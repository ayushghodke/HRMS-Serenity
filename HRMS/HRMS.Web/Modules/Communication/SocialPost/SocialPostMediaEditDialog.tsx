import { Decorators, EntityDialog, EditorUtils } from '@serenity-is/corelib';
import { SocialPostMediaForm, SocialPostMediaRow } from '../../ServerTypes/Communication';

@Decorators.registerClass('HRMS.Communication.SocialPostMediaEditDialog')
export class SocialPostMediaEditDialog extends EntityDialog<SocialPostMediaRow, any> {
    protected override getFormKey() { return SocialPostMediaForm.formKey; }
    protected override getRowDefinition() { return SocialPostMediaRow; }

    protected form = new SocialPostMediaForm(this.idPrefix);

    protected override getIdProperty() { return '__id'; }

    protected override updateInterface() {
        super.updateInterface();
        this.toolbar.findButton('apply-changes-button').hide();
        this.toolbar.findButton('delete-button').hide();
    }
}
