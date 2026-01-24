import { registerEnum } from "@serenity-is/corelib";

export enum CandidateStatus {
    Rejected = 0,
    Applied = 1,
    Shortlisted = 2,
    Interviewed = 3,
    Offered = 4,
    Hired = 5
}
registerEnum(CandidateStatus, 'HRMS.Recruitment.CandidateStatus');