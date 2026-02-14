import { BooleanEditor, DateEditor, EnumEditor, initFormType, IntegerEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { HolidayType } from "./HolidayType";

export interface HolidayForm {
    HolidayName: StringEditor;
    HolidayDate: DateEditor;
    HolidayType: EnumEditor;
    Branch: StringEditor;
    ApplicableDepartments: TextAreaEditor;
    IsOptionalHoliday: BooleanEditor;
    Year: IntegerEditor;
}

export class HolidayForm extends PrefixedContext {
    static readonly formKey = 'Operations.Holiday';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!HolidayForm.init) {
            HolidayForm.init = true;

            var w0 = StringEditor;
            var w1 = DateEditor;
            var w2 = EnumEditor;
            var w3 = TextAreaEditor;
            var w4 = BooleanEditor;
            var w5 = IntegerEditor;

            initFormType(HolidayForm, [
                'HolidayName', w0,
                'HolidayDate', w1,
                'HolidayType', w2,
                'Branch', w0,
                'ApplicableDepartments', w3,
                'IsOptionalHoliday', w4,
                'Year', w5
            ]);
        }
    }
}

[HolidayType]; // referenced types