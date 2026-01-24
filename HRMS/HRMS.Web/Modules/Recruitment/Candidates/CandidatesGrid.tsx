import { EntityGrid } from '@serenity-is/corelib';
import { CandidatesColumns, CandidatesRow, CandidatesService } from '../../ServerTypes/Recruitment';
import { CandidatesDialog } from './CandidatesDialog';

export class CandidatesGrid extends EntityGrid<CandidatesRow> {
    static override [Symbol.typeInfo] = this.registerClass("HRMS.Recruitment.");

    protected override getColumnsKey() { return CandidatesColumns.columnsKey; }
    protected override getDialogType() { return CandidatesDialog; }
    protected override getRowDefinition() { return CandidatesRow; }
    protected override getService() { return CandidatesService.baseUrl; }
}