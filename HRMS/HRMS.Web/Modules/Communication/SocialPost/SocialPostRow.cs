using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.Collections.Generic;
using System.ComponentModel;

namespace HRMS.Communication;

[ConnectionKey("Default"), Module("Communication"), TableName("SocialPost")]
[DisplayName("Social Post"), InstanceName("Social Post")]
[ReadPermission("HumanResources")]
[ModifyPermission("HumanResources")]
public sealed class SocialPostRow : Row<SocialPostRow.RowFields>, IIdRow, INameRow, ILoggingRow
{
    [DisplayName("Id"), Identity, IdProperty]
    public int? SocialPostId { get => fields.SocialPostId[this]; set => fields.SocialPostId[this] = value; }

    [DisplayName("Social Account"), NotNull, ForeignKey("SocialAccount", "SocialAccountId"), LeftJoin("sa")]
    [LookupEditor(typeof(SocialAccountRow), InplaceAdd = false)]
    public int? SocialAccountId { get => fields.SocialAccountId[this]; set => fields.SocialAccountId[this] = value; }

    [DisplayName("Account Name"), Expression("sa.[AccountName]")]
    public string SocialAccountName { get => fields.SocialAccountName[this]; set => fields.SocialAccountName[this] = value; }

    [DisplayName("Platform"), Expression("sa.[Platform]")]
    public SocialPlatform? SocialAccountPlatform { get => (SocialPlatform?)fields.SocialAccountPlatform[this]; set => fields.SocialAccountPlatform[this] = (int?)value; }

    [DisplayName("Title"), Size(300), NameProperty, QuickSearch]
    public string Title { get => fields.Title[this]; set => fields.Title[this] = value; }

    [DisplayName("Content"), NotNull]
    public string Content { get => fields.Content[this]; set => fields.Content[this] = value; }

    [DisplayName("Post Type"), NotNull, DefaultValue(SocialPostType.Text)]
    public SocialPostType? PostType { get => (SocialPostType?)fields.PostType[this]; set => fields.PostType[this] = (int?)value; }

    [DisplayName("Status"), NotNull, DefaultValue(SocialPostStatus.Draft)]
    public SocialPostStatus? Status { get => (SocialPostStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Scheduled Date")]
    public DateTime? ScheduledDate { get => fields.ScheduledDate[this]; set => fields.ScheduledDate[this] = value; }

    [DisplayName("Published Date")]
    public DateTime? PublishedDate { get => fields.PublishedDate[this]; set => fields.PublishedDate[this] = value; }

    [DisplayName("External Post Id"), Size(500)]
    public string ExternalPostId { get => fields.ExternalPostId[this]; set => fields.ExternalPostId[this] = value; }

    [DisplayName("Error Message"), Size(2000)]
    public string ErrorMessage { get => fields.ErrorMessage[this]; set => fields.ErrorMessage[this] = value; }

    [DisplayName("Media"), MasterDetailRelation(foreignKey: "SocialPostId"), NotMapped]
    public List<SocialPostMediaRow> MediaList { get => fields.MediaList[this]; set => fields.MediaList[this] = value; }

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
        public Int32Field SocialPostId;
        public Int32Field SocialAccountId;
        public StringField SocialAccountName;
        public Int32Field SocialAccountPlatform;
        public StringField Title;
        public StringField Content;
        public Int32Field PostType;
        public Int32Field Status;
        public DateTimeField ScheduledDate;
        public DateTimeField PublishedDate;
        public StringField ExternalPostId;
        public StringField ErrorMessage;
        public RowListField<SocialPostMediaRow> MediaList;
        public Int32Field InsertUserId;
        public DateTimeField InsertDate;
        public Int32Field UpdateUserId;
        public DateTimeField UpdateDate;
    }
}

public enum SocialPostType
{
    [Description("Text")]
    Text = 1,

    [Description("Image")]
    Image = 2,

    [Description("Video")]
    Video = 3,

    [Description("Carousel")]
    Carousel = 4
}

public enum SocialPostStatus
{
    [Description("Draft")]
    Draft = 1,

    [Description("Scheduled")]
    Scheduled = 2,

    [Description("Published")]
    Published = 3,

    [Description("Failed")]
    Failed = 4
}
