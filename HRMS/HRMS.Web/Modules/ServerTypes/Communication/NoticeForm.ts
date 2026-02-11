import { BooleanEditor, DateEditor, EnumEditor, initFormType, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { NoticePriority } from "./NoticePriority";

export interface NoticeForm {
    Title: StringEditor;
    Description: TextAreaEditor;
    Priority: EnumEditor;
    PublishDate: DateEditor;
    ExpiryDate: DateEditor;
    IsActive: BooleanEditor;
}

export class NoticeForm extends PrefixedContext {
    static readonly formKey = 'Communication.Notice';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!NoticeForm.init) {
            NoticeForm.init = true;

            var w0 = StringEditor;
            var w1 = TextAreaEditor;
            var w2 = EnumEditor;
            var w3 = DateEditor;
            var w4 = BooleanEditor;

            initFormType(NoticeForm, [
                'Title', w0,
                'Description', w1,
                'Priority', w2,
                'PublishDate', w3,
                'ExpiryDate', w3,
                'IsActive', w4
            ]);
        }
    }
}

[NoticePriority]; // referenced types