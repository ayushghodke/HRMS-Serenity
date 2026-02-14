import { DecimalEditor, initFormType, LookupEditor, PrefixedContext } from "@serenity-is/corelib";

export interface EmployeeLeaveProfileForm {
    EmployeeId: LookupEditor;
    LeavePolicyId: LookupEditor;
    LeaveTypeId: LookupEditor;
    OpeningBalance: DecimalEditor;
    AccruedLeave: DecimalEditor;
    UsedLeave: DecimalEditor;
    PendingLeave: DecimalEditor;
    CarryForwardLeave: DecimalEditor;
    LOPDays: DecimalEditor;
}

export class EmployeeLeaveProfileForm extends PrefixedContext {
    static readonly formKey = 'Operations.EmployeeLeaveProfile';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!EmployeeLeaveProfileForm.init) {
            EmployeeLeaveProfileForm.init = true;

            var w0 = LookupEditor;
            var w1 = DecimalEditor;

            initFormType(EmployeeLeaveProfileForm, [
                'EmployeeId', w0,
                'LeavePolicyId', w0,
                'LeaveTypeId', w0,
                'OpeningBalance', w1,
                'AccruedLeave', w1,
                'UsedLeave', w1,
                'PendingLeave', w1,
                'CarryForwardLeave', w1,
                'LOPDays', w1
            ]);
        }
    }
}