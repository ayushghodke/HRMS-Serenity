import { EnumEditor, ImageUploadEditor, initFormType, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { DocumentKind } from "./DocumentKind";

export interface EmployeeDocsForm {
    DocumentType: EnumEditor;
    Title: StringEditor;
    Description: TextAreaEditor;
    FilePath: ImageUploadEditor;
}

export class EmployeeDocsForm extends PrefixedContext {
    static readonly formKey = 'HR.EmployeeDocs';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!EmployeeDocsForm.init) {
            EmployeeDocsForm.init = true;

            var w0 = EnumEditor;
            var w1 = StringEditor;
            var w2 = TextAreaEditor;
            var w3 = ImageUploadEditor;

            initFormType(EmployeeDocsForm, [
                'DocumentType', w0,
                'Title', w1,
                'Description', w2,
                'FilePath', w3
            ]);
        }
    }
}

[DocumentKind]; // referenced types