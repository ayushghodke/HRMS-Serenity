import { EntityDialog } from '@serenity-is/corelib';
import { EmployeeForm, EmployeeRow, EmployeeService } from '../../ServerTypes/HR';

export class EmployeeDialog extends EntityDialog<EmployeeRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.HR.EmployeeDialog");

    protected override getFormKey() { return EmployeeForm.formKey; }
    protected override getRowDefinition() { return EmployeeRow; }
    protected override getService() { return EmployeeService.baseUrl; }

    protected form = new EmployeeForm(this.idPrefix);
}
