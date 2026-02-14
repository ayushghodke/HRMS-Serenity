import { registerEnum } from "@serenity-is/corelib";

export enum HrApprovalStatus {
    Rejected = -1,
    Pending = 0,
    Approved = 1
}
registerEnum(HrApprovalStatus, 'HRMS.Operations.HrApprovalStatus');