import { EntityDialog } from '@serenity-is/corelib';
import { LeaveForm, LeaveRow, LeaveService } from '../../ServerTypes/Operations';

export class LeaveDialog extends EntityDialog<LeaveRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.LeaveDialog");

    protected override getFormKey() { return LeaveForm.formKey; }
    protected override getRowDefinition() { return LeaveRow; }
    protected override getService() { return LeaveService.baseUrl; }

    protected form = new LeaveForm(this.idPrefix);
}
