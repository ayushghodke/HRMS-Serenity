import { DateEditor, EnumEditor, initFormType, LookupEditor, PrefixedContext, StringEditor, TextAreaEditor } from "@serenity-is/corelib";
import { TaskStatus } from "./TaskStatus";

export interface TaskForm {
    Title: StringEditor;
    Description: TextAreaEditor;
    AssignedTo: LookupEditor;
    DueDate: DateEditor;
    Status: EnumEditor;
    AssignedBy: LookupEditor;
}

export class TaskForm extends PrefixedContext {
    static readonly formKey = 'Operations.Task';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!TaskForm.init) {
            TaskForm.init = true;

            var w0 = StringEditor;
            var w1 = TextAreaEditor;
            var w2 = LookupEditor;
            var w3 = DateEditor;
            var w4 = EnumEditor;

            initFormType(TaskForm, [
                'Title', w0,
                'Description', w1,
                'AssignedTo', w2,
                'DueDate', w3,
                'Status', w4,
                'AssignedBy', w2
            ]);
        }
    }
}

[TaskStatus]; // referenced types