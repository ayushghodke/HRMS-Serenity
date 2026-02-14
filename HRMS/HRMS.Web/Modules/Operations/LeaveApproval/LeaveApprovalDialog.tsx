import { EntityDialog } from '@serenity-is/corelib';
import { LeaveApprovalForm, LeaveApprovalRow, LeaveApprovalService } from '../../ServerTypes/Operations';

export class LeaveApprovalDialog extends EntityDialog<LeaveApprovalRow, any> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.LeaveApprovalDialog');

    protected override getFormKey() { return LeaveApprovalForm.formKey; }
    protected override getRowDefinition() { return LeaveApprovalRow; }
    protected override getService() { return LeaveApprovalService.baseUrl; }

    protected form = new LeaveApprovalForm(this.idPrefix);
}
