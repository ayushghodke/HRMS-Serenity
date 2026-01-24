import { EntityGrid } from '@serenity-is/corelib';
import { DesignationColumns, DesignationRow, DesignationService } from '../../ServerTypes/HR';
import { DesignationDialog } from './DesignationDialog';

export class DesignationGrid extends EntityGrid<DesignationRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.HR.DesignationGrid");

    protected override getColumnsKey() { return DesignationColumns.columnsKey; }
    protected override getDialogType() { return DesignationDialog; }
    protected override getRowDefinition() { return DesignationRow; }
    protected override getService() { return DesignationService.baseUrl; }
}
