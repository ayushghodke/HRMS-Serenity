import { EntityGrid } from '@serenity-is/corelib';
import { EmployeeLeaveProfileColumns, EmployeeLeaveProfileRow, EmployeeLeaveProfileService } from '../../ServerTypes/Operations';
import { EmployeeLeaveProfileDialog } from './EmployeeLeaveProfileDialog';

export class EmployeeLeaveProfileGrid extends EntityGrid<EmployeeLeaveProfileRow> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.EmployeeLeaveProfileGrid');

    protected override getColumnsKey() { return EmployeeLeaveProfileColumns.columnsKey; }
    protected override getDialogType() { return EmployeeLeaveProfileDialog; }
    protected override getRowDefinition() { return EmployeeLeaveProfileRow; }
    protected override getService() { return EmployeeLeaveProfileService.baseUrl; }
}
