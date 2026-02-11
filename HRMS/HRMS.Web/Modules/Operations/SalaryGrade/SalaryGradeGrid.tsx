import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { SalaryGradeColumns, SalaryGradeRow, SalaryGradeService } from '../../ServerTypes/Operations';
import { SalaryGradeDialog } from './SalaryGradeDialog';

@Decorators.registerClass('HRMS.Operations.SalaryGradeGrid')
export class SalaryGradeGrid extends EntityGrid<SalaryGradeRow> {
    protected override getColumnsKey() { return SalaryGradeColumns.columnsKey; }
    protected override getDialogType() { return SalaryGradeDialog; }
    protected override getRowDefinition() { return SalaryGradeRow; }
    protected override getService() { return SalaryGradeService.baseUrl; }
}
