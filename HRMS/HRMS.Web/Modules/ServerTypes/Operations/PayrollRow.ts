import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { Month } from "./Month";

export interface PayrollRow {
    PayrollId?: number;
    EmployeeId?: number;
    Month?: Month;
    Year?: number;
    BasicSalary?: number;
    Allowances?: number;
    Deductions?: number;
    NetSalary?: number;
    GeneratedDate?: string;
    EmployeeFullName?: string;
}

export abstract class PayrollRow {
    static readonly idProperty = 'PayrollId';
    static readonly nameProperty = 'EmployeeFullName';
    static readonly localTextPrefix = 'Operations.Payroll';
    static readonly lookupKey = 'Operations.Payroll';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<PayrollRow>('Operations.Payroll') }
    static async getLookupAsync() { return getLookupAsync<PayrollRow>('Operations.Payroll') }

    static readonly deletePermission = 'Operations:Payroll';
    static readonly insertPermission = 'Operations:Payroll';
    static readonly readPermission = 'Operations:Payroll';
    static readonly updatePermission = 'Operations:Payroll';

    static readonly Fields = fieldsProxy<PayrollRow>();
}