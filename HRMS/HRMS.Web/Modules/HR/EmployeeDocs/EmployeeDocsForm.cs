using Serenity.ComponentModel;
using System;

namespace HRMS.HR.Forms;

[FormScript("HR.EmployeeDocs")]
[BasedOnRow(typeof(EmployeeDocsRow), CheckNames = true)]
public class EmployeeDocsForm
{
    public DocumentKind DocumentType { get; set; }
    public string Title { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Description { get; set; }
    public string FilePath { get; set; }
}
