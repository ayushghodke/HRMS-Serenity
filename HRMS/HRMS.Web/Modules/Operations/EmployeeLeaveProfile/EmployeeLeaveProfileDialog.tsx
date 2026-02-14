import { EntityDialog } from '@serenity-is/corelib';
import { EmployeeLeaveProfileForm, EmployeeLeaveProfileRow, EmployeeLeaveProfileService } from '../../ServerTypes/Operations';

export class EmployeeLeaveProfileDialog extends EntityDialog<EmployeeLeaveProfileRow, any> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.EmployeeLeaveProfileDialog');

    protected override getFormKey() { return EmployeeLeaveProfileForm.formKey; }
    protected override getRowDefinition() { return EmployeeLeaveProfileRow; }
    protected override getService() { return EmployeeLeaveProfileService.baseUrl; }

    protected form = new EmployeeLeaveProfileForm(this.idPrefix);
}
