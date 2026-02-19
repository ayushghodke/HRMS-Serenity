import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { SocialPlatform } from "./SocialPlatform";
import { SocialPostRow } from "./SocialPostRow";

export interface SocialPostColumns {
    SocialPostId: Column<SocialPostRow>;
    SocialAccountName: Column<SocialPostRow>;
    SocialAccountPlatform: Column<SocialPostRow>;
    Title: Column<SocialPostRow>;
    PostType: Column<SocialPostRow>;
    Status: Column<SocialPostRow>;
    ScheduledDate: Column<SocialPostRow>;
    PublishedDate: Column<SocialPostRow>;
}

export class SocialPostColumns extends ColumnsBase<SocialPostRow> {
    static readonly columnsKey = 'Communication.SocialPost';
    static readonly Fields = fieldsProxy<SocialPostColumns>();
}

[SocialPlatform]; // referenced types