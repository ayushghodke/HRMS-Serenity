import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { CandidateStatus } from "./CandidateStatus";

export interface CandidatesRow {
    CandidateId?: number;
    JobId?: number;
    FirstName?: string;
    LastName?: string;
    Email?: string;
    Mobile?: string;
    ResumePath?: string;
    Status?: CandidateStatus;
    AppliedDate?: string;
    JobTitle?: string;
}

export abstract class CandidatesRow {
    static readonly idProperty = 'CandidateId';
    static readonly nameProperty = 'FirstName';
    static readonly localTextPrefix = 'Recruitment.Candidates';
    static readonly lookupKey = 'Recruitment.Candidates';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<CandidatesRow>('Recruitment.Candidates') }
    static async getLookupAsync() { return getLookupAsync<CandidatesRow>('Recruitment.Candidates') }

    static readonly deletePermission = 'Administration:General';
    static readonly insertPermission = 'Administration:General';
    static readonly readPermission = 'Administration:General';
    static readonly updatePermission = 'Administration:General';

    static readonly Fields = fieldsProxy<CandidatesRow>();
}