import { registerEnum } from "@serenity-is/corelib";

export enum LeaveType {
    Casual = 1,
    Sick = 2,
    Earned = 3,
    Unpaid = 4
}
registerEnum(LeaveType, 'HRMS.Operations.LeaveType');