import { BooleanEditor, DecimalEditor, initFormType, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";

export interface SalaryGradeForm {
    GradeName: StringEditor;
    GradeCode: StringEditor;
    MinSalary: DecimalEditor;
    MaxSalary: DecimalEditor;
    Description: TextAreaEditor;
    IsActive: BooleanEditor;
}

export class SalaryGradeForm extends PrefixedContext {
    static readonly formKey = 'Operations.SalaryGrade';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!SalaryGradeForm.init) {
            SalaryGradeForm.init = true;

            var w0 = StringEditor;
            var w1 = DecimalEditor;
            var w2 = TextAreaEditor;
            var w3 = BooleanEditor;

            initFormType(SalaryGradeForm, [
                'GradeName', w0,
                'GradeCode', w0,
                'MinSalary', w1,
                'MaxSalary', w1,
                'Description', w2,
                'IsActive', w3
            ]);
        }
    }
}