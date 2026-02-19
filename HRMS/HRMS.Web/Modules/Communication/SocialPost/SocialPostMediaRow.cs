using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Communication;

[ConnectionKey("Default"), Module("Communication"), TableName("SocialPostMedia")]
[DisplayName("Post Media"), InstanceName("Post Media")]
[ReadPermission("HumanResources")]
[ModifyPermission("HumanResources")]
public sealed class SocialPostMediaRow : Row<SocialPostMediaRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Id"), Identity, IdProperty]
    public int? SocialPostMediaId { get => fields.SocialPostMediaId[this]; set => fields.SocialPostMediaId[this] = value; }

    [DisplayName("Social Post"), NotNull, ForeignKey("SocialPost", "SocialPostId")]
    public int? SocialPostId { get => fields.SocialPostId[this]; set => fields.SocialPostId[this] = value; }

    [DisplayName("File"), NotNull, Size(500), NameProperty]
    [ImageUploadEditor(FilenameFormat = "SocialMedia/~", CopyToHistory = true)]
    public string FileName { get => fields.FileName[this]; set => fields.FileName[this] = value; }

    [DisplayName("Media Type"), NotNull, DefaultValue(SocialMediaType.Image)]
    public SocialMediaType? MediaType { get => (SocialMediaType?)fields.MediaType[this]; set => fields.MediaType[this] = (int?)value; }

    [DisplayName("Display Order"), NotNull, DefaultValue(0)]
    public int? DisplayOrder { get => fields.DisplayOrder[this]; set => fields.DisplayOrder[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field SocialPostMediaId;
        public Int32Field SocialPostId;
        public StringField FileName;
        public Int32Field MediaType;
        public Int32Field DisplayOrder;
    }
}

public enum SocialMediaType
{
    [Description("Image")]
    Image = 1,

    [Description("Video")]
    Video = 2
}
