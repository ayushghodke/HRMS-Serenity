import { Decorators } from '@serenity-is/corelib';
import { GridEditorDialog } from '../../Common/Helpers/GridEditorDialog';
import { EmployeeDocsForm, EmployeeDocsRow } from '../../ServerTypes/HR';

@Decorators.registerClass('HRMS.HR.EmployeeDocsEditDialog')
export class EmployeeDocsEditDialog extends GridEditorDialog<EmployeeDocsRow> {
    protected override getFormKey() { return EmployeeDocsForm.formKey; }
    protected override getRowDefinition() { return EmployeeDocsRow; }
    protected override getLocalTextPrefix() { return EmployeeDocsRow.localTextPrefix; }

    protected form = new EmployeeDocsForm(this.idPrefix);
}
