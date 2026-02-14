import { registerEnum } from "@serenity-is/corelib";

export enum RecordStatus {
    Inactive = 0,
    Active = 1
}
registerEnum(RecordStatus, 'HRMS.Operations.RecordStatus');