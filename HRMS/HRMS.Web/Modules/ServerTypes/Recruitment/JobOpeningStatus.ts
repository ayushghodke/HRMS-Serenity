import { registerEnum } from "@serenity-is/corelib";

export enum JobOpeningStatus {
    Draft = 0,
    Open = 1,
    Closed = 2,
    OnHold = 3
}
registerEnum(JobOpeningStatus, 'HRMS.Recruitment.JobOpeningStatus');