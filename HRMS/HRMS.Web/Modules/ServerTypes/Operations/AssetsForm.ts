import { DateEditor, DecimalEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { AssetStatus } from "./AssetStatus";
import { AssetType } from "./AssetType";

export interface AssetsForm {
    AssetName: StringEditor;
    SerialNumber: StringEditor;
    AssetType: EnumEditor;
    Status: EnumEditor;
    AssignedTo: LookupEditor;
    PurchaseDate: DateEditor;
    Cost: DecimalEditor;
    Description: TextAreaEditor;
}

export class AssetsForm extends PrefixedContext {
    static readonly formKey = 'Operations.Assets';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!AssetsForm.init) {
            AssetsForm.init = true;

            var w0 = StringEditor;
            var w1 = EnumEditor;
            var w2 = LookupEditor;
            var w3 = DateEditor;
            var w4 = DecimalEditor;
            var w5 = TextAreaEditor;

            initFormType(AssetsForm, [
                'AssetName', w0,
                'SerialNumber', w0,
                'AssetType', w1,
                'Status', w1,
                'AssignedTo', w2,
                'PurchaseDate', w3,
                'Cost', w4,
                'Description', w5
            ]);
        }
    }
}

[AssetType, AssetStatus]; // referenced types