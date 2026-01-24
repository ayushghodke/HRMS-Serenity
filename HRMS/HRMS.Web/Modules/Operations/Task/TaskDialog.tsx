import { EntityDialog } from '@serenity-is/corelib';
import { TaskForm, TaskRow, TaskService } from '../../ServerTypes/Operations';

export class TaskDialog extends EntityDialog<TaskRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.TaskDialog");

    protected override getFormKey() { return TaskForm.formKey; }
    protected override getRowDefinition() { return TaskRow; }
    protected override getService() { return TaskService.baseUrl; }

    protected form = new TaskForm(this.idPrefix);
}
