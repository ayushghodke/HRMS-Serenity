import { EntityGrid, resolveUrl } from '@serenity-is/corelib';
import { TaskColumns, TaskRow, TaskService } from '../../ServerTypes/Operations';
import { TaskDialog } from './TaskDialog';

export class TaskGrid extends EntityGrid<TaskRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.TaskGrid");

    protected override getColumnsKey() { return TaskColumns.columnsKey; }
    protected override getDialogType() { return TaskDialog; }
    protected override getRowDefinition() { return TaskRow; }
    protected override getService() { return TaskService.baseUrl; }

    protected override getButtons() {
        var buttons = super.getButtons();
        buttons.push({
            title: 'Kanban View',
            cssClass: 'btn-info',
            icon: 'fa-trello',
            onClick: () => {
                window.location.href = resolveUrl('~/Operations/TaskKanban');
            }
        });
        return buttons;
    }
}
