import { EntityGrid, Decorators, ToolButton, confirmDialog, notifySuccess, notifyError, resolveUrl, serviceCall } from '@serenity-is/corelib';
import { LeaveColumns, LeaveRow, LeaveService, LeaveStatus } from '../../ServerTypes/Operations';
import { LeaveDialog } from './LeaveDialog';
import { Column, FormatterContext } from '@serenity-is/sleekgrid';

@Decorators.registerClass("HRMS.Operations.LeaveGrid")
export class LeaveGrid extends EntityGrid<LeaveRow> {
    protected override getColumnsKey() { return LeaveColumns.columnsKey; }
    protected override getDialogType() { return LeaveDialog; }
    protected override getRowDefinition() { return LeaveRow; }
    protected override getService() { return LeaveService.baseUrl; }

    protected override getButtons(): ToolButton[] {
        const buttons = super.getButtons();

        buttons.push({
            title: 'Kanban View',
            cssClass: 'btn-info',
            icon: 'fa-trello',
            onClick: () => {
                window.location.href = resolveUrl('~/Operations/LeaveKanban');
            }
        });

        buttons.push({
            title: 'Dashboard',
            cssClass: 'btn-primary',
            icon: 'fa-area-chart',
            onClick: () => {
                window.location.href = resolveUrl('~/Operations/LeaveDashboard');
            }
        });

        buttons.push({
            title: 'Reports',
            cssClass: 'btn-default',
            icon: 'fa-file-text-o',
            onClick: () => {
                window.location.href = resolveUrl('~/Operations/LeaveReports');
            }
        });

        return buttons;
    }

    protected override getColumns(): Column[] {
        let columns = super.getColumns();

        // Add Actions column at the end
        columns.push({
            field: 'Actions',
            name: 'Actions',
            width: 150,
            format: (ctx: FormatterContext) => {
                const item = ctx.item as LeaveRow;
                if (item.Status === LeaveStatus.Pending) {
                    return `<a class="inline-action approve-btn" title="Approve"><i class="fa fa-check text-success"></i> Approve</a>
                            <a class="inline-action reject-btn" title="Reject"><i class="fa fa-times text-danger"></i> Reject</a>`;
                }
                return '';
            }
        });

        return columns;
    }

    protected override onClick(e: Event, row: number, cell: number): void {
        super.onClick(e, row, cell);

        const target = e.target as HTMLElement;
        const item = this.itemAt(row);

        if (target.closest('.approve-btn')) {
            e.preventDefault();
            this.approveLeave(item.LeaveId);
        }
        else if (target.closest('.reject-btn')) {
            e.preventDefault();
            this.rejectLeave(item.LeaveId);
        }
    }

    private approveLeave(leaveId: number): void {
        confirmDialog('Are you sure you want to approve this leave request?', () => {
            serviceCall({
                url: LeaveService.baseUrl + '/Approve',
                request: leaveId,
                onSuccess: () => {
                    notifySuccess('Leave approved successfully.');
                    this.refresh();
                },
                onError: (response) => {
                    notifyError(response?.Error?.Message || 'Failed to approve leave.');
                }
            });
        });
    }

    private rejectLeave(leaveId: number): void {
        confirmDialog('Are you sure you want to reject this leave request?', () => {
            serviceCall({
                url: LeaveService.baseUrl + '/Reject',
                request: leaveId,
                onSuccess: () => {
                    notifySuccess('Leave rejected successfully.');
                    this.refresh();
                },
                onError: (response) => {
                    notifyError(response?.Error?.Message || 'Failed to reject leave.');
                }
            });
        });
    }
}
