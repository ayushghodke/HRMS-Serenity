import { BooleanEditor, DateEditor, EnumEditor, initFormType, PrefixedContext, StringEditor } from "@serenity-is/corelib";
import { SocialPlatform } from "./SocialPlatform";

export interface SocialAccountForm {
    Platform: EnumEditor;
    AccountName: StringEditor;
    ProfileUrl: StringEditor;
    ConnectedDate: DateEditor;
    IsActive: BooleanEditor;
}

export class SocialAccountForm extends PrefixedContext {
    static readonly formKey = 'Communication.SocialAccount';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!SocialAccountForm.init) {
            SocialAccountForm.init = true;

            var w0 = EnumEditor;
            var w1 = StringEditor;
            var w2 = DateEditor;
            var w3 = BooleanEditor;

            initFormType(SocialAccountForm, [
                'Platform', w0,
                'AccountName', w1,
                'ProfileUrl', w1,
                'ConnectedDate', w2,
                'IsActive', w3
            ]);
        }
    }
}

[SocialPlatform]; // referenced types
