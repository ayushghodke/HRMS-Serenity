import { registerEnum } from "@serenity-is/corelib";

export enum InterviewStatus {
    Cancelled = -1,
    Scheduled = 1,
    Interviewed = 2
}
registerEnum(InterviewStatus, 'HRMS.Recruitment.InterviewStatus');