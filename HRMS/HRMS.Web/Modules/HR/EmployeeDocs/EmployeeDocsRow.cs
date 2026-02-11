using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace HRMS.HR;

[ConnectionKey("Default"), Module("HR"), TableName("EmployeeDocs")]
[DisplayName("Employee Documents"), InstanceName("Document")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
public sealed class EmployeeDocsRow : Row<EmployeeDocsRow.RowFields>, IIdRow
{
    [DisplayName("Document Id"), Identity, IdProperty]
    public int? DocumentId
    {
        get => fields.DocumentId[this];
        set => fields.DocumentId[this] = value;
    }

    [DisplayName("Employee"), NotNull, ForeignKey("Employee", "EmployeeId"), LeftJoin("jEmployee"), TextualField("EmployeeFirstName")]
    public int? EmployeeId
    {
        get => fields.EmployeeId[this];
        set => fields.EmployeeId[this] = value;
    }

    [DisplayName("Document Type"), NotNull]
    public DocumentKind? DocumentType
    {
        get => (DocumentKind?)fields.DocumentType[this];
        set => fields.DocumentType[this] = (int?)value;
    }

    [DisplayName("Title"), Size(200), QuickSearch]
    public string Title
    {
        get => fields.Title[this];
        set => fields.Title[this] = value;
    }

    [DisplayName("Description"), Size(1000)]
    public string Description
    {
        get => fields.Description[this];
        set => fields.Description[this] = value;
    }

    [DisplayName("File Path"), Size(1000), ImageUploadEditor(FilenameFormat = "EmployeeDocuments/~", CopyToHistory = true)]
    public string FilePath
    {
        get => fields.FilePath[this];
        set => fields.FilePath[this] = value;
    }

    [DisplayName("Uploaded On")]
    public DateTime? UploadedOn
    {
        get => fields.UploadedOn[this];
        set => fields.UploadedOn[this] = value;
    }

    [DisplayName("Employee First Name"), Expression("jEmployee.[FirstName]")]
    public string EmployeeFirstName
    {
        get => fields.EmployeeFirstName[this];
        set => fields.EmployeeFirstName[this] = value;
    }

    public class RowFields : RowFieldsBase
    {
        public Int32Field DocumentId;
        public Int32Field EmployeeId;
        public Int32Field DocumentType;
        public StringField Title;
        public StringField Description;
        public StringField FilePath;
        public DateTimeField UploadedOn;

        public StringField EmployeeFirstName;
    }
}

public enum DocumentKind
{
    [Description("Aadhar Card")]
    Aadhar = 1,
    [Description("PAN Card")]
    PAN = 2,
    [Description("Resume")]
    Resume = 3,
    [Description("Offer Letter")]
    OfferLetter = 4,
    [Description("Other")]
    Other = 5
}
