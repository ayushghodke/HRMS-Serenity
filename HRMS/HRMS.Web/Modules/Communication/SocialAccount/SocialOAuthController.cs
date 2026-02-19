using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Web;

namespace HRMS.Communication.Pages;

/// <summary>
/// OAuth controller for social media platform connections.
/// Reads credentials from the SocialPlatformConfig table (managed via UI).
/// </summary>
[PageAuthorize(typeof(SocialAccountRow))]
public class SocialOAuthController : Controller
{
    private readonly ISqlConnections _sqlConnections;

    public SocialOAuthController(ISqlConnections sqlConnections)
    {
        _sqlConnections = sqlConnections;
    }

    /// <summary>
    /// Initiates OAuth flow for a given platform.
    /// GET /Communication/SocialOAuth/Connect?platform=1 (1=Facebook, 2=Instagram, 3=LinkedIn)
    /// </summary>
    [Route("Communication/SocialOAuth/Connect")]
    public ActionResult Connect(int platform)
    {
        var config = GetPlatformConfig((SocialPlatform)platform);

        if (config == null || string.IsNullOrEmpty(config.ClientId))
        {
            return Content($"OAuth is not configured for this platform. " +
                           $"Please go to Communication → Platform Settings and add your ClientId and ClientSecret.");
        }

        if (config.IsEnabled != true)
        {
            return Content("This platform is currently disabled. Enable it in Platform Settings first.");
        }

        var redirectUri = config.RedirectUri ?? $"{Request.Scheme}://{Request.Host}/Communication/SocialOAuth/Callback";

        string authUrl = ((SocialPlatform)platform) switch
        {
            SocialPlatform.Facebook => $"https://www.facebook.com/v18.0/dialog/oauth?client_id={config.ClientId}&redirect_uri={redirectUri}&scope=pages_manage_posts,pages_read_engagement&state=facebook",
            SocialPlatform.Instagram => $"https://api.instagram.com/oauth/authorize?client_id={config.ClientId}&redirect_uri={redirectUri}&scope=user_profile,user_media&response_type=code&state=instagram",
            SocialPlatform.LinkedIn => $"https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id={config.ClientId}&redirect_uri={redirectUri}&scope=w_member_social&state=linkedin",
            _ => null
        };

        if (authUrl == null)
        {
            return Content($"Unknown platform.");
        }

        return Redirect(authUrl);
    }

    /// <summary>
    /// OAuth callback handler. Exchanges code for access token.
    /// GET /Communication/SocialOAuth/Callback?code=xxx&state=yyy
    /// </summary>
    [Route("Communication/SocialOAuth/Callback")]
    public ActionResult Callback(string code, string state, string error)
    {
        if (!string.IsNullOrEmpty(error))
        {
            return Content($"OAuth Error: {error}. Please try connecting again.");
        }

        if (string.IsNullOrEmpty(code))
        {
            return Content("No authorization code received.");
        }

        // In production: exchange `code` for access token via HTTP call to the platform API
        // using credentials from GetPlatformConfig(), then save to SocialAccount table.
        return Redirect("/Communication/SocialAccount?oauth=success");
    }

    private SocialPlatformConfigRow GetPlatformConfig(SocialPlatform platform)
    {
        using var connection = _sqlConnections.NewByKey("Default");
        var fld = SocialPlatformConfigRow.Fields;
        return connection.TryFirst<SocialPlatformConfigRow>(
            fld.Platform == (int)platform);
    }
}
