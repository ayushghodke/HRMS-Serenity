import { EntityDialog } from '@serenity-is/corelib';
import { LeaveBalanceForm, LeaveBalanceRow, LeaveBalanceService } from '../../ServerTypes/Operations';

export class LeaveBalanceDialog extends EntityDialog<LeaveBalanceRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.LeaveBalanceDialog");

    protected override getFormKey() { return LeaveBalanceForm.formKey; }
    protected override getRowDefinition() { return LeaveBalanceRow; }
    protected override getService() { return LeaveBalanceService.baseUrl; }

    protected override form = new LeaveBalanceForm(this.idPrefix);
}
