import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";

export interface SalaryGradeRow {
    GradeId?: number;
    GradeName?: string;
    GradeCode?: string;
    MinSalary?: number;
    MaxSalary?: number;
    Description?: string;
    IsActive?: boolean;
}

export abstract class SalaryGradeRow {
    static readonly idProperty = 'GradeId';
    static readonly nameProperty = 'GradeName';
    static readonly localTextPrefix = 'Operations.SalaryGrade';
    static readonly lookupKey = 'Operations.SalaryGrade';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<SalaryGradeRow>('Operations.SalaryGrade') }
    static async getLookupAsync() { return getLookupAsync<SalaryGradeRow>('Operations.SalaryGrade') }

    static readonly deletePermission = 'Operations:Payroll';
    static readonly insertPermission = 'Operations:Payroll';
    static readonly readPermission = 'Operations:Payroll';
    static readonly updatePermission = 'Operations:Payroll';

    static readonly Fields = fieldsProxy<SalaryGradeRow>();
}