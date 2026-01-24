import { EntityDialog } from '@serenity-is/corelib';
import { JobOpeningsForm, JobOpeningsRow, JobOpeningsService } from '../../ServerTypes/Recruitment';

export class JobOpeningsDialog extends EntityDialog<JobOpeningsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.JobOpeningsDialog");

    protected override getFormKey() { return JobOpeningsForm.formKey; }
    protected override getRowDefinition() { return JobOpeningsRow; }
    protected override getService() { return JobOpeningsService.baseUrl; }

    protected form = new JobOpeningsForm(this.idPrefix);
}
