import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { LeaveBalanceRow } from "./LeaveBalanceRow";
import { LeaveType } from "./LeaveType";

export interface LeaveBalanceColumns {
    LeaveBalanceId: Column<LeaveBalanceRow>;
    EmployeeFullName: Column<LeaveBalanceRow>;
    LeaveType: Column<LeaveBalanceRow>;
    Year: Column<LeaveBalanceRow>;
    Allocated: Column<LeaveBalanceRow>;
    Used: Column<LeaveBalanceRow>;
    Balance: Column<LeaveBalanceRow>;
}

export class LeaveBalanceColumns extends ColumnsBase<LeaveBalanceRow> {
    static readonly columnsKey = 'Operations.LeaveBalance';
    static readonly Fields = fieldsProxy<LeaveBalanceColumns>();
}

[LeaveType]; // referenced types