import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { SocialPostForm, SocialPostRow, SocialPostService } from '../../ServerTypes/Communication';

@Decorators.registerClass('HRMS.Communication.SocialPostDialog')
export class SocialPostDialog extends EntityDialog<SocialPostRow, any> {
    protected override getFormKey() { return SocialPostForm.formKey; }
    protected override getRowDefinition() { return SocialPostRow; }
    protected override getService() { return SocialPostService.baseUrl; }

    protected form = new SocialPostForm(this.idPrefix);
}
