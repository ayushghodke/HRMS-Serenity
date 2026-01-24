import { registerEnum } from "@serenity-is/corelib";

export enum EmploymentType {
    FullTime = 1,
    PartTime = 2,
    Contract = 3,
    Intern = 4
}
registerEnum(EmploymentType, 'HRMS.HR.EmploymentType');