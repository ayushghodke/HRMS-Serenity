import { EntityGrid } from '@serenity-is/corelib';
import { LeaveApprovalColumns, LeaveApprovalRow, LeaveApprovalService } from '../../ServerTypes/Operations';
import { LeaveApprovalDialog } from './LeaveApprovalDialog';

export class LeaveApprovalGrid extends EntityGrid<LeaveApprovalRow> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.LeaveApprovalGrid');

    protected override getColumnsKey() { return LeaveApprovalColumns.columnsKey; }
    protected override getDialogType() { return LeaveApprovalDialog; }
    protected override getRowDefinition() { return LeaveApprovalRow; }
    protected override getService() { return LeaveApprovalService.baseUrl; }
}
