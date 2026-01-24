import { fieldsProxy } from "@serenity-is/corelib";
import { AttendanceType } from "./AttendanceType";

export interface AttendanceRow {
    Id?: number;
    UserId?: string;
    Name?: number;
    DateNTime?: string;
    Type?: AttendanceType;
    Coordinates?: string;
    PunchOutCoordinates?: string;
    Location?: string;
    ApprovedBy?: number;
    PunchIn?: string;
    PunchOut?: string;
    Distance?: number;
    NameUsername?: string;
    ApprovedByUsername?: string;
}

export abstract class AttendanceRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'UserId';
    static readonly localTextPrefix = 'Operations.Attendance';
    static readonly deletePermission = 'Operations:Attendance';
    static readonly insertPermission = 'Operations:Attendance';
    static readonly readPermission = 'Operations:Attendance';
    static readonly updatePermission = 'Operations:Attendance';

    static readonly Fields = fieldsProxy<AttendanceRow>();
}