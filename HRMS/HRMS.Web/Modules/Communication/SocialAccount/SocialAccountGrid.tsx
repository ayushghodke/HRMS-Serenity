import { Decorators, EntityGrid, ToolButton } from '@serenity-is/corelib';
import { SocialAccountColumns, SocialAccountRow, SocialAccountService } from '../../ServerTypes/Communication';
import { SocialAccountDialog } from './SocialAccountDialog';

@Decorators.registerClass('HRMS.Communication.SocialAccountGrid')
export class SocialAccountGrid extends EntityGrid<SocialAccountRow, any> {
    protected override getColumnsKey() { return SocialAccountColumns.columnsKey; }
    protected override getDialogType() { return SocialAccountDialog; }
    protected override getRowDefinition() { return SocialAccountRow; }
    protected override getService() { return SocialAccountService.baseUrl; }

    constructor(props: any) {
        super(props);
    }

    protected override getButtons(): ToolButton[] {
        let buttons = super.getButtons();

        buttons.push({
            title: 'Connect Account',
            cssClass: 'add-button',
            icon: 'fa-plug',
            onClick: () => {
                // Stub: In production this would redirect to OAuth flow
                // window.open('/Communication/SocialOAuth/Connect?platform=Facebook', '_blank');
                alert('OAuth integration will be configured with your platform credentials.\n\nTo connect accounts, configure ClientId and ClientSecret in appsettings.json for each platform.');
            }
        });

        return buttons;
    }
}
