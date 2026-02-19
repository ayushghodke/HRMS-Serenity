import { Decorators, EntityGrid, QuickSearchField } from '@serenity-is/corelib';
import { SocialPostColumns, SocialPostRow, SocialPostService } from '../../ServerTypes/Communication';
import { SocialPostDialog } from './SocialPostDialog';

@Decorators.registerClass('HRMS.Communication.SocialPostGrid')
export class SocialPostGrid extends EntityGrid<SocialPostRow, any> {
    protected override getColumnsKey() { return SocialPostColumns.columnsKey; }
    protected override getDialogType() { return SocialPostDialog; }
    protected override getRowDefinition() { return SocialPostRow; }
    protected override getService() { return SocialPostService.baseUrl; }

    constructor(props: any) {
        super(props);
    }

    protected override getQuickSearchFields(): QuickSearchField[] {
        return [
            { name: "", title: "all" },
            { name: "Title", title: "title" },
            { name: "Content", title: "content" }
        ];
    }
}
