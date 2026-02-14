import { registerEnum } from "@serenity-is/corelib";

export enum LeaveCategory {
    Paid = 1,
    Unpaid = 2
}
registerEnum(LeaveCategory, 'HRMS.Operations.LeaveCategory');