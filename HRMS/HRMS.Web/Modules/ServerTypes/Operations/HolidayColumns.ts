import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { HolidayRow } from "./HolidayRow";
import { HolidayType } from "./HolidayType";

export interface HolidayColumns {
    HolidayId: Column<HolidayRow>;
    HolidayName: Column<HolidayRow>;
    HolidayDate: Column<HolidayRow>;
    HolidayType: Column<HolidayRow>;
    Branch: Column<HolidayRow>;
    IsOptionalHoliday: Column<HolidayRow>;
    Year: Column<HolidayRow>;
}

export class HolidayColumns extends ColumnsBase<HolidayRow> {
    static readonly columnsKey = 'Operations.Holiday';
    static readonly Fields = fieldsProxy<HolidayColumns>();
}

[HolidayType]; // referenced types