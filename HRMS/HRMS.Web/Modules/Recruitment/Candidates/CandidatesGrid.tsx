import { EntityGrid } from '@serenity-is/corelib';
import { CandidatesColumns, CandidatesRow, CandidatesService } from '../../ServerTypes/Recruitment';
import { CandidatesDialog } from './CandidatesDialog';
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

export class CandidatesGrid extends EntityGrid<CandidatesRow> {
    static override [Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.CandidatesGrid");

    protected override getColumnsKey() { return CandidatesColumns.columnsKey; }
    protected override getDialogType() { return CandidatesDialog; }
    protected override getRowDefinition() { return CandidatesRow; }
    protected override getService() { return CandidatesService.baseUrl; }

    protected override getColumns() {
        const columns = super.getColumns();

        columns.push({
            field: 'ScheduleInterview',
            name: 'Action',
            width: 180,
            minWidth: 160,
            maxWidth: 220,
            format: ctx => `<a href="javascript:;" class="schedule-interview-link" data-candidate-id="${ctx.item?.CandidateId ?? ''}"><i class="fa fa-calendar"></i> Schedule Interview</a>`
        } as any);

        return columns;
    }

    protected override onClick(e: any, row: number, cell: number) {
        const target = e?.target as HTMLElement;
        const scheduleLink = target?.closest('.schedule-interview-link') as HTMLElement;

        if (scheduleLink) {
            e.preventDefault();
            e.stopPropagation();

            const candidateIdText = scheduleLink.getAttribute('data-candidate-id');
            const candidateId = candidateIdText ? parseInt(candidateIdText, 10) : NaN;

            if (!Number.isFinite(candidateId) || candidateId <= 0)
                return;

            const interviewDialog = new ScheduleInterviewDialog(candidateId);
            interviewDialog.loadNewAndOpenDialog();

            return;
        }

        super.onClick(e, row, cell);
    }
}
