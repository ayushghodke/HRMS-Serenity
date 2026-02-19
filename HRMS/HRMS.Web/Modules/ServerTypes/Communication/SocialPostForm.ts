import { DateEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, StringEditor, TextAreaEditor, Widget } from "@serenity-is/corelib";
import { SocialPostStatus } from "./SocialPostStatus";
import { SocialPostType } from "./SocialPostType";

export interface SocialPostForm {
    SocialAccountId: LookupEditor;
    Title: StringEditor;
    Content: TextAreaEditor;
    PostType: EnumEditor;
    Status: EnumEditor;
    ScheduledDate: DateEditor;
    PublishedDate: DateEditor;
    MediaList: Widget;
}

export class SocialPostForm extends PrefixedContext {
    static readonly formKey = 'Communication.SocialPost';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!SocialPostForm.init) {
            SocialPostForm.init = true;

            var w0 = LookupEditor;
            var w1 = StringEditor;
            var w2 = TextAreaEditor;
            var w3 = EnumEditor;
            var w4 = DateEditor;
            var w5 = Widget;

            initFormType(SocialPostForm, [
                'SocialAccountId', w0,
                'Title', w1,
                'Content', w2,
                'PostType', w3,
                'Status', w3,
                'ScheduledDate', w4,
                'PublishedDate', w4,
                'MediaList', w5
            ]);
        }
    }
}

[SocialPostType, SocialPostStatus]; // referenced types