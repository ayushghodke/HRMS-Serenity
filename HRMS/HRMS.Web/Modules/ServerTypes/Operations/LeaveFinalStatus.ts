import { registerEnum } from "@serenity-is/corelib";

export enum LeaveFinalStatus {
    Cancelled = -2,
    Rejected = -1,
    Pending = 0,
    ManagerApproved = 1,
    Approved = 2
}
registerEnum(LeaveFinalStatus, 'HRMS.Operations.LeaveFinalStatus');