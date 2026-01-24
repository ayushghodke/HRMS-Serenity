import { registerEnum } from "@serenity-is/corelib";

export enum AttendanceType {
    Present = 1,
    HalfDay = 2,
    Absent = 3,
    OnLeave = 4
}
registerEnum(AttendanceType, 'HRMS.Operations.AttendanceType');