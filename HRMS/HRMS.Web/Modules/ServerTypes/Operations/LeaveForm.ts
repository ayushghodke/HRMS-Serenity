import { DateEditor, DecimalEditor, EnumEditor, ImageUploadEditor, initFormType, LookupEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { HalfDaySession } from "./HalfDaySession";
import { HrApprovalStatus } from "./HrApprovalStatus";
import { LeaveFinalStatus } from "./LeaveFinalStatus";
import { LeaveStatus } from "./LeaveStatus";

export interface LeaveForm {
    LeaveApplicationNo: StringEditor;
    ApplicationDate: DateEditor;
    EmployeeId: LookupEditor;
    LeaveTypeId: LookupEditor;
    StartDate: DateEditor;
    EndDate: DateEditor;
    HalfDaySession: EnumEditor;
    TotalDays: DecimalEditor;
    PaidDays: DecimalEditor;
    UnpaidDays: DecimalEditor;
    Reason: TextAreaEditor;
    Attachment: ImageUploadEditor;
    ReportingManagerId: LookupEditor;
    Status: EnumEditor;
    HrApprovalStatus: EnumEditor;
    FinalStatus: EnumEditor;
    ManagerRemarks: TextAreaEditor;
    HrRemarks: TextAreaEditor;
    SubstituteEmployeeId: LookupEditor;
    ContactDuringLeave: StringEditor;
}

export class LeaveForm extends PrefixedContext {
    static readonly formKey = 'Operations.Leave';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!LeaveForm.init) {
            LeaveForm.init = true;

            var w0 = StringEditor;
            var w1 = DateEditor;
            var w2 = LookupEditor;
            var w3 = EnumEditor;
            var w4 = DecimalEditor;
            var w5 = TextAreaEditor;
            var w6 = ImageUploadEditor;

            initFormType(LeaveForm, [
                'LeaveApplicationNo', w0,
                'ApplicationDate', w1,
                'EmployeeId', w2,
                'LeaveTypeId', w2,
                'StartDate', w1,
                'EndDate', w1,
                'HalfDaySession', w3,
                'TotalDays', w4,
                'PaidDays', w4,
                'UnpaidDays', w4,
                'Reason', w5,
                'Attachment', w6,
                'ReportingManagerId', w2,
                'Status', w3,
                'HrApprovalStatus', w3,
                'FinalStatus', w3,
                'ManagerRemarks', w5,
                'HrRemarks', w5,
                'SubstituteEmployeeId', w2,
                'ContactDuringLeave', w0
            ]);
        }
    }
}

[HalfDaySession, LeaveStatus, HrApprovalStatus, LeaveFinalStatus]; // referenced types