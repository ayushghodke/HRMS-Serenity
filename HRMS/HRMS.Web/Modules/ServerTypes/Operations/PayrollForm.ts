import { DecimalEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext } from "@serenity-is/corelib";
import { Month } from "./Month";

export interface PayrollForm {
    EmployeeId: LookupEditor;
    Month: EnumEditor;
    Year: IntegerEditor;
    BasicSalary: DecimalEditor;
    Allowances: DecimalEditor;
    Deductions: DecimalEditor;
    NetSalary: DecimalEditor;
}

export class PayrollForm extends PrefixedContext {
    static readonly formKey = 'Operations.Payroll';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!PayrollForm.init) {
            PayrollForm.init = true;

            var w0 = LookupEditor;
            var w1 = EnumEditor;
            var w2 = IntegerEditor;
            var w3 = DecimalEditor;

            initFormType(PayrollForm, [
                'EmployeeId', w0,
                'Month', w1,
                'Year', w2,
                'BasicSalary', w3,
                'Allowances', w3,
                'Deductions', w3,
                'NetSalary', w3
            ]);
        }
    }
}

[Month]; // referenced types