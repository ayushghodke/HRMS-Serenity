import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { NoticeForm, NoticeRow, NoticeService } from '../../ServerTypes/Communication';

@Decorators.registerClass('HRMS.Communication.NoticeDialog')
export class NoticeDialog extends EntityDialog<NoticeRow, any> {
    protected override getFormKey() { return NoticeForm.formKey; }
    protected override getRowDefinition() { return NoticeRow; }
    protected override getService() { return NoticeService.baseUrl; }

    protected form = new NoticeForm(this.idPrefix);
}
