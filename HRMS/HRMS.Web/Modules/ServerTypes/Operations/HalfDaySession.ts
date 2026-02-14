import { registerEnum } from "@serenity-is/corelib";

export enum HalfDaySession {
    FirstHalf = 1,
    SecondHalf = 2
}
registerEnum(HalfDaySession, 'HRMS.Operations.HalfDaySession');