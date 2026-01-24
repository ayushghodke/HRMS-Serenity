import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { Month } from "./Month";
import { PayrollRow } from "./PayrollRow";

export interface PayrollColumns {
    PayrollId: Column<PayrollRow>;
    EmployeeFullName: Column<PayrollRow>;
    Month: Column<PayrollRow>;
    Year: Column<PayrollRow>;
    BasicSalary: Column<PayrollRow>;
    Allowances: Column<PayrollRow>;
    Deductions: Column<PayrollRow>;
    NetSalary: Column<PayrollRow>;
    GeneratedDate: Column<PayrollRow>;
}

export class PayrollColumns extends ColumnsBase<PayrollRow> {
    static readonly columnsKey = 'Operations.Payroll';
    static readonly Fields = fieldsProxy<PayrollColumns>();
}

[Month]; // referenced types