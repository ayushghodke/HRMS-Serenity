import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { SalaryComponentsColumns, SalaryComponentsRow, SalaryComponentsService } from '../../ServerTypes/Operations';
import { SalaryComponentsDialog } from './SalaryComponentsDialog';

@Decorators.registerClass('HRMS.Operations.SalaryComponentsGrid')
export class SalaryComponentsGrid extends EntityGrid<SalaryComponentsRow> {
    protected override getColumnsKey() { return SalaryComponentsColumns.columnsKey; }
    protected override getDialogType() { return SalaryComponentsDialog; }
    protected override getRowDefinition() { return SalaryComponentsRow; }
    protected override getService() { return SalaryComponentsService.baseUrl; }
}
