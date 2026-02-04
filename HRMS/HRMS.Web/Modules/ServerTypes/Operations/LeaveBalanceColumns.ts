import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { LeaveBalanceRow } from "./LeaveBalanceRow";

export interface LeaveBalanceColumns {
    EmployeeFullName: Column<LeaveBalanceRow>;
    EmployeeJoinDate: Column<LeaveBalanceRow>;
    MonthsWorked: Column<LeaveBalanceRow>;
    AccruedLeaves: Column<LeaveBalanceRow>;
    LeavesThisMonth: Column<LeaveBalanceRow>;
    LeavesPreviousMonths: Column<LeaveBalanceRow>;
}

export class LeaveBalanceColumns extends ColumnsBase<LeaveBalanceRow> {
    static readonly columnsKey = 'Operations.LeaveBalance';
    static readonly Fields = fieldsProxy<LeaveBalanceColumns>();
}