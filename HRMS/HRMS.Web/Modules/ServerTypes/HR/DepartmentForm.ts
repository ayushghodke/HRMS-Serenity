import { BooleanEditor, initFormType, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";

export interface DepartmentForm {
    DepartmentName: StringEditor;
    Description: TextAreaEditor;
    IsActive: BooleanEditor;
}

export class DepartmentForm extends PrefixedContext {
    static readonly formKey = 'HR.Department';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!DepartmentForm.init) {
            DepartmentForm.init = true;

            var w0 = StringEditor;
            var w1 = TextAreaEditor;
            var w2 = BooleanEditor;

            initFormType(DepartmentForm, [
                'DepartmentName', w0,
                'Description', w1,
                'IsActive', w2
            ]);
        }
    }
}