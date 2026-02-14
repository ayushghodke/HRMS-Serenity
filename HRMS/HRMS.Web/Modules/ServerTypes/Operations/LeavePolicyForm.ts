import { BooleanEditor, DateEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";
import { ApprovalLevelMode } from "./ApprovalLevelMode";
import { RecordStatus } from "./RecordStatus";

export interface LeavePolicyForm {
    PolicyName: StringEditor;
    ApplicableFromDate: DateEditor;
    Branch: StringEditor;
    DepartmentId: LookupEditor;
    MaxConsecutiveLeavesAllowed: IntegerEditor;
    NoticePeriodLeaveAllowed: BooleanEditor;
    ProbationLeaveAllowed: BooleanEditor;
    ApprovalLevels: EnumEditor;
    HROverridePermission: BooleanEditor;
    PayrollCutoffDay: IntegerEditor;
    Status: EnumEditor;
}

export class LeavePolicyForm extends PrefixedContext {
    static readonly formKey = 'Operations.LeavePolicy';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!LeavePolicyForm.init) {
            LeavePolicyForm.init = true;

            var w0 = StringEditor;
            var w1 = DateEditor;
            var w2 = LookupEditor;
            var w3 = IntegerEditor;
            var w4 = BooleanEditor;
            var w5 = EnumEditor;

            initFormType(LeavePolicyForm, [
                'PolicyName', w0,
                'ApplicableFromDate', w1,
                'Branch', w0,
                'DepartmentId', w2,
                'MaxConsecutiveLeavesAllowed', w3,
                'NoticePeriodLeaveAllowed', w4,
                'ProbationLeaveAllowed', w4,
                'ApprovalLevels', w5,
                'HROverridePermission', w4,
                'PayrollCutoffDay', w3,
                'Status', w5
            ]);
        }
    }
}

[ApprovalLevelMode, RecordStatus]; // referenced types