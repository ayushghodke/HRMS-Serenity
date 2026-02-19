import { BooleanEditor, EnumEditor, initFormType, PasswordEditor, PrefixedContext, StringEditor } from "@serenity-is/corelib";
import { SocialPlatform } from "./SocialPlatform";

export interface SocialPlatformConfigForm {
    Platform: EnumEditor;
    ClientId: StringEditor;
    ClientSecret: PasswordEditor;
    RedirectUri: StringEditor;
    IsEnabled: BooleanEditor;
}

export class SocialPlatformConfigForm extends PrefixedContext {
    static readonly formKey = 'Communication.SocialPlatformConfig';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!SocialPlatformConfigForm.init) {
            SocialPlatformConfigForm.init = true;

            var w0 = EnumEditor;
            var w1 = StringEditor;
            var w2 = PasswordEditor;
            var w3 = BooleanEditor;

            initFormType(SocialPlatformConfigForm, [
                'Platform', w0,
                'ClientId', w1,
                'ClientSecret', w2,
                'RedirectUri', w1,
                'IsEnabled', w3
            ]);
        }
    }
}

[SocialPlatform]; // referenced types