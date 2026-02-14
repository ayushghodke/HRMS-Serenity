import { BooleanEditor, DecimalEditor, EnumEditor, initFormType, IntegerEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { LeaveCategory } from "./LeaveCategory";
import { RecordStatus } from "./RecordStatus";

export interface LeaveTypeForm {
    LeaveTypeName: StringEditor;
    LeaveCode: StringEditor;
    LeaveCategory: EnumEditor;
    AnnualAllocation: DecimalEditor;
    MonthlyAccrual: BooleanEditor;
    CarryForwardAllowed: BooleanEditor;
    MaxCarryForwardDays: DecimalEditor;
    EncashmentAllowed: BooleanEditor;
    ApplicableDepartments: TextAreaEditor;
    ApplicableDesignations: TextAreaEditor;
    ApplicableBranches: StringEditor;
    GenderSpecific: BooleanEditor;
    ProbationApplicable: BooleanEditor;
    MinimumServiceRequiredMonths: IntegerEditor;
    MaxLeavePerRequest: DecimalEditor;
    SandwichRuleApplicable: BooleanEditor;
    HalfDayAllowed: BooleanEditor;
    DocumentsRequired: BooleanEditor;
    Status: EnumEditor;
}

export class LeaveTypeForm extends PrefixedContext {
    static readonly formKey = 'Operations.LeaveType';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!LeaveTypeForm.init) {
            LeaveTypeForm.init = true;

            var w0 = StringEditor;
            var w1 = EnumEditor;
            var w2 = DecimalEditor;
            var w3 = BooleanEditor;
            var w4 = TextAreaEditor;
            var w5 = IntegerEditor;

            initFormType(LeaveTypeForm, [
                'LeaveTypeName', w0,
                'LeaveCode', w0,
                'LeaveCategory', w1,
                'AnnualAllocation', w2,
                'MonthlyAccrual', w3,
                'CarryForwardAllowed', w3,
                'MaxCarryForwardDays', w2,
                'EncashmentAllowed', w3,
                'ApplicableDepartments', w4,
                'ApplicableDesignations', w4,
                'ApplicableBranches', w0,
                'GenderSpecific', w3,
                'ProbationApplicable', w3,
                'MinimumServiceRequiredMonths', w5,
                'MaxLeavePerRequest', w2,
                'SandwichRuleApplicable', w3,
                'HalfDayAllowed', w3,
                'DocumentsRequired', w3,
                'Status', w1
            ]);
        }
    }
}

[LeaveCategory, RecordStatus]; // referenced types