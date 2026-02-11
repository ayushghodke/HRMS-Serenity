import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { NoticeColumns, NoticeRow, NoticeService } from '../../ServerTypes/Communication';
import { NoticeDialog } from './NoticeDialog';

@Decorators.registerClass('HRMS.Communication.NoticeGrid')
export class NoticeGrid extends EntityGrid<NoticeRow, any> {
    protected getColumnsKey() { return NoticeColumns.columnsKey; }
    protected getDialogType() { return NoticeDialog; }
    protected getRowDefinition() { return NoticeRow; }
    protected getService() { return NoticeService.baseUrl; }

    constructor(container: JQuery) {
        super(container);
    }
}
