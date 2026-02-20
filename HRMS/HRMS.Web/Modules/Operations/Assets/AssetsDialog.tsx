import { EntityDialog } from '@serenity-is/corelib';
import { AssetsForm, AssetsRow, AssetsService } from '../../ServerTypes/Operations';

export class AssetsDialog extends EntityDialog<AssetsRow, any> {
    static override[Symbol.typeInfo] = this.registerClass("HRMS.Operations.AssetsDialog");

    protected override getFormKey() { return AssetsForm.formKey; }
    protected override getRowDefinition() { return AssetsRow; }
    protected override getService() { return AssetsService.baseUrl; }

    protected override getToolbarButtons() {
        var buttons = super.getToolbarButtons();
        var saveButton = buttons.find(b => b.cssClass.indexOf('save-button') >= 0);
        if (saveButton) {
            saveButton.onClick = () => {
                this.save(() => this.dialogClose());
            };
        }
        return buttons;
    }

    protected form = new AssetsForm(this.idPrefix);
}
