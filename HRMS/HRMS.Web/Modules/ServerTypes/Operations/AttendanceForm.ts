import { DateEditor, DecimalEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";
import { AttendanceType } from "./AttendanceType";

export interface AttendanceForm {
    UserId: StringEditor;
    Name: LookupEditor;
    DateNTime: DateEditor;
    Type: EnumEditor;
    Coordinates: StringEditor;
    PunchOutCoordinates: StringEditor;
    Location: StringEditor;
    ApprovedBy: LookupEditor;
    PunchIn: DateEditor;
    PunchOut: DateEditor;
    Distance: DecimalEditor;
}

export class AttendanceForm extends PrefixedContext {
    static readonly formKey = 'Operations.Attendance';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!AttendanceForm.init) {
            AttendanceForm.init = true;

            var w0 = StringEditor;
            var w1 = LookupEditor;
            var w2 = DateEditor;
            var w3 = EnumEditor;
            var w4 = DecimalEditor;

            initFormType(AttendanceForm, [
                'UserId', w0,
                'Name', w1,
                'DateNTime', w2,
                'Type', w3,
                'Coordinates', w0,
                'PunchOutCoordinates', w0,
                'Location', w0,
                'ApprovedBy', w1,
                'PunchIn', w2,
                'PunchOut', w2,
                'Distance', w4
            ]);
        }
    }
}

[AttendanceType]; // referenced types