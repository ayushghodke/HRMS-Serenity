import { fieldsProxy } from "@serenity-is/corelib";

export interface EmployeeSalaryDetailsRow {
    DetailId?: number;
    EmployeeSalaryId?: number;
    ComponentId?: number;
    Amount?: number;
    IsActive?: boolean;
    ComponentName?: string;
    ComponentType?: number;
}

export abstract class EmployeeSalaryDetailsRow {
    static readonly idProperty = 'DetailId';
    static readonly nameProperty = 'ComponentName';
    static readonly localTextPrefix = 'HR.EmployeeSalaryDetails';
    static readonly deletePermission = 'HR:Employee:Modify';
    static readonly insertPermission = 'HR:Employee:Modify';
    static readonly readPermission = 'HR:Employee:View';
    static readonly updatePermission = 'HR:Employee:Modify';

    static readonly Fields = fieldsProxy<EmployeeSalaryDetailsRow>();
}