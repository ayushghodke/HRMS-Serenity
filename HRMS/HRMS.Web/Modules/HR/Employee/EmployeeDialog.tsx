import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { EmployeeForm, EmployeeRow, EmployeeService } from '../../ServerTypes/HR';
import { EmployeeDocsGrid } from '../EmployeeDocs/EmployeeDocsGrid';

@Decorators.registerClass('HRMS.HR.EmployeeDialog')
export class EmployeeDialog extends EntityDialog<EmployeeRow, any> {
    static override[Symbol.typeInfo] = EmployeeDialog.registerClass("HRMS.HR.EmployeeDialog");

    protected override getFormKey() { return EmployeeForm.formKey; }
    protected override getRowDefinition() { return EmployeeRow; }
    protected override getService() { return EmployeeService.baseUrl; }

    protected form = new EmployeeForm(this.idPrefix);
}
