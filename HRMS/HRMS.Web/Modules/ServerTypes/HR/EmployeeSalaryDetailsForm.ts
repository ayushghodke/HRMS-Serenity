import { DecimalEditor, initFormType, LookupEditor, PrefixedContext } from "@serenity-is/corelib";

export interface EmployeeSalaryDetailsForm {
    ComponentId: LookupEditor;
    Amount: DecimalEditor;
}

export class EmployeeSalaryDetailsForm extends PrefixedContext {
    static readonly formKey = 'HR.EmployeeSalaryDetails';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!EmployeeSalaryDetailsForm.init) {
            EmployeeSalaryDetailsForm.init = true;

            var w0 = LookupEditor;
            var w1 = DecimalEditor;

            initFormType(EmployeeSalaryDetailsForm, [
                'ComponentId', w0,
                'Amount', w1
            ]);
        }
    }
}