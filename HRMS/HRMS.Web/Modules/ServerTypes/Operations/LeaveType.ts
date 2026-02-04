import { registerEnum } from "@serenity-is/corelib";

export enum LeaveType {
    PaidLeave = 1,
    Unpaid = 2
}
registerEnum(LeaveType, 'HRMS.Operations.LeaveType');