import { EntityDialog } from '@serenity-is/corelib';
import { AttendanceForm, AttendanceRow, AttendanceService } from '../../ServerTypes/Operations';

export class AttendanceDialog extends EntityDialog<AttendanceRow, any> {
    static override [Symbol.typeInfo] = this.registerClass("HRMS.Operations.");

    protected override getFormKey() { return AttendanceForm.formKey; }
    protected override getRowDefinition() { return AttendanceRow; }
    protected override getService() { return AttendanceService.baseUrl; }

    protected form = new AttendanceForm(this.idPrefix);
}