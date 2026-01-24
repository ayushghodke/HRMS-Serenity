import { EntityDialog } from '@serenity-is/corelib';
import { CandidatesForm, CandidatesRow, CandidatesService } from '../../ServerTypes/Recruitment';

export class CandidatesDialog extends EntityDialog<CandidatesRow, any> {
    static override [Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.");

    protected override getFormKey() { return CandidatesForm.formKey; }
    protected override getRowDefinition() { return CandidatesRow; }
    protected override getService() { return CandidatesService.baseUrl; }

    protected form = new CandidatesForm(this.idPrefix);
}