import { DateEditor, DecimalEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, TextAreaEditor } from "@serenity-is/corelib";
import { LeaveStatus } from "./LeaveStatus";
import { LeaveType } from "./LeaveType";

export interface LeaveForm {
    EmployeeId: LookupEditor;
    LeaveType: EnumEditor;
    StartDate: DateEditor;
    EndDate: DateEditor;
    TotalDays: DecimalEditor;
    Reason: TextAreaEditor;
    Status: EnumEditor;
    ApprovedBy: LookupEditor;
}

export class LeaveForm extends PrefixedContext {
    static readonly formKey = 'Operations.Leave';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!LeaveForm.init) {
            LeaveForm.init = true;

            var w0 = LookupEditor;
            var w1 = EnumEditor;
            var w2 = DateEditor;
            var w3 = DecimalEditor;
            var w4 = TextAreaEditor;

            initFormType(LeaveForm, [
                'EmployeeId', w0,
                'LeaveType', w1,
                'StartDate', w2,
                'EndDate', w2,
                'TotalDays', w3,
                'Reason', w4,
                'Status', w1,
                'ApprovedBy', w0
            ]);
        }
    }
}

[LeaveType, LeaveStatus]; // referenced types