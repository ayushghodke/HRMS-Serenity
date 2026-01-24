import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";

export interface DesignationRow {
    DesignationId?: number;
    DesignationName?: string;
    Level?: number;
    IsActive?: boolean;
}

export abstract class DesignationRow {
    static readonly idProperty = 'DesignationId';
    static readonly nameProperty = 'DesignationName';
    static readonly localTextPrefix = 'HR.Designation';
    static readonly lookupKey = 'HR.Designation';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<DesignationRow>('HR.Designation') }
    static async getLookupAsync() { return getLookupAsync<DesignationRow>('HR.Designation') }

    static readonly deletePermission = 'HR:Designation';
    static readonly insertPermission = 'HR:Designation';
    static readonly readPermission = 'HR:Designation';
    static readonly updatePermission = 'HR:Designation';

    static readonly Fields = fieldsProxy<DesignationRow>();
}