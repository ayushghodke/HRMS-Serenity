import { BooleanEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { SalaryCalculationType } from "./SalaryCalculationType";
import { SalaryComponentType } from "./SalaryComponentType";

export interface SalaryComponentsForm {
    ComponentName: StringEditor;
    ComponentType: EnumEditor;
    CalculationType: EnumEditor;
    PercentageOf: LookupEditor;
    IsStatutory: BooleanEditor;
    IsTaxable: BooleanEditor;
    DisplayOrder: IntegerEditor;
    Description: TextAreaEditor;
    IsActive: BooleanEditor;
}

export class SalaryComponentsForm extends PrefixedContext {
    static readonly formKey = 'Operations.SalaryComponents';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!SalaryComponentsForm.init) {
            SalaryComponentsForm.init = true;

            var w0 = StringEditor;
            var w1 = EnumEditor;
            var w2 = LookupEditor;
            var w3 = BooleanEditor;
            var w4 = IntegerEditor;
            var w5 = TextAreaEditor;

            initFormType(SalaryComponentsForm, [
                'ComponentName', w0,
                'ComponentType', w1,
                'CalculationType', w1,
                'PercentageOf', w2,
                'IsStatutory', w3,
                'IsTaxable', w3,
                'DisplayOrder', w4,
                'Description', w5,
                'IsActive', w3
            ]);
        }
    }
}

[SalaryComponentType, SalaryCalculationType]; // referenced types