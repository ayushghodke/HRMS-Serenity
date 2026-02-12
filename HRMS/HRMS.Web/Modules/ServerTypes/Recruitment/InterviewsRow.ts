import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { InterviewRound } from "./InterviewRound";

export interface InterviewsRow {
    InterviewId?: number;
    CandidateId?: number;
    InterviewerId?: number;
    InterviewDate?: string;
    Round?: InterviewRound;
    Rating?: number;
    Comments?: string;
    IsCompleted?: boolean;
    CompletedOn?: string;
    CandidateName?: string;
    InterviewerName?: string;
}

export abstract class InterviewsRow {
    static readonly idProperty = 'InterviewId';
    static readonly localTextPrefix = 'Recruitment.Interviews';
    static readonly lookupKey = 'Recruitment.Interviews';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<InterviewsRow>('Recruitment.Interviews') }
    static async getLookupAsync() { return getLookupAsync<InterviewsRow>('Recruitment.Interviews') }

    static readonly deletePermission = 'Administration:General';
    static readonly insertPermission = 'Administration:General';
    static readonly readPermission = 'Administration:General';
    static readonly updatePermission = 'Administration:General';

    static readonly Fields = fieldsProxy<InterviewsRow>();
}