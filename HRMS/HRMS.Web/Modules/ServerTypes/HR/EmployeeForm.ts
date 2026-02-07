import { DateEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";
import { EmployeeDocsEditor } from "../../HR/EmployeeDocs/EmployeeDocsEditor";
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
    DocumentList: EmployeeDocsEditor;
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
            var w4 = EmployeeDocsEditor;

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
                'UserId', w3,
                'DocumentList', w4
            ]);
        }
    }
}

[Gender, EmploymentType, EmployeeStatus]; // referenced types