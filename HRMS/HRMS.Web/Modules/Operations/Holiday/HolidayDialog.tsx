import { EntityDialog } from '@serenity-is/corelib';
import { HolidayForm, HolidayRow, HolidayService } from '../../ServerTypes/Operations';

export class HolidayDialog extends EntityDialog<HolidayRow, any> {
    static override [Symbol.typeInfo] = this.registerClass('HRMS.Operations.HolidayDialog');

    protected override getFormKey() { return HolidayForm.formKey; }
    protected override getRowDefinition() { return HolidayRow; }
    protected override getService() { return HolidayService.baseUrl; }

    protected form = new HolidayForm(this.idPrefix);
}
