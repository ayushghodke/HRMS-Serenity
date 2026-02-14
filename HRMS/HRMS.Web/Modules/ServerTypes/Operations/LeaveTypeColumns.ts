import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { LeaveCategory } from "./LeaveCategory";
import { LeaveTypeRow } from "./LeaveTypeRow";

export interface LeaveTypeColumns {
    LeaveTypeId: Column<LeaveTypeRow>;
    LeaveTypeName: Column<LeaveTypeRow>;
    LeaveCode: Column<LeaveTypeRow>;
    LeaveCategory: Column<LeaveTypeRow>;
    AnnualAllocation: Column<LeaveTypeRow>;
    MonthlyAccrual: Column<LeaveTypeRow>;
    CarryForwardAllowed: Column<LeaveTypeRow>;
    SandwichRuleApplicable: Column<LeaveTypeRow>;
    HalfDayAllowed: Column<LeaveTypeRow>;
    Status: Column<LeaveTypeRow>;
}

export class LeaveTypeColumns extends ColumnsBase<LeaveTypeRow> {
    static readonly columnsKey = 'Operations.LeaveType';
    static readonly Fields = fieldsProxy<LeaveTypeColumns>();
}

[LeaveCategory]; // referenced types