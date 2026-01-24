import { EntityGrid } from '@serenity-is/corelib';
import { PayrollColumns, PayrollRow, PayrollService } from '../../ServerTypes/Operations';
import { PayrollDialog } from './PayrollDialog';

export class PayrollGrid extends EntityGrid<PayrollRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.PayrollGrid");

    protected override getColumnsKey() { return PayrollColumns.columnsKey; }
    protected override getDialogType() { return PayrollDialog; }
    protected override getRowDefinition() { return PayrollRow; }
    protected override getService() { return PayrollService.baseUrl; }
}
