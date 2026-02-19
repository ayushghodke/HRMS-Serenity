using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Communication;

[ConnectionKey("Default"), Module("Communication"), TableName("SocialPlatformConfig")]
[DisplayName("Platform Settings"), InstanceName("Platform Settings")]
[ReadPermission("Administration")]
[ModifyPermission("Administration")]
public sealed class SocialPlatformConfigRow : Row<SocialPlatformConfigRow.RowFields>, IIdRow, INameRow, ILoggingRow
{
    [DisplayName("Id"), Identity, IdProperty]
    public int? SocialPlatformConfigId { get => fields.SocialPlatformConfigId[this]; set => fields.SocialPlatformConfigId[this] = value; }

    [DisplayName("Platform"), NotNull, Unique]
    public SocialPlatform? Platform { get => (SocialPlatform?)fields.Platform[this]; set => fields.Platform[this] = (int?)value; }

    [DisplayName("Client Id"), Size(500), NameProperty]
    public string ClientId { get => fields.ClientId[this]; set => fields.ClientId[this] = value; }

    [DisplayName("Client Secret"), Size(500)]
    [PasswordEditor]
    public string ClientSecret { get => fields.ClientSecret[this]; set => fields.ClientSecret[this] = value; }

    [DisplayName("Redirect URI"), Size(500)]
    public string RedirectUri { get => fields.RedirectUri[this]; set => fields.RedirectUri[this] = value; }

    [DisplayName("Enabled"), NotNull, DefaultValue(false)]
    public bool? IsEnabled { get => fields.IsEnabled[this]; set => fields.IsEnabled[this] = value; }

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
        public Int32Field SocialPlatformConfigId;
        public Int32Field Platform;
        public StringField ClientId;
        public StringField ClientSecret;
        public StringField RedirectUri;
        public BooleanField IsEnabled;
        public Int32Field InsertUserId;
        public DateTimeField InsertDate;
        public Int32Field UpdateUserId;
        public DateTimeField UpdateDate;
    }
}
