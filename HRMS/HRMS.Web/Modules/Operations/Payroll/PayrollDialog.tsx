import { Decorators, EntityDialog, serviceCall } from '@serenity-is/corelib';
import { PayrollForm, PayrollRow, PayrollService, SalaryComponentType } from '../../ServerTypes/Operations';
import { EmployeeSalaryService } from '../../ServerTypes/HR';

@Decorators.registerClass('HRMS.Operations.PayrollDialog')
export class PayrollDialog extends EntityDialog<PayrollRow, any> {
    protected override getFormKey() { return PayrollForm.formKey; }
    protected override getRowDefinition() { return PayrollRow; }
    protected override getService() { return PayrollService.baseUrl; }

    protected form = new PayrollForm(this.idPrefix);

    constructor() {
        super();

        this.form.EmployeeId.change(e => {
            var employeeId = this.form.EmployeeId.value;
            if (employeeId) {
                this.calculatePayroll(employeeId);
            }
        });
    }

    protected calculatePayroll(employeeId: string) {
        serviceCall({
            service: EmployeeSalaryService.baseUrl + '/GetSalaryStructure',
            request: { EmployeeId: parseInt(employeeId) },
            onSuccess: (response: any) => {
                if (response) {
                    var basic = response.BasicSalary || 0;
                    var earnings = 0;
                    var deductions = 0;
                    var details = response.DetailList || [];

                    for (var item of details) {
                        if (item.ComponentType == SalaryComponentType.Earning) {
                            earnings += (item.Amount || 0);
                        }
                        else if (item.ComponentType == SalaryComponentType.Deduction) {
                            deductions += (item.Amount || 0);
                        }
                    }

                    this.form.BasicSalary.value = basic;
                    this.form.Allowances.value = earnings; // Earnings excluding Basic?  
                    // Wait, usually Basic is part of Earnings. 
                    // But in our form, we have Basic, Allowances, Deductions.
                    // If Allowances means "Other Earnings", then we need to subtract Basic from Total Earnings if Basic is a component?
                    // But Basic is usually a separate field in EmployeeSalaryRow.
                    // In DetailList, do we include Basic?
                    // Setup: EmployeeSalary has BasicSalary field. DetailList has "HRA", "DA", etc.
                    // So Earnings Loop should ideally NOT include Basic unless Basic is ALSO in DetailList (which creates duplication).
                    // Assuming Basic is separate.

                    this.form.Deductions.value = deductions;
                    this.form.NetSalary.value = (basic + earnings) - deductions;
                }
            }
        });
    }
}
