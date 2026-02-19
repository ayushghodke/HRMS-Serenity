import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { SocialAccountForm, SocialAccountRow, SocialAccountService } from '../../ServerTypes/Communication';

@Decorators.registerClass('HRMS.Communication.SocialAccountDialog')
export class SocialAccountDialog extends EntityDialog<SocialAccountRow, any> {
    protected override getFormKey() { return SocialAccountForm.formKey; }
    protected override getRowDefinition() { return SocialAccountRow; }
    protected override getService() { return SocialAccountService.baseUrl; }

    protected form = new SocialAccountForm(this.idPrefix);
}
