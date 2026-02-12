import { EntityGrid } from "@serenity-is/corelib";
import { InterviewsColumns, InterviewsRow, InterviewsService } from "../../ServerTypes/Recruitment";
import { nsRecruitment } from "../../ServerTypes/Namespaces";
import { InterviewsDialog } from "./InterviewsDialog";

const candidateProgressSyncKey = "hrms:candidate-progress-changed";

export class InterviewsGrid extends EntityGrid<InterviewsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass(nsRecruitment);

    protected override getColumnsKey() { return InterviewsColumns.columnsKey; }
    protected override getDialogType() { return InterviewsDialog; }
    protected override getIdProperty() { return InterviewsRow.idProperty; }
    protected override getLocalTextPrefix() { return InterviewsRow.localTextPrefix; }
    protected override getService() { return InterviewsService.baseUrl; }

    protected override getColumns() {
        const columns = super.getColumns();

        columns.push({
            field: "MarkDone",
            name: "Action",
            width: 120,
            minWidth: 120,
            maxWidth: 140,
            format: ctx => {
                const row = ctx.item as InterviewsRow;

                if (row.IsCompleted)
                    return '<span class="text-success"><i class="fa fa-check-circle"></i> Done</span>';

                return '<a href="javascript:;" class="mark-interview-done"><i class="fa fa-check"></i> Mark Done</a>';
            }
        } as any);

        return columns;
    }

    protected override onClick(e: any, row: number, cell: number) {
        const target = e?.target as HTMLElement;
        const button = target?.closest(".mark-interview-done") as HTMLElement;

        if (button) {
            e.preventDefault();
            e.stopPropagation();

            const item = this.itemAt(row) as InterviewsRow;
            if (!item?.InterviewId || item.IsCompleted)
                return;

            if (!window.confirm("Mark this interview as done?"))
                return;

            InterviewsService.MarkDone({ InterviewId: item.InterviewId }, () => {
                this.notifyCandidateProgressChanged();
                this.refresh();
            });

            return;
        }

        super.onClick(e, row, cell);
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
