import { EntityGrid } from '@serenity-is/corelib';
import { HolidayColumns, HolidayRow, HolidayService } from '../../ServerTypes/Operations';
import { HolidayDialog } from './HolidayDialog';

export class HolidayGrid extends EntityGrid<HolidayRow> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.HolidayGrid');

    protected override getColumnsKey() { return HolidayColumns.columnsKey; }
    protected override getDialogType() { return HolidayDialog; }
    protected override getRowDefinition() { return HolidayRow; }
    protected override getService() { return HolidayService.baseUrl; }
}
