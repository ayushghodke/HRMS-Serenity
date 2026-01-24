import { DecimalEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext } from "@serenity-is/corelib";
import { LeaveType } from "./LeaveType";

export interface LeaveBalanceForm {
    EmployeeId: LookupEditor;
    LeaveType: EnumEditor;
    Year: IntegerEditor;
    Allocated: DecimalEditor;
    Used: DecimalEditor;
}

export class LeaveBalanceForm extends PrefixedContext {
    static readonly formKey = 'Operations.LeaveBalance';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!LeaveBalanceForm.init) {
            LeaveBalanceForm.init = true;

            var w0 = LookupEditor;
            var w1 = EnumEditor;
            var w2 = IntegerEditor;
            var w3 = DecimalEditor;

            initFormType(LeaveBalanceForm, [
                'EmployeeId', w0,
                'LeaveType', w1,
                'Year', w2,
                'Allocated', w3,
                'Used', w3
            ]);
        }
    }
}

[LeaveType]; // referenced types