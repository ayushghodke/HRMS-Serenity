import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { SalaryComponentsRow } from "./SalaryComponentsRow";
import { SalaryComponentType } from "./SalaryComponentType";

export interface SalaryComponentsColumns {
    ComponentId: Column<SalaryComponentsRow>;
    ComponentName: Column<SalaryComponentsRow>;
    ComponentType: Column<SalaryComponentsRow>;
    CalculationType: Column<SalaryComponentsRow>;
    PercentageOfComponentName: Column<SalaryComponentsRow>;
    IsStatutory: Column<SalaryComponentsRow>;
    IsTaxable: Column<SalaryComponentsRow>;
    IsActive: Column<SalaryComponentsRow>;
    DisplayOrder: Column<SalaryComponentsRow>;
}

export class SalaryComponentsColumns extends ColumnsBase<SalaryComponentsRow> {
    static readonly columnsKey = 'Operations.SalaryComponents';
    static readonly Fields = fieldsProxy<SalaryComponentsColumns>();
}

[SalaryComponentType]; // referenced types