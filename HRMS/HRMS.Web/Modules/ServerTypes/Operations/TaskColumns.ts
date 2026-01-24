import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { TaskRow } from "./TaskRow";
import { TaskStatus } from "./TaskStatus";

export interface TaskColumns {
    TaskId: Column<TaskRow>;
    Title: Column<TaskRow>;
    AssignedToFullName: Column<TaskRow>;
    AssignedByUsername: Column<TaskRow>;
    DueDate: Column<TaskRow>;
    Status: Column<TaskRow>;
}

export class TaskColumns extends ColumnsBase<TaskRow> {
    static readonly columnsKey = 'Operations.Task';
    static readonly Fields = fieldsProxy<TaskColumns>();
}

[TaskStatus]; // referenced types