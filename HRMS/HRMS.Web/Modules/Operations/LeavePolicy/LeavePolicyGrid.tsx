import { EntityGrid } from '@serenity-is/corelib';
import { LeavePolicyColumns, LeavePolicyRow, LeavePolicyService } from '../../ServerTypes/Operations';
import { LeavePolicyDialog } from './LeavePolicyDialog';

export class LeavePolicyGrid extends EntityGrid<LeavePolicyRow> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.LeavePolicyGrid');

    protected override getColumnsKey() { return LeavePolicyColumns.columnsKey; }
    protected override getDialogType() { return LeavePolicyDialog; }
    protected override getRowDefinition() { return LeavePolicyRow; }
    protected override getService() { return LeavePolicyService.baseUrl; }
}
