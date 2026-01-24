import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { DepartmentRow } from "./DepartmentRow";

export interface DepartmentColumns {
    DepartmentId: Column<DepartmentRow>;
    DepartmentName: Column<DepartmentRow>;
    Description: Column<DepartmentRow>;
    IsActive: Column<DepartmentRow>;
}

export class DepartmentColumns extends ColumnsBase<DepartmentRow> {
    static readonly columnsKey = 'HR.Department';
    static readonly Fields = fieldsProxy<DepartmentColumns>();
}