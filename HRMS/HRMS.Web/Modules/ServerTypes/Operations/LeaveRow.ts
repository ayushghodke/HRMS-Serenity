import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { LeaveStatus } from "./LeaveStatus";
import { LeaveType } from "./LeaveType";

export interface LeaveRow {
    LeaveId?: number;
    EmployeeId?: number;
    LeaveType?: LeaveType;
    StartDate?: string;
    EndDate?: string;
    TotalDays?: number;
    Reason?: string;
    Status?: LeaveStatus;
    ApprovedBy?: number;
    CreatedDate?: string;
    EmployeeFullName?: string;
    ApprovedByUsername?: string;
}

export abstract class LeaveRow {
    static readonly idProperty = 'LeaveId';
    static readonly nameProperty = 'Reason';
    static readonly localTextPrefix = 'Operations.Leave';
    static readonly lookupKey = 'Operations.Leave';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<LeaveRow>('Operations.Leave') }
    static async getLookupAsync() { return getLookupAsync<LeaveRow>('Operations.Leave') }

    static readonly deletePermission = 'Operations:Leave';
    static readonly insertPermission = 'Operations:Leave';
    static readonly readPermission = 'Operations:Leave';
    static readonly updatePermission = 'Operations:Leave';

    static readonly Fields = fieldsProxy<LeaveRow>();
}