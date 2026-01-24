import { DateEditor, EnumEditor, initFormType, IntegerEditor, LookupEditor, PrefixedContext, TextAreaEditor } from "@serenity-is/corelib";
import { InterviewRound } from "./InterviewRound";

export interface InterviewsForm {
    CandidateId: LookupEditor;
    InterviewerId: LookupEditor;
    InterviewDate: DateEditor;
    Round: EnumEditor;
    Rating: IntegerEditor;
    Comments: TextAreaEditor;
}

export class InterviewsForm extends PrefixedContext {
    static readonly formKey = 'Recruitment.Interviews';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!InterviewsForm.init) {
            InterviewsForm.init = true;

            var w0 = LookupEditor;
            var w1 = DateEditor;
            var w2 = EnumEditor;
            var w3 = IntegerEditor;
            var w4 = TextAreaEditor;

            initFormType(InterviewsForm, [
                'CandidateId', w0,
                'InterviewerId', w0,
                'InterviewDate', w1,
                'Round', w2,
                'Rating', w3,
                'Comments', w4
            ]);
        }
    }
}

[InterviewRound]; // referenced types