import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { DocumentKind } from "./DocumentKind";
import { EmployeeDocsRow } from "./EmployeeDocsRow";

export interface EmployeeDocsColumns {
    DocumentType: Column<EmployeeDocsRow>;
    Title: Column<EmployeeDocsRow>;
    Description: Column<EmployeeDocsRow>;
    UploadedOn: Column<EmployeeDocsRow>;
    FilePath: Column<EmployeeDocsRow>;
}

export class EmployeeDocsColumns extends ColumnsBase<EmployeeDocsRow> {
    static readonly columnsKey = 'HR.EmployeeDocs';
    static readonly Fields = fieldsProxy<EmployeeDocsColumns>();
}

[DocumentKind]; // referenced types