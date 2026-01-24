import { EntityGrid } from '@serenity-is/corelib';
import { AttendanceColumns, AttendanceRow, AttendanceService } from '../../ServerTypes/Operations';
import { AttendanceDialog } from './AttendanceDialog';

export class AttendanceGrid extends EntityGrid<AttendanceRow> {
    static override [Symbol.typeInfo] = this.registerClass("HRMS.Operations.");

    protected override getColumnsKey() { return AttendanceColumns.columnsKey; }
    protected override getDialogType() { return AttendanceDialog; }
    protected override getRowDefinition() { return AttendanceRow; }
    protected override getService() { return AttendanceService.baseUrl; }
}