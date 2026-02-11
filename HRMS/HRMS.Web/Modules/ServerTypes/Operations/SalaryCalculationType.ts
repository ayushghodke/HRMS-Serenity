import { registerEnum } from "@serenity-is/corelib";

export enum SalaryCalculationType {
    Fixed = 1,
    Percentage = 2,
    Formula = 3
}
registerEnum(SalaryCalculationType, 'HRMS.Operations.SalaryCalculationType');