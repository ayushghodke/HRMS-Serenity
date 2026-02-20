import { EntityDialog } from '@serenity-is/corelib';
import { AssetsForm, AssetsRow, AssetsService } from '../../ServerTypes/Operations';

export class AssetsDialog extends EntityDialog<AssetsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.AssetsDialog");

    protected override getFormKey() { return AssetsForm.formKey; }
    protected override getRowDefinition() { return AssetsRow; }
    protected override getService() { return AssetsService.baseUrl; }

    protected form = new AssetsForm(this.idPrefix);
}
