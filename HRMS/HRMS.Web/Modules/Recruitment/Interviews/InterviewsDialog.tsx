import { EntityDialog } from '@serenity-is/corelib';
import { InterviewsForm, InterviewsRow, InterviewsService } from '../../ServerTypes/Recruitment';

export class InterviewsDialog extends EntityDialog<InterviewsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.InterviewsDialog");

    protected override getFormKey() { return InterviewsForm.formKey; }
    protected override getRowDefinition() { return InterviewsRow; }
    protected override getService() { return InterviewsService.baseUrl; }

    protected form = new InterviewsForm(this.idPrefix);
}
