namespace HRMS.HR;

public partial class EmployeeDocsEditorAttribute : CustomEditorAttribute
{
    public const string Key = "HRMS.HR.EmployeeDocsEditor";

    public EmployeeDocsEditorAttribute()
        : base(Key)
    {
    }
}