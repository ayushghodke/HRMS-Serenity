import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";

export interface DepartmentRow {
    DepartmentId?: number;
    DepartmentName?: string;
    Description?: string;
    IsActive?: boolean;
}

export abstract class DepartmentRow {
    static readonly idProperty = 'DepartmentId';
    static readonly nameProperty = 'DepartmentName';
    static readonly localTextPrefix = 'HR.Department';
    static readonly lookupKey = 'HR.Department';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<DepartmentRow>('HR.Department') }
    static async getLookupAsync() { return getLookupAsync<DepartmentRow>('HR.Department') }

    static readonly deletePermission = 'HR:Department';
    static readonly insertPermission = 'HR:Department';
    static readonly readPermission = 'HR:Department';
    static readonly updatePermission = 'HR:Department';

    static readonly Fields = fieldsProxy<DepartmentRow>();
}