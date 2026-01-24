import { EntityDialog } from '@serenity-is/corelib';
import { DepartmentForm, DepartmentRow, DepartmentService } from '../../ServerTypes/HR';

export class DepartmentDialog extends EntityDialog<DepartmentRow, any> {
    static override [Symbol.typeInfo] = this.registerClass("HRMS.HR.DepartmentDialog");

    protected override getFormKey() { return DepartmentForm.formKey; }
    protected override getRowDefinition() { return DepartmentRow; }
    protected override getService() { return DepartmentService.baseUrl; }

    protected form = new DepartmentForm(this.idPrefix);
}
