import { EntityGrid, confirm, notifySuccess, serviceCall } from '@serenity-is/corelib';
import { LeaveBalanceColumns, LeaveBalanceRow, LeaveBalanceService } from '../../ServerTypes/Operations';
import { LeaveBalanceDialog } from './LeaveBalanceDialog';

export class LeaveBalanceGrid extends EntityGrid<LeaveBalanceRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.LeaveBalanceGrid");

    protected override getColumnsKey() { return LeaveBalanceColumns.columnsKey; }
    protected override getDialogType() { return LeaveBalanceDialog; }
    protected override getRowDefinition() { return LeaveBalanceRow; }
    protected override getService() { return LeaveBalanceService.baseUrl; }

    protected override getButtons() {
        const buttons = super.getButtons();

        buttons.push({
            title: 'Recalculate Balances',
            cssClass: 'initialize-button',
            onClick: () => {
                confirm('This will recalculate used leaves for all employees based on their history. Continue?', () => {
                    serviceCall({
                        service: LeaveBalanceService.baseUrl + '/RecalculateAllBalances',
                        request: {},
                        onSuccess: () => {
                            notifySuccess('Employee balances recalculated successfully!');
                            this.refresh();
                        }
                    });
                });
            }
        });

        return buttons;
    }

    protected override getColumns() {
        const columns = super.getColumns();

        return columns;
    }
}
