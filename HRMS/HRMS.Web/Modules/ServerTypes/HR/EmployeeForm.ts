import { DateEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";
import { EmployeeStatus } from "./EmployeeStatus";
import { EmploymentType } from "./EmploymentType";
import { Gender } from "./Gender";

export interface EmployeeForm {
    FirstName: StringEditor;
    LastName: StringEditor;
    EmployeeCode: StringEditor;
    Email: StringEditor;
    Phone: StringEditor;
    Gender: EnumEditor;
    DateOfBirth: DateEditor;
    JoiningDate: DateEditor;
    DepartmentId: LookupEditor;
    DesignationId: LookupEditor;
    ManagerId: LookupEditor;
    EmploymentType: EnumEditor;
    Status: EnumEditor;
    UserId: LookupEditor;
}

export class EmployeeForm extends PrefixedContext {
    static readonly formKey = 'HR.Employee';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!EmployeeForm.init) {
            EmployeeForm.init = true;

            var w0 = StringEditor;
            var w1 = EnumEditor;
            var w2 = DateEditor;
            var w3 = LookupEditor;

            initFormType(EmployeeForm, [
                'FirstName', w0,
                'LastName', w0,
                'EmployeeCode', w0,
                'Email', w0,
                'Phone', w0,
                'Gender', w1,
                'DateOfBirth', w2,
                'JoiningDate', w2,
                'DepartmentId', w3,
                'DesignationId', w3,
                'ManagerId', w3,
                'EmploymentType', w1,
                'Status', w1,
                'UserId', w3
            ]);
        }
    }
}

[Gender, EmploymentType, EmployeeStatus]; // referenced types