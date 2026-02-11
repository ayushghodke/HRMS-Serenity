import { registerEnum } from "@serenity-is/corelib";

export enum NoticePriority {
    Low = 1,
    Normal = 2,
    High = 3
}
registerEnum(NoticePriority, 'HRMS.Communication.NoticePriority');