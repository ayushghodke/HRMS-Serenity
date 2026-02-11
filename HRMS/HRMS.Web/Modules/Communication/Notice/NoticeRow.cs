using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Communication;

[ConnectionKey("Default"), Module("Communication"), TableName("Notice")]
[DisplayName("Notice"), InstanceName("Notice")]
[ReadPermission("*")]
[ModifyPermission("HumanResources")]
public sealed class NoticeRow : Row<NoticeRow.RowFields>, IIdRow, INameRow, ILoggingRow
{
    [DisplayName("Notice Id"), Identity, IdProperty]
    public int? NoticeId { get => fields.NoticeId[this]; set => fields.NoticeId[this] = value; }

    [DisplayName("Title"), Size(200), NotNull, QuickSearch, NameProperty]
    public string Title { get => fields.Title[this]; set => fields.Title[this] = value; }

    [DisplayName("Description"), NotNull]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Priority"), NotNull, DefaultValue(NoticePriority.Normal)]
    public NoticePriority? Priority { get => (NoticePriority?)fields.Priority[this]; set => fields.Priority[this] = (int?)value; }

    [DisplayName("Publish Date"), NotNull, DefaultValue("now")]
    public DateTime? PublishDate { get => fields.PublishDate[this]; set => fields.PublishDate[this] = value; }

    [DisplayName("Expiry Date")]
    public DateTime? ExpiryDate { get => fields.ExpiryDate[this]; set => fields.ExpiryDate[this] = value; }

    [DisplayName("Is Active"), NotNull, DefaultValue(true)]
    public bool? IsActive { get => fields.IsActive[this]; set => fields.IsActive[this] = value; }

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
        public Int32Field NoticeId;
        public StringField Title;
        public StringField Description;
        public Int32Field Priority;
        public DateTimeField PublishDate;
        public DateTimeField ExpiryDate;
        public BooleanField IsActive;
        public Int32Field InsertUserId;
        public DateTimeField InsertDate;
        public Int32Field UpdateUserId;
        public DateTimeField UpdateDate;
    }
}

public enum NoticePriority
{
    [Description("Low")]
    Low = 1,
    
    [Description("Normal")]
    Normal = 2,
    
    [Description("High")]
    High = 3
}
