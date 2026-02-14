import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { EmployeeRow } from "./EmployeeRow";
import { EmployeeStatus } from "./EmployeeStatus";

export interface EmployeeColumns {
    EmployeeId: Column<EmployeeRow>;
    EmployeeCode: Column<EmployeeRow>;
    FullName: Column<EmployeeRow>;
    Email: Column<EmployeeRow>;
    Phone: Column<EmployeeRow>;
    PaidLeavesPerMonth: Column<EmployeeRow>;
    DepartmentName: Column<EmployeeRow>;
    DesignationName: Column<EmployeeRow>;
    Status: Column<EmployeeRow>;
}

export class EmployeeColumns extends ColumnsBase<EmployeeRow> {
    static readonly columnsKey = 'HR.Employee';
    static readonly Fields = fieldsProxy<EmployeeColumns>();
}

[EmployeeStatus]; // referenced types