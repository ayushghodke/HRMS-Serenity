import { EntityDialog } from '@serenity-is/corelib';
import { CandidatesForm, CandidatesRow, CandidatesService } from '../../ServerTypes/Recruitment';
import { InterviewsDialog } from '../Interviews/InterviewsDialog';

class ScheduleInterviewDialog extends InterviewsDialog {
    constructor(private readonly candidateId: number) {
        super();
    }

    protected override afterLoadEntity() {
        super.afterLoadEntity();
        this.form.CandidateId.value = this.candidateId?.toString();
    }
}

export class CandidatesDialog extends EntityDialog<CandidatesRow, any> {
    static override [Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.CandidatesDialog");

    protected override getFormKey() { return CandidatesForm.formKey; }
    protected override getRowDefinition() { return CandidatesRow; }
    protected override getService() { return CandidatesService.baseUrl; }

    protected form = new CandidatesForm(this.idPrefix);

    protected override getToolbarButtons() {
        const buttons = super.getToolbarButtons();

        buttons.push({
            title: 'Schedule Interview',
            cssClass: 'schedule-interview-button',
            icon: 'fa-calendar',
            onClick: () => {
                const candidateId = this.entity?.CandidateId;
                if (!candidateId)
                    return;

                const interviewDialog = new ScheduleInterviewDialog(candidateId);
                interviewDialog.loadNewAndOpenDialog();
            }
        });

        return buttons;
    }

    protected override updateInterface() {
        super.updateInterface();
        this.toolbar.findButton('schedule-interview-button').toggleClass('disabled', this.isNewOrDeleted());
    }
}
