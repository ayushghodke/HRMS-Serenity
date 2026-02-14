import { fieldsProxy } from "@serenity-is/corelib";
import { LeaveStatus } from "./LeaveStatus";

export interface LeaveApprovalRow {
    ApprovalId?: number;
    LeaveId?: number;
    ApproverId?: number;
    ApprovalLevel?: number;
    ApprovalDate?: string;
    Status?: LeaveStatus;
    Remarks?: string;
    EscalationTrigger?: boolean;
    EscalationTo?: number;
    TimeStamp?: string;
    LeaveApplicationNo?: string;
    ApproverUsername?: string;
    EscalationToUsername?: string;
}

export abstract class LeaveApprovalRow {
    static readonly idProperty = 'ApprovalId';
    static readonly localTextPrefix = 'Operations.LeaveApproval';
    static readonly deletePermission = 'Operations:Leave';
    static readonly insertPermission = 'Operations:Leave';
    static readonly readPermission = 'Operations:Leave';
    static readonly updatePermission = 'Operations:Leave';

    static readonly Fields = fieldsProxy<LeaveApprovalRow>();
}