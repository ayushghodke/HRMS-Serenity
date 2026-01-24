import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { AttendanceRow } from "./AttendanceRow";
import { AttendanceType } from "./AttendanceType";

export interface AttendanceColumns {
    Id: Column<AttendanceRow>;
    UserId: Column<AttendanceRow>;
    NameUsername: Column<AttendanceRow>;
    DateNTime: Column<AttendanceRow>;
    Type: Column<AttendanceRow>;
    Coordinates: Column<AttendanceRow>;
    PunchOutCoordinates: Column<AttendanceRow>;
    Location: Column<AttendanceRow>;
    ApprovedByUsername: Column<AttendanceRow>;
    PunchIn: Column<AttendanceRow>;
    PunchOut: Column<AttendanceRow>;
    Distance: Column<AttendanceRow>;
}

export class AttendanceColumns extends ColumnsBase<AttendanceRow> {
    static readonly columnsKey = 'Operations.Attendance';
    static readonly Fields = fieldsProxy<AttendanceColumns>();
}

[AttendanceType]; // referenced types