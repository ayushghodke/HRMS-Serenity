import { EntityGrid } from '@serenity-is/corelib';
import { LeaveColumns, LeaveRow, LeaveService } from '../../ServerTypes/Operations';
import { LeaveDialog } from './LeaveDialog';

export class LeaveGrid extends EntityGrid<LeaveRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.LeaveGrid");

    protected override getColumnsKey() { return LeaveColumns.columnsKey; }
    protected override getDialogType() { return LeaveDialog; }
    protected override getRowDefinition() { return LeaveRow; }
    protected override getService() { return LeaveService.baseUrl; }
}
