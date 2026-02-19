import { EnumEditor, ImageUploadEditor, initFormType, IntegerEditor, PrefixedContext } from "@serenity-is/corelib";
import { SocialMediaType } from "./SocialMediaType";

export interface SocialPostMediaForm {
    FileName: ImageUploadEditor;
    MediaType: EnumEditor;
    DisplayOrder: IntegerEditor;
}

export class SocialPostMediaForm extends PrefixedContext {
    static readonly formKey = 'Communication.SocialPostMedia';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!SocialPostMediaForm.init) {
            SocialPostMediaForm.init = true;

            var w0 = ImageUploadEditor;
            var w1 = EnumEditor;
            var w2 = IntegerEditor;

            initFormType(SocialPostMediaForm, [
                'FileName', w0,
                'MediaType', w1,
                'DisplayOrder', w2
            ]);
        }
    }
}

[SocialMediaType]; // referenced types