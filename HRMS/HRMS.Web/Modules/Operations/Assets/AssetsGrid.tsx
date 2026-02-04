import { EntityGrid } from '@serenity-is/corelib';
import { AssetsColumns, AssetsRow, AssetsService } from '../../ServerTypes/Operations';
import { AssetsDialog } from './AssetsDialog';

export class AssetsGrid extends EntityGrid<AssetsRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.AssetsGrid");

    protected override getColumnsKey() { return AssetsColumns.columnsKey; }
    protected override getDialogType() { return AssetsDialog; }
    protected override getRowDefinition() { return AssetsRow; }
    protected override getService() { return AssetsService.baseUrl; }
}
