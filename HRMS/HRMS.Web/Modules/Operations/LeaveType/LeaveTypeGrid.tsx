import { EntityGrid } from '@serenity-is/corelib';
import { LeaveTypeColumns, LeaveTypeRow, LeaveTypeService } from '../../ServerTypes/Operations';
import { LeaveTypeDialog } from './LeaveTypeDialog';

export class LeaveTypeGrid extends EntityGrid<LeaveTypeRow> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.LeaveTypeGrid');

    protected override getColumnsKey() { return LeaveTypeColumns.columnsKey; }
    protected override getDialogType() { return LeaveTypeDialog; }
    protected override getRowDefinition() { return LeaveTypeRow; }
    protected override getService() { return LeaveTypeService.baseUrl; }
}
