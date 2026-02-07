using Serenity.ComponentModel;
using System;

namespace HRMS.HR.Columns;

[ColumnsScript("HR.EmployeeDocs")]
[BasedOnRow(typeof(EmployeeDocsRow), CheckNames = true)]
public class EmployeeDocsColumns
{
    [EditLink, Width(150)]
    public DocumentKind DocumentType { get; set; }
    [EditLink, Width(200)]
    public string Title { get; set; }
    [Width(300)]
    public string Description { get; set; }
    [Width(100), AlignRight]
    public DateTime UploadedOn { get; set; }
    [Width(80)]
    public string FilePath { get; set; }
}
