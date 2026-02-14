import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { LeaveCategory } from "./LeaveCategory";
import { RecordStatus } from "./RecordStatus";

export interface LeaveTypeRow {
    LeaveTypeId?: number;
    LeaveTypeName?: string;
    LeaveCode?: string;
    LeaveCategory?: LeaveCategory;
    AnnualAllocation?: number;
    MonthlyAccrual?: boolean;
    CarryForwardAllowed?: boolean;
    MaxCarryForwardDays?: number;
    EncashmentAllowed?: boolean;
    ApplicableDepartments?: string;
    ApplicableDesignations?: string;
    ApplicableBranches?: string;
    GenderSpecific?: boolean;
    ProbationApplicable?: boolean;
    MinimumServiceRequiredMonths?: number;
    MaxLeavePerRequest?: number;
    SandwichRuleApplicable?: boolean;
    HalfDayAllowed?: boolean;
    DocumentsRequired?: boolean;
    Status?: RecordStatus;
}

export abstract class LeaveTypeRow {
    static readonly idProperty = 'LeaveTypeId';
    static readonly nameProperty = 'LeaveTypeName';
    static readonly localTextPrefix = 'Operations.LeaveType';
    static readonly lookupKey = 'Operations.LeaveType';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<LeaveTypeRow>('Operations.LeaveType') }
    static async getLookupAsync() { return getLookupAsync<LeaveTypeRow>('Operations.LeaveType') }

    static readonly deletePermission = 'Operations:Leave';
    static readonly insertPermission = 'Operations:Leave';
    static readonly readPermission = 'Operations:Leave';
    static readonly updatePermission = 'Operations:Leave';

    static readonly Fields = fieldsProxy<LeaveTypeRow>();
}