import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { NoticeForm, NoticeRow, NoticeService } from '../../ServerTypes/Communication';

@Decorators.registerClass('HRMS.Communication.NoticeDialog')
export class NoticeDialog extends EntityDialog<NoticeRow, any> {
    protected getFormKey() { return NoticeForm.formKey; }
    protected getRowDefinition() { return NoticeRow; }
    protected getService() { return NoticeService.baseUrl; }

    protected form = new NoticeForm(this.idPrefix);
}
