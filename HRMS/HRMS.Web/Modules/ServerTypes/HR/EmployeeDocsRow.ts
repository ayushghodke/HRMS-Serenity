import { fieldsProxy } from "@serenity-is/corelib";
import { DocumentKind } from "./DocumentKind";

export interface EmployeeDocsRow {
    DocumentId?: number;
    EmployeeId?: number;
    DocumentType?: DocumentKind;
    Title?: string;
    Description?: string;
    FilePath?: string;
    UploadedOn?: string;
    EmployeeFirstName?: string;
}

export abstract class EmployeeDocsRow {
    static readonly idProperty = 'DocumentId';
    static readonly localTextPrefix = 'HR.EmployeeDocs';
    static readonly deletePermission = 'Administration:General';
    static readonly insertPermission = 'Administration:General';
    static readonly readPermission = 'Administration:General';
    static readonly updatePermission = 'Administration:General';

    static readonly Fields = fieldsProxy<EmployeeDocsRow>();
}