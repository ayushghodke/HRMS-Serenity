import { EntityDialog } from '@serenity-is/corelib';
import { LeaveTypeForm, LeaveTypeRow, LeaveTypeService } from '../../ServerTypes/Operations';

export class LeaveTypeDialog extends EntityDialog<LeaveTypeRow, any> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.LeaveTypeDialog');

    protected override getFormKey() { return LeaveTypeForm.formKey; }
    protected override getRowDefinition() { return LeaveTypeRow; }
    protected override getService() { return LeaveTypeService.baseUrl; }

    protected form = new LeaveTypeForm(this.idPrefix);
}
