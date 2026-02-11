import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { EmployeeSalaryColumns, EmployeeSalaryRow, EmployeeSalaryService } from '../../ServerTypes/HR';
import { EmployeeSalaryDialog } from './EmployeeSalaryDialog';

@Decorators.registerClass('HRMS.HR.EmployeeSalaryGrid')
export class EmployeeSalaryGrid extends EntityGrid<EmployeeSalaryRow> {
    protected override getColumnsKey() { return EmployeeSalaryColumns.columnsKey; }
    protected override getDialogType() { return EmployeeSalaryDialog; }
    protected override getRowDefinition() { return EmployeeSalaryRow; }
    protected override getService() { return EmployeeSalaryService.baseUrl; }
}
