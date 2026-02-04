import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { LeaveType } from "./LeaveType";

export interface LeaveBalanceRow {
    LeaveBalanceId?: number;
    EmployeeId?: number;
    LeaveType?: LeaveType;
    Year?: number;
    Allocated?: number;
    Used?: number;
    Balance?: number;
    EmployeeFullName?: string;
    EmployeeJoinDate?: string;
    MonthsWorked?: number;
    AccruedLeaves?: number;
    RemainingLeaves?: number;
    LeavesThisMonth?: number;
    LeavesPreviousMonths?: number;
}

export abstract class LeaveBalanceRow {
    static readonly idProperty = 'LeaveBalanceId';
    static readonly localTextPrefix = 'Operations.LeaveBalance';
    static readonly lookupKey = 'Operations.LeaveBalance';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<LeaveBalanceRow>('Operations.LeaveBalance') }
    static async getLookupAsync() { return getLookupAsync<LeaveBalanceRow>('Operations.LeaveBalance') }

    static readonly deletePermission = 'Operations:Leave';
    static readonly insertPermission = 'Operations:Leave';
    static readonly readPermission = 'Operations:Leave';
    static readonly updatePermission = 'Operations:Leave';

    static readonly Fields = fieldsProxy<LeaveBalanceRow>();
}