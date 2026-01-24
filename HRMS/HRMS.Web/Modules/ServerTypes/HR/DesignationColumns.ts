import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { DesignationRow } from "./DesignationRow";

export interface DesignationColumns {
    DesignationId: Column<DesignationRow>;
    DesignationName: Column<DesignationRow>;
    Level: Column<DesignationRow>;
    IsActive: Column<DesignationRow>;
}

export class DesignationColumns extends ColumnsBase<DesignationRow> {
    static readonly columnsKey = 'HR.Designation';
    static readonly Fields = fieldsProxy<DesignationColumns>();
}