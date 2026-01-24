import { DateEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { JobOpeningStatus } from "./JobOpeningStatus";

export interface JobOpeningsForm {
    Title: StringEditor;
    Description: TextAreaEditor;
    DepartmentId: LookupEditor;
    HiringManagerId: LookupEditor;
    Status: EnumEditor;
    CreatedDate: DateEditor;
}

export class JobOpeningsForm extends PrefixedContext {
    static readonly formKey = 'Recruitment.JobOpenings';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!JobOpeningsForm.init) {
            JobOpeningsForm.init = true;

            var w0 = StringEditor;
            var w1 = TextAreaEditor;
            var w2 = LookupEditor;
            var w3 = EnumEditor;
            var w4 = DateEditor;

            initFormType(JobOpeningsForm, [
                'Title', w0,
                'Description', w1,
                'DepartmentId', w2,
                'HiringManagerId', w2,
                'Status', w3,
                'CreatedDate', w4
            ]);
        }
    }
}

[JobOpeningStatus]; // referenced types