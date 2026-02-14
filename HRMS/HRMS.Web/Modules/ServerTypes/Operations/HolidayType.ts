import { registerEnum } from "@serenity-is/corelib";

export enum HolidayType {
    National = 1,
    Festival = 2,
    CompanyHoliday = 3
}
registerEnum(HolidayType, 'HRMS.Operations.HolidayType');