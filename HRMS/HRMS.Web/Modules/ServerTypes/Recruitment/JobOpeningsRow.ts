import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { JobOpeningStatus } from "./JobOpeningStatus";

export interface JobOpeningsRow {
    JobId?: number;
    Title?: string;
    Description?: string;
    DepartmentId?: number;
    HiringManagerId?: number;
    Status?: JobOpeningStatus;
    CreatedDate?: string;
    DepartmentName?: string;
    HiringManagerName?: string;
}

export abstract class JobOpeningsRow {
    static readonly idProperty = 'JobId';
    static readonly nameProperty = 'Title';
    static readonly localTextPrefix = 'Recruitment.JobOpenings';
    static readonly lookupKey = 'Recruitment.JobOpenings';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<JobOpeningsRow>('Recruitment.JobOpenings') }
    static async getLookupAsync() { return getLookupAsync<JobOpeningsRow>('Recruitment.JobOpenings') }

    static readonly deletePermission = 'Administration:General';
    static readonly insertPermission = 'Administration:General';
    static readonly readPermission = 'Administration:General';
    static readonly updatePermission = 'Administration:General';

    static readonly Fields = fieldsProxy<JobOpeningsRow>();
}