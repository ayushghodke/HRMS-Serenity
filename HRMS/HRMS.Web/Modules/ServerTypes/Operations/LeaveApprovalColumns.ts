import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { LeaveApprovalRow } from "./LeaveApprovalRow";
import { LeaveStatus } from "./LeaveStatus";

export interface LeaveApprovalColumns {
    ApprovalId: Column<LeaveApprovalRow>;
    LeaveApplicationNo: Column<LeaveApprovalRow>;
    ApproverUsername: Column<LeaveApprovalRow>;
    ApprovalLevel: Column<LeaveApprovalRow>;
    ApprovalDate: Column<LeaveApprovalRow>;
    Status: Column<LeaveApprovalRow>;
    Remarks: Column<LeaveApprovalRow>;
}

export class LeaveApprovalColumns extends ColumnsBase<LeaveApprovalRow> {
    static readonly columnsKey = 'Operations.LeaveApproval';
    static readonly Fields = fieldsProxy<LeaveApprovalColumns>();
}

[LeaveStatus]; // referenced types