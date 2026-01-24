import { registerEnum } from "@serenity-is/corelib";

export enum TaskStatus {
    Cancelled = -1,
    Open = 0,
    In_Progress = 1,
    Completed = 2,
    On_Hold = 3
}
registerEnum(TaskStatus, 'HRMS.Operations.TaskStatus');