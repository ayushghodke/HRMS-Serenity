import { EntityGrid } from '@serenity-is/corelib';
import { EmployeeColumns, EmployeeRow, EmployeeService } from '../../ServerTypes/HR';
import { EmployeeDialog } from './EmployeeDialog';

export class EmployeeGrid extends EntityGrid<EmployeeRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.HR.EmployeeGrid");

    protected override getColumnsKey() { return EmployeeColumns.columnsKey; }
    protected override getDialogType() { return EmployeeDialog; }
    protected override getRowDefinition() { return EmployeeRow; }
    protected override getService() { return EmployeeService.baseUrl; }
}
