import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { EmployeeSalaryForm, EmployeeSalaryRow, EmployeeSalaryService } from '../../ServerTypes/HR';
import { EmployeeSalaryDetailsEditor } from './EmployeeSalaryDetailsEditor';
import { SalaryComponentType } from '../../ServerTypes/Operations';

@Decorators.registerClass('HRMS.HR.EmployeeSalaryDialog')
export class EmployeeSalaryDialog extends EntityDialog<EmployeeSalaryRow, any> {
    protected override getFormKey() { return EmployeeSalaryForm.formKey; }
    protected override getRowDefinition() { return EmployeeSalaryRow; }
    protected override getService() { return EmployeeSalaryService.baseUrl; }

    protected form = new EmployeeSalaryForm(this.idPrefix);

    constructor() {
        super();

        this.form.BasicSalary.change(e => this.calculateGross());
        (this.form.DetailList as EmployeeSalaryDetailsEditor).change(e => this.calculateGross());
    }

    protected calculateGross() {
        var basic = this.form.BasicSalary.value || 0;
        var details = (this.form.DetailList as EmployeeSalaryDetailsEditor).value || [];

        var earnings = 0;
        for (var item of details) {
            if (item.ComponentType == SalaryComponentType.Earning) {
                earnings += (item.Amount || 0);
            }
        }

        this.form.GrossSalary.value = basic + earnings;
    }
}
