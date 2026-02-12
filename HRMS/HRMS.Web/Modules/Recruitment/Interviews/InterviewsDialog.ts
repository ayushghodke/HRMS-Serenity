import { EntityDialog } from "@serenity-is/corelib";
import { InterviewsForm, InterviewsRow, InterviewsService } from "../../ServerTypes/Recruitment";
import { nsRecruitment } from "../../ServerTypes/Namespaces";

const candidateProgressSyncKey = "hrms:candidate-progress-changed";

export class InterviewsDialog extends EntityDialog<InterviewsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass(nsRecruitment);

    protected override getFormKey() { return InterviewsForm.formKey; }
    protected override getIdProperty() { return InterviewsRow.idProperty; }
    protected override getLocalTextPrefix() { return InterviewsRow.localTextPrefix; }
    protected override getService() { return InterviewsService.baseUrl; }

    protected form = new InterviewsForm(this.idPrefix);

    protected override onSaveSuccess(response: any) {
        super.onSaveSuccess(response);
        this.notifyCandidateProgressChanged();
    }

    private notifyCandidateProgressChanged() {
        window.dispatchEvent(new Event("candidate-progress-changed"));

        try {
            window.localStorage.setItem(candidateProgressSyncKey, new Date().toISOString());
        }
        catch {
            // no-op
        }
    }
}
