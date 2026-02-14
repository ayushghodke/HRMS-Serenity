import { DateEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";
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
    PaidLeavesPerMonth: IntegerEditor;
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
            var w3 = IntegerEditor;
            var w4 = LookupEditor;
            var w5 = EmployeeDocsEditor;

            initFormType(EmployeeForm, [
                'FirstName', w0,
                'LastName', w0,
                'EmployeeCode', w0,
                'Email', w0,
                'Phone', w0,
                'Gender', w1,
                'DateOfBirth', w2,
                'JoiningDate', w2,
                'PaidLeavesPerMonth', w3,
                'DepartmentId', w4,
                'DesignationId', w4,
                'ManagerId', w4,
                'EmploymentType', w1,
                'Status', w1,
                'UserId', w4,
                'DocumentList', w5
            ]);
        }
    }
}

[Gender, EmploymentType, EmployeeStatus]; // referenced types