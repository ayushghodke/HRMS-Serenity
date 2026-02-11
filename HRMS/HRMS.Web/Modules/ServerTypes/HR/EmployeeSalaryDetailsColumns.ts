import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { EmployeeSalaryDetailsRow } from "./EmployeeSalaryDetailsRow";

export interface EmployeeSalaryDetailsColumns {
    ComponentName: Column<EmployeeSalaryDetailsRow>;
    Amount: Column<EmployeeSalaryDetailsRow>;
    ComponentType: Column<EmployeeSalaryDetailsRow>;
}

export class EmployeeSalaryDetailsColumns extends ColumnsBase<EmployeeSalaryDetailsRow> {
    static readonly columnsKey = 'HR.EmployeeSalaryDetails';
    static readonly Fields = fieldsProxy<EmployeeSalaryDetailsColumns>();
}