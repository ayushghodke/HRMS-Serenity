import { EntityDialog } from '@serenity-is/corelib';
import { PayrollForm, PayrollRow, PayrollService } from '../../ServerTypes/Operations';

export class PayrollDialog extends EntityDialog<PayrollRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.PayrollDialog");

    protected override getFormKey() { return PayrollForm.formKey; }
    protected override getRowDefinition() { return PayrollRow; }
    protected override getService() { return PayrollService.baseUrl; }

    protected form = new PayrollForm(this.idPrefix);
}
