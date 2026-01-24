import { EntityGrid } from '@serenity-is/corelib';
import { JobOpeningsColumns, JobOpeningsRow, JobOpeningsService } from '../../ServerTypes/Recruitment';
import { JobOpeningsDialog } from './JobOpeningsDialog';

export class JobOpeningsGrid extends EntityGrid<JobOpeningsRow> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.JobOpeningsGrid");

    protected override getColumnsKey() { return JobOpeningsColumns.columnsKey; }
    protected override getDialogType() { return JobOpeningsDialog; }
    protected override getRowDefinition() { return JobOpeningsRow; }
    protected override getService() { return JobOpeningsService.baseUrl; }
}
