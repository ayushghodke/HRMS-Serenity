import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { EmployeeSalaryRow } from "./EmployeeSalaryRow";

export interface EmployeeSalaryColumns {
    EmployeeSalaryId: Column<EmployeeSalaryRow>;
    EmployeeName: Column<EmployeeSalaryRow>;
    GradeName: Column<EmployeeSalaryRow>;
    EffectiveDate: Column<EmployeeSalaryRow>;
    BasicSalary: Column<EmployeeSalaryRow>;
    GrossSalary: Column<EmployeeSalaryRow>;
    IsActive: Column<EmployeeSalaryRow>;
}

export class EmployeeSalaryColumns extends ColumnsBase<EmployeeSalaryRow> {
    static readonly columnsKey = 'HR.EmployeeSalary';
    static readonly Fields = fieldsProxy<EmployeeSalaryColumns>();
}