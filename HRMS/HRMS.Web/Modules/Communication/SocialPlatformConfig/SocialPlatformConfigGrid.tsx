import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { SocialPlatformConfigColumns, SocialPlatformConfigRow, SocialPlatformConfigService } from '../../ServerTypes/Communication';
import { SocialPlatformConfigDialog } from './SocialPlatformConfigDialog';

@Decorators.registerClass('HRMS.Communication.SocialPlatformConfigGrid')
export class SocialPlatformConfigGrid extends EntityGrid<SocialPlatformConfigRow, any> {
    protected override getColumnsKey() { return SocialPlatformConfigColumns.columnsKey; }
    protected override getDialogType() { return SocialPlatformConfigDialog; }
    protected override getRowDefinition() { return SocialPlatformConfigRow; }
    protected override getService() { return SocialPlatformConfigService.baseUrl; }

    constructor(props: any) {
        super(props);
    }
}
