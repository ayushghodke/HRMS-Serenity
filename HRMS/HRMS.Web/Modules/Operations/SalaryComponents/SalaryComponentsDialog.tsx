import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { SalaryComponentsForm, SalaryComponentsRow, SalaryComponentsService } from '../../ServerTypes/Operations';

@Decorators.registerClass('HRMS.Operations.SalaryComponentsDialog')
export class SalaryComponentsDialog extends EntityDialog<SalaryComponentsRow, any> {
    protected override getFormKey() { return SalaryComponentsForm.formKey; }
    protected override getRowDefinition() { return SalaryComponentsRow; }
    protected override getService() { return SalaryComponentsService.baseUrl; }

    protected form = new SalaryComponentsForm(this.idPrefix);
}
