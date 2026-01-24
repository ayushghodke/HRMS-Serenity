import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { LeaveRow } from "./LeaveRow";
import { LeaveType } from "./LeaveType";

export interface LeaveColumns {
    LeaveId: Column<LeaveRow>;
    EmployeeFullName: Column<LeaveRow>;
    LeaveType: Column<LeaveRow>;
    StartDate: Column<LeaveRow>;
    EndDate: Column<LeaveRow>;
    TotalDays: Column<LeaveRow>;
    Reason: Column<LeaveRow>;
    Status: Column<LeaveRow>;
    ApprovedByUsername: Column<LeaveRow>;
}

export class LeaveColumns extends ColumnsBase<LeaveRow> {
    static readonly columnsKey = 'Operations.Leave';
    static readonly Fields = fieldsProxy<LeaveColumns>();
}

[LeaveType]; // referenced types