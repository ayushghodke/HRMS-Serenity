import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { HolidayType } from "./HolidayType";

export interface HolidayRow {
    HolidayId?: number;
    HolidayName?: string;
    HolidayDate?: string;
    HolidayType?: HolidayType;
    Branch?: string;
    ApplicableDepartments?: string;
    IsOptionalHoliday?: boolean;
    Year?: number;
}

export abstract class HolidayRow {
    static readonly idProperty = 'HolidayId';
    static readonly nameProperty = 'HolidayName';
    static readonly localTextPrefix = 'Operations.Holiday';
    static readonly lookupKey = 'Operations.Holiday';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<HolidayRow>('Operations.Holiday') }
    static async getLookupAsync() { return getLookupAsync<HolidayRow>('Operations.Holiday') }

    static readonly deletePermission = 'Operations:Leave';
    static readonly insertPermission = 'Operations:Leave';
    static readonly readPermission = 'Operations:Leave';
    static readonly updatePermission = 'Operations:Leave';

    static readonly Fields = fieldsProxy<HolidayRow>();
}