import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { ApprovalLevelMode } from "./ApprovalLevelMode";
import { RecordStatus } from "./RecordStatus";

export interface LeavePolicyRow {
    LeavePolicyId?: number;
    PolicyName?: string;
    ApplicableFromDate?: string;
    Branch?: string;
    DepartmentId?: number;
    MaxConsecutiveLeavesAllowed?: number;
    NoticePeriodLeaveAllowed?: boolean;
    ProbationLeaveAllowed?: boolean;
    ApprovalLevels?: ApprovalLevelMode;
    HROverridePermission?: boolean;
    PayrollCutoffDay?: number;
    Status?: RecordStatus;
    DepartmentName?: string;
}

export abstract class LeavePolicyRow {
    static readonly idProperty = 'LeavePolicyId';
    static readonly nameProperty = 'PolicyName';
    static readonly localTextPrefix = 'Operations.LeavePolicy';
    static readonly lookupKey = 'Operations.LeavePolicy';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<LeavePolicyRow>('Operations.LeavePolicy') }
    static async getLookupAsync() { return getLookupAsync<LeavePolicyRow>('Operations.LeavePolicy') }

    static readonly deletePermission = 'Operations:Leave';
    static readonly insertPermission = 'Operations:Leave';
    static readonly readPermission = 'Operations:Leave';
    static readonly updatePermission = 'Operations:Leave';

    static readonly Fields = fieldsProxy<LeavePolicyRow>();
}