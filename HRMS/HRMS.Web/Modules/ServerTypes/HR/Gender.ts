import { registerEnum } from "@serenity-is/corelib";

export enum Gender {
    Male = 1,
    Female = 2,
    Other = 3
}
registerEnum(Gender, 'HRMS.HR.Gender');