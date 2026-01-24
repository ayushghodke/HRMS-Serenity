import { registerEnum } from "@serenity-is/corelib";

export enum LeaveStatus {
    Cancelled = -2,
    Rejected = -1,
    Pending = 0,
    Approved = 1
}
registerEnum(LeaveStatus, 'HRMS.Operations.LeaveStatus');