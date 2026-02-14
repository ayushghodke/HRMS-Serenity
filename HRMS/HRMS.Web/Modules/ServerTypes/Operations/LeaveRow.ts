import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { HalfDaySession } from "./HalfDaySession";
import { HrApprovalStatus } from "./HrApprovalStatus";
import { LeaveFinalStatus } from "./LeaveFinalStatus";
import { LeaveStatus } from "./LeaveStatus";
import { LeaveType } from "./LeaveType";

export interface LeaveRow {
    LeaveId?: number;
    EmployeeId?: number;
    LeaveType?: LeaveType;
    LeaveTypeId?: number;
    LeaveApplicationNo?: string;
    ApplicationDate?: string;
    StartDate?: string;
    EndDate?: string;
    HalfDaySession?: HalfDaySession;
    TotalDays?: number;
    PaidDays?: number;
    UnpaidDays?: number;
    Reason?: string;
    Attachment?: string;
    ReportingManagerId?: number;
    Status?: LeaveStatus;
    HrApprovalStatus?: HrApprovalStatus;
    FinalStatus?: LeaveFinalStatus;
    ManagerRemarks?: string;
    HrRemarks?: string;
    SubstituteEmployeeId?: number;
    ContactDuringLeave?: string;
    CreatedByUserId?: number;
    ApprovedBy?: number;
    CreatedDate?: string;
    ApprovedDate?: string;
    EmployeeFullName?: string;
    ApprovedByUsername?: string;
    LeaveTypeName?: string;
    ReportingManagerName?: string;
    SubstituteEmployeeName?: string;
    CreatedByUsername?: string;
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