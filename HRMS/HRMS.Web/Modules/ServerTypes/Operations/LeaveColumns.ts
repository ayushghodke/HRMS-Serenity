import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { HalfDaySession } from "./HalfDaySession";
import { LeaveRow } from "./LeaveRow";

export interface LeaveColumns {
    LeaveId: Column<LeaveRow>;
    LeaveApplicationNo: Column<LeaveRow>;
    ApplicationDate: Column<LeaveRow>;
    EmployeeFullName: Column<LeaveRow>;
    LeaveTypeName: Column<LeaveRow>;
    StartDate: Column<LeaveRow>;
    EndDate: Column<LeaveRow>;
    HalfDaySession: Column<LeaveRow>;
    TotalDays: Column<LeaveRow>;
    PaidDays: Column<LeaveRow>;
    UnpaidDays: Column<LeaveRow>;
    Reason: Column<LeaveRow>;
    Status: Column<LeaveRow>;
    HrApprovalStatus: Column<LeaveRow>;
    FinalStatus: Column<LeaveRow>;
    ReportingManagerName: Column<LeaveRow>;
    ApprovedByUsername: Column<LeaveRow>;
}

export class LeaveColumns extends ColumnsBase<LeaveRow> {
    static readonly columnsKey = 'Operations.Leave';
    static readonly Fields = fieldsProxy<LeaveColumns>();
}

[HalfDaySession]; // referenced types