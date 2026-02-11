import { registerEnum } from "@serenity-is/corelib";

export enum SalaryComponentType {
    Earning = 1,
    Deduction = 2
}
registerEnum(SalaryComponentType, 'HRMS.Operations.SalaryComponentType');