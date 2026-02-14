import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { EmployeeLeaveProfileRow } from "./EmployeeLeaveProfileRow";

export interface EmployeeLeaveProfileColumns {
    EmployeeLeaveProfileId: Column<EmployeeLeaveProfileRow>;
    EmployeeFullName: Column<EmployeeLeaveProfileRow>;
    DepartmentName: Column<EmployeeLeaveProfileRow>;
    DesignationName: Column<EmployeeLeaveProfileRow>;
    LeavePolicyName: Column<EmployeeLeaveProfileRow>;
    LeaveTypeName: Column<EmployeeLeaveProfileRow>;
    OpeningBalance: Column<EmployeeLeaveProfileRow>;
    AccruedLeave: Column<EmployeeLeaveProfileRow>;
    UsedLeave: Column<EmployeeLeaveProfileRow>;
    PendingLeave: Column<EmployeeLeaveProfileRow>;
    CarryForwardLeave: Column<EmployeeLeaveProfileRow>;
    LOPDays: Column<EmployeeLeaveProfileRow>;
    LastUpdatedDate: Column<EmployeeLeaveProfileRow>;
}

export class EmployeeLeaveProfileColumns extends ColumnsBase<EmployeeLeaveProfileRow> {
    static readonly columnsKey = 'Operations.EmployeeLeaveProfile';
    static readonly Fields = fieldsProxy<EmployeeLeaveProfileColumns>();
}