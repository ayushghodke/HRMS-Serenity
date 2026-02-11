import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { SalaryGradeForm, SalaryGradeRow, SalaryGradeService } from '../../ServerTypes/Operations';

@Decorators.registerClass('HRMS.Operations.SalaryGradeDialog')
export class SalaryGradeDialog extends EntityDialog<SalaryGradeRow, any> {
    protected override getFormKey() { return SalaryGradeForm.formKey; }
    protected override getRowDefinition() { return SalaryGradeRow; }
    protected override getService() { return SalaryGradeService.baseUrl; }

    protected form = new SalaryGradeForm(this.idPrefix);
}
