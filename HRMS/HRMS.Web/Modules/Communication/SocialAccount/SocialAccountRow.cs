using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Communication;

[ConnectionKey("Default"), Module("Communication"), TableName("SocialAccount")]
[DisplayName("Social Account"), InstanceName("Social Account")]
[ReadPermission("HumanResources")]
[ModifyPermission("HumanResources")]
[LookupScript("Communication.SocialAccount", Permission = "*")]
public sealed class SocialAccountRow : Row<SocialAccountRow.RowFields>, IIdRow, INameRow, ILoggingRow
{
    [DisplayName("Id"), Identity, IdProperty]
    public int? SocialAccountId { get => fields.SocialAccountId[this]; set => fields.SocialAccountId[this] = value; }

    [DisplayName("Platform"), NotNull]
    public SocialPlatform? Platform { get => (SocialPlatform?)fields.Platform[this]; set => fields.Platform[this] = (int?)value; }

    [DisplayName("Account Name"), Size(200), NotNull, QuickSearch, NameProperty]
    public string AccountName { get => fields.AccountName[this]; set => fields.AccountName[this] = value; }

    [DisplayName("Profile Url"), Size(500)]
    public string ProfileUrl { get => fields.ProfileUrl[this]; set => fields.ProfileUrl[this] = value; }

    [DisplayName("Access Token"), Size(2000), Insertable(false), Updatable(false)]
    public string AccessToken { get => fields.AccessToken[this]; set => fields.AccessToken[this] = value; }

    [DisplayName("Refresh Token"), Size(2000), Insertable(false), Updatable(false)]
    public string RefreshToken { get => fields.RefreshToken[this]; set => fields.RefreshToken[this] = value; }

    [DisplayName("Token Expiry"), Insertable(false), Updatable(false)]
    public DateTime? TokenExpiry { get => fields.TokenExpiry[this]; set => fields.TokenExpiry[this] = value; }

    [DisplayName("Is Active"), NotNull, DefaultValue(true)]
    public bool? IsActive { get => fields.IsActive[this]; set => fields.IsActive[this] = value; }

    [DisplayName("Connected Date")]
    public DateTime? ConnectedDate { get => fields.ConnectedDate[this]; set => fields.ConnectedDate[this] = value; }

    [NotNull, Insertable(false), Updatable(false)]
    public int? InsertUserId { get => fields.InsertUserId[this]; set => fields.InsertUserId[this] = value; }

    [NotNull, Insertable(false), Updatable(false)]
    public DateTime? InsertDate { get => fields.InsertDate[this]; set => fields.InsertDate[this] = value; }

    [Insertable(false), Updatable(false)]
    public int? UpdateUserId { get => fields.UpdateUserId[this]; set => fields.UpdateUserId[this] = value; }

    [Insertable(false), Updatable(false)]
    public DateTime? UpdateDate { get => fields.UpdateDate[this]; set => fields.UpdateDate[this] = value; }

    Field IInsertUserIdRow.InsertUserIdField => fields.InsertUserId;
    DateTimeField IInsertDateRow.InsertDateField => fields.InsertDate;
    Field IUpdateUserIdRow.UpdateUserIdField => fields.UpdateUserId;
    DateTimeField IUpdateDateRow.UpdateDateField => fields.UpdateDate;

    public class RowFields : RowFieldsBase
    {
        public Int32Field SocialAccountId;
        public Int32Field Platform;
        public StringField AccountName;
        public StringField ProfileUrl;
        public StringField AccessToken;
        public StringField RefreshToken;
        public DateTimeField TokenExpiry;
        public BooleanField IsActive;
        public DateTimeField ConnectedDate;
        public Int32Field InsertUserId;
        public DateTimeField InsertDate;
        public Int32Field UpdateUserId;
        public DateTimeField UpdateDate;
    }
}

public enum SocialPlatform
{
    [Description("Facebook")]
    Facebook = 1,

    [Description("Instagram")]
    Instagram = 2,

    [Description("LinkedIn")]
    LinkedIn = 3
}
