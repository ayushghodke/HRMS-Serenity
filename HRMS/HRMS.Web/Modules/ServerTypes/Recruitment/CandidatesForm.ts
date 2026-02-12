import { DateEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";
import { CandidateStatus } from "./CandidateStatus";

export interface CandidatesForm {
    JobId: LookupEditor;
    FirstName: StringEditor;
    LastName: StringEditor;
    Email: StringEditor;
    Mobile: StringEditor;
    ResumePath: StringEditor;
    Status: EnumEditor;
    AppliedDate: DateEditor;
}

export class CandidatesForm extends PrefixedContext {
    static readonly formKey = 'Recruitment.Candidates';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!CandidatesForm.init) {
            CandidatesForm.init = true;

            var w0 = LookupEditor;
            var w1 = StringEditor;
            var w2 = EnumEditor;
            var w3 = DateEditor;

            initFormType(CandidatesForm, [
                'JobId', w0,
                'FirstName', w1,
                'LastName', w1,
                'Email', w1,
                'Mobile', w1,
                'ResumePath', w1,
                'Status', w2,
                'AppliedDate', w3
            ]);
        }
    }
}

[CandidateStatus]; // referenced types