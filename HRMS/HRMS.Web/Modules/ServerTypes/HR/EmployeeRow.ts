import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { EmployeeDocsRow } from "./EmployeeDocsRow";
import { EmployeeStatus } from "./EmployeeStatus";
import { EmploymentType } from "./EmploymentType";
import { Gender } from "./Gender";

export interface EmployeeRow {
    EmployeeId?: number;
    UserId?: number;
    EmployeeCode?: string;
    FirstName?: string;
    LastName?: string;
    FullName?: string;
    Email?: string;
    Phone?: string;
    Gender?: Gender;
    DateOfBirth?: string;
    JoiningDate?: string;
    DepartmentId?: number;
    DesignationId?: number;
    ManagerId?: number;
    EmploymentType?: EmploymentType;
    Status?: EmployeeStatus;
    Username?: string;
    UserImage?: string;
    DepartmentName?: string;
    DesignationName?: string;
    ManagerFullName?: string;
    DocumentList?: EmployeeDocsRow[];
}

export abstract class EmployeeRow {
    static readonly idProperty = 'EmployeeId';
    static readonly nameProperty = 'FirstName';
    static readonly localTextPrefix = 'HR.Employee';
    static readonly lookupKey = 'HR.Employee';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<EmployeeRow>('HR.Employee') }
    static async getLookupAsync() { return getLookupAsync<EmployeeRow>('HR.Employee') }

    static readonly deletePermission = 'HR:Employee';
    static readonly insertPermission = 'HR:Employee';
    static readonly readPermission = 'HR:Employee';
    static readonly updatePermission = 'HR:Employee';

    static readonly Fields = fieldsProxy<EmployeeRow>();
}