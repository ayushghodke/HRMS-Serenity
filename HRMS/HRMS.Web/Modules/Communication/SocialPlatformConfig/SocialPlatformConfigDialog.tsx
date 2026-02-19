import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { SocialPlatformConfigForm, SocialPlatformConfigRow, SocialPlatformConfigService } from '../../ServerTypes/Communication';

@Decorators.registerClass('HRMS.Communication.SocialPlatformConfigDialog')
export class SocialPlatformConfigDialog extends EntityDialog<SocialPlatformConfigRow, any> {
    protected override getFormKey() { return SocialPlatformConfigForm.formKey; }
    protected override getRowDefinition() { return SocialPlatformConfigRow; }
    protected override getService() { return SocialPlatformConfigService.baseUrl; }

    protected form = new SocialPlatformConfigForm(this.idPrefix);
}
