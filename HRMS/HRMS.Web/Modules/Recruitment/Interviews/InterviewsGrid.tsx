import { EntityGrid } from '@serenity-is/corelib';
import { InterviewsColumns, InterviewsRow, InterviewsService } from '../../ServerTypes/Recruitment';
import { InterviewsDialog } from './InterviewsDialog';

export class InterviewsGrid extends EntityGrid<InterviewsRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.InterviewsGrid");

    protected override getColumnsKey() { return InterviewsColumns.columnsKey; }
    protected override getDialogType() { return InterviewsDialog; }
    protected override getRowDefinition() { return InterviewsRow; }
    protected override getService() { return InterviewsService.baseUrl; }
}
