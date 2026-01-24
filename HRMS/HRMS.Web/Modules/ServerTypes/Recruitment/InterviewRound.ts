import { registerEnum } from "@serenity-is/corelib";

export enum InterviewRound {
    Technical = 1,
    HR = 2,
    Management = 3,
    Final = 4
}
registerEnum(InterviewRound, 'HRMS.Recruitment.InterviewRound');