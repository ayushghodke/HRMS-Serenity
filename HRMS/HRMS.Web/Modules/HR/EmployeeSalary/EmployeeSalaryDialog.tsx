import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { EmployeeSalaryForm, EmployeeSalaryRow, EmployeeSalaryService } from '../../ServerTypes/HR';

@Decorators.registerClass('HRMS.HR.EmployeeSalaryDialog')
export class EmployeeSalaryDialog extends EntityDialog<EmployeeSalaryRow, any> {
    protected override getFormKey() { return EmployeeSalaryForm.formKey; }
    protected override getRowDefinition() { return EmployeeSalaryRow; }
    protected override getService() { return EmployeeSalaryService.baseUrl; }

    protected form = new EmployeeSalaryForm(this.idPrefix);

    constructor() {
        super();

        this.form.BasicSalary.change(e => this.calculateGross());
    }

    protected calculateGross() {
        // Simple calculation for now: Basic + sum of earnings (where type is Earning)
        // This requires access to the details list and component types
        // For now, just a placeholder or basic sum if we have details
    }
}
