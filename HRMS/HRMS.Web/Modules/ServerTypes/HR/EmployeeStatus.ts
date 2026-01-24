import { registerEnum } from "@serenity-is/corelib";

export enum EmployeeStatus {
    Terminated = -1,
    Inactive = 0,
    Active = 1
}
registerEnum(EmployeeStatus, 'HRMS.HR.EmployeeStatus');