import { EntityGrid } from '@serenity-is/corelib';
import { CandidatesColumns, CandidatesRow, CandidatesService } from '../../ServerTypes/Recruitment';
import { CandidatesDialog } from './CandidatesDialog';
import { InterviewsDialog } from '../Interviews/InterviewsDialog';

export class CandidatesGrid extends EntityGrid<CandidatesRow> {
    static override [Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.");

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
            format: () => '<a href="javascript:;" class="schedule-interview-link"><i class="fa fa-calendar"></i> Schedule Interview</a>'
        } as any);

        return columns;
    }

    protected override onClick(e: any, row: number, cell: number) {
        const target = e?.target as HTMLElement;
        const scheduleLink = target?.closest('.schedule-interview-link') as HTMLElement;

        if (scheduleLink) {
            e.preventDefault();
            e.stopPropagation();

            const item = this.itemAt(row) as CandidatesRow;
            if (!item?.CandidateId)
                return;

            const interviewDialog = new InterviewsDialog();
            interviewDialog.loadEntityAndOpenDialog({
                CandidateId: item.CandidateId
            });

            return;
        }

        super.onClick(e, row, cell);
    }
}
