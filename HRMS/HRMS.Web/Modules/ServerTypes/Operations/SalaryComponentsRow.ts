import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { SalaryCalculationType } from "./SalaryCalculationType";
import { SalaryComponentType } from "./SalaryComponentType";

export interface SalaryComponentsRow {
    ComponentId?: number;
    ComponentName?: string;
    ComponentType?: SalaryComponentType;
    CalculationType?: SalaryCalculationType;
    PercentageOf?: number;
    IsStatutory?: boolean;
    IsTaxable?: boolean;
    IsActive?: boolean;
    DisplayOrder?: number;
    Description?: string;
    PercentageOfComponentName?: string;
}

export abstract class SalaryComponentsRow {
    static readonly idProperty = 'ComponentId';
    static readonly nameProperty = 'ComponentName';
    static readonly localTextPrefix = 'Operations.SalaryComponents';
    static readonly lookupKey = 'Operations.SalaryComponents';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<SalaryComponentsRow>('Operations.SalaryComponents') }
    static async getLookupAsync() { return getLookupAsync<SalaryComponentsRow>('Operations.SalaryComponents') }

    static readonly deletePermission = 'Operations:Payroll';
    static readonly insertPermission = 'Operations:Payroll';
    static readonly readPermission = 'Operations:Payroll';
    static readonly updatePermission = 'Operations:Payroll';

    static readonly Fields = fieldsProxy<SalaryComponentsRow>();
}