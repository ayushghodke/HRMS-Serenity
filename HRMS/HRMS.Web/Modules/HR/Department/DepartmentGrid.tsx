import { EntityGrid } from '@serenity-is/corelib';
import { DepartmentColumns, DepartmentRow, DepartmentService } from '../../ServerTypes/HR';
import { DepartmentDialog } from './DepartmentDialog';

export class DepartmentGrid extends EntityGrid<DepartmentRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.HR.DepartmentGrid");

    protected override getColumnsKey() { return DepartmentColumns.columnsKey; }
    protected override getDialogType() { return DepartmentDialog; }
    protected override getRowDefinition() { return DepartmentRow; }
    protected override getService() { return DepartmentService.baseUrl; }
}
