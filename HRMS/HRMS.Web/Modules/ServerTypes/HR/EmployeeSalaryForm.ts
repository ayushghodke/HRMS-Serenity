import { BooleanEditor, DateEditor, DecimalEditor, initFormType, LookupEditor, PrefixedContext, Widget } from "@serenity-is/corelib";

export interface EmployeeSalaryForm {
    EmployeeId: LookupEditor;
    GradeId: LookupEditor;
    EffectiveDate: DateEditor;
    BasicSalary: DecimalEditor;
    GrossSalary: DecimalEditor;
    DetailList: Widget;
    IsActive: BooleanEditor;
}

export class EmployeeSalaryForm extends PrefixedContext {
    static readonly formKey = 'HR.EmployeeSalary';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!EmployeeSalaryForm.init) {
            EmployeeSalaryForm.init = true;

            var w0 = LookupEditor;
            var w1 = DateEditor;
            var w2 = DecimalEditor;
            var w3 = Widget;
            var w4 = BooleanEditor;

            initFormType(EmployeeSalaryForm, [
                'EmployeeId', w0,
                'GradeId', w0,
                'EffectiveDate', w1,
                'BasicSalary', w2,
                'GrossSalary', w2,
                'DetailList', w3,
                'IsActive', w4
            ]);
        }
    }
}