import { fieldsProxy } from "@serenity-is/corelib";
import { EmployeeSalaryDetailsRow } from "./EmployeeSalaryDetailsRow";

export interface EmployeeSalaryRow {
    EmployeeSalaryId?: number;
    EmployeeId?: number;
    GradeId?: number;
    EffectiveDate?: string;
    BasicSalary?: number;
    GrossSalary?: number;
    IsActive?: boolean;
    EmployeeName?: string;
    GradeName?: string;
    DetailList?: EmployeeSalaryDetailsRow[];
}

export abstract class EmployeeSalaryRow {
    static readonly idProperty = 'EmployeeSalaryId';
    static readonly localTextPrefix = 'HR.EmployeeSalary';
    static readonly deletePermission = 'HR:Employee:Modify';
    static readonly insertPermission = 'HR:Employee:Modify';
    static readonly readPermission = 'HR:Employee:View';
    static readonly updatePermission = 'HR:Employee:Modify';

    static readonly Fields = fieldsProxy<EmployeeSalaryRow>();
}