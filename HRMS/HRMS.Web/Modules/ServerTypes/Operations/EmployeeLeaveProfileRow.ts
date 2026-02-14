import { fieldsProxy } from "@serenity-is/corelib";

export interface EmployeeLeaveProfileRow {
    EmployeeLeaveProfileId?: number;
    EmployeeId?: number;
    LeavePolicyId?: number;
    LeaveTypeId?: number;
    OpeningBalance?: number;
    AccruedLeave?: number;
    UsedLeave?: number;
    PendingLeave?: number;
    CarryForwardLeave?: number;
    LOPDays?: number;
    LastUpdatedDate?: string;
    EmployeeFullName?: string;
    DepartmentName?: string;
    DesignationName?: string;
    LeavePolicyName?: string;
    LeaveTypeName?: string;
}

export abstract class EmployeeLeaveProfileRow {
    static readonly idProperty = 'EmployeeLeaveProfileId';
    static readonly localTextPrefix = 'Operations.EmployeeLeaveProfile';
    static readonly deletePermission = 'Operations:Leave';
    static readonly insertPermission = 'Operations:Leave';
    static readonly readPermission = 'Operations:Leave';
    static readonly updatePermission = 'Operations:Leave';

    static readonly Fields = fieldsProxy<EmployeeLeaveProfileRow>();
}