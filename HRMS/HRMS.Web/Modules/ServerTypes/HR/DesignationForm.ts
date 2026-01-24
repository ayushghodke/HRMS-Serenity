import { BooleanEditor, initFormType, IntegerEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface DesignationForm {
    DesignationName: StringEditor;
    Level: IntegerEditor;
    IsActive: BooleanEditor;
}

export class DesignationForm extends PrefixedContext {
    static readonly formKey = 'HR.Designation';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!DesignationForm.init) {
            DesignationForm.init = true;

            var w0 = StringEditor;
            var w1 = IntegerEditor;
            var w2 = BooleanEditor;

            initFormType(DesignationForm, [
                'DesignationName', w0,
                'Level', w1,
                'IsActive', w2
            ]);
        }
    }
}