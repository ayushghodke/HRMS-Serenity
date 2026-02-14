import { BooleanEditor, DateEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext, TextAreaEditor } from "@serenity-is/corelib";
import { LeaveStatus } from "./LeaveStatus";

export interface LeaveApprovalForm {
    LeaveId: LookupEditor;
    ApproverId: LookupEditor;
    ApprovalLevel: IntegerEditor;
    ApprovalDate: DateEditor;
    Status: EnumEditor;
    Remarks: TextAreaEditor;
    EscalationTrigger: BooleanEditor;
    EscalationTo: LookupEditor;
}

export class LeaveApprovalForm extends PrefixedContext {
    static readonly formKey = 'Operations.LeaveApproval';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!LeaveApprovalForm.init) {
            LeaveApprovalForm.init = true;

            var w0 = LookupEditor;
            var w1 = IntegerEditor;
            var w2 = DateEditor;
            var w3 = EnumEditor;
            var w4 = TextAreaEditor;
            var w5 = BooleanEditor;

            initFormType(LeaveApprovalForm, [
                'LeaveId', w0,
                'ApproverId', w0,
                'ApprovalLevel', w1,
                'ApprovalDate', w2,
                'Status', w3,
                'Remarks', w4,
                'EscalationTrigger', w5,
                'EscalationTo', w0
            ]);
        }
    }
}

[LeaveStatus]; // referenced types