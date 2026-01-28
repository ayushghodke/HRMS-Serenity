import { CandidateStatus } from "./CandidateStatus";

export interface UpdateStatusRequest {
    CandidateId?: number;
    NewStatus?: CandidateStatus;
}