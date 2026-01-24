import { EntityDialog } from '@serenity-is/corelib';
import { DesignationForm, DesignationRow, DesignationService } from '../../ServerTypes/HR';

export class DesignationDialog extends EntityDialog<DesignationRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.HR.DesignationDialog");

    protected override getFormKey() { return DesignationForm.formKey; }
    protected override getRowDefinition() { return DesignationRow; }
    protected override getService() { return DesignationService.baseUrl; }

    protected form = new DesignationForm(this.idPrefix);
}
