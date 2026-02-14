import { EntityDialog } from '@serenity-is/corelib';
import { LeavePolicyForm, LeavePolicyRow, LeavePolicyService } from '../../ServerTypes/Operations';

export class LeavePolicyDialog extends EntityDialog<LeavePolicyRow, any> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.LeavePolicyDialog');

    protected override getFormKey() { return LeavePolicyForm.formKey; }
    protected override getRowDefinition() { return LeavePolicyRow; }
    protected override getService() { return LeavePolicyService.baseUrl; }

    protected form = new LeavePolicyForm(this.idPrefix);
}
