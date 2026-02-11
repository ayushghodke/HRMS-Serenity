import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { NoticeColumns, NoticeRow, NoticeService } from '../../ServerTypes/Communication';
import { NoticeDialog } from './NoticeDialog';

@Decorators.registerClass('HRMS.Communication.NoticeGrid')
export class NoticeGrid extends EntityGrid<NoticeRow, any> {
    protected override getColumnsKey() { return NoticeColumns.columnsKey; }
    protected override getDialogType() { return NoticeDialog; }
    protected override getRowDefinition() { return NoticeRow; }
    protected override getService() { return NoticeService.baseUrl; }

    constructor(props: any) {
        super(props);
    }
}
