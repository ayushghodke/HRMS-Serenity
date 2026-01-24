import { EntityGrid } from '@serenity-is/corelib';
import { LeaveBalanceColumns, LeaveBalanceRow, LeaveBalanceService } from '../../ServerTypes/Operations';
import { LeaveBalanceDialog } from './LeaveBalanceDialog';

export class LeaveBalanceGrid extends EntityGrid<LeaveBalanceRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.LeaveBalanceGrid");

    protected override getColumnsKey() { return LeaveBalanceColumns.columnsKey; }
    protected override getDialogType() { return LeaveBalanceDialog; }
    protected override getRowDefinition() { return LeaveBalanceRow; }
    protected override getService() { return LeaveBalanceService.baseUrl; }
}
