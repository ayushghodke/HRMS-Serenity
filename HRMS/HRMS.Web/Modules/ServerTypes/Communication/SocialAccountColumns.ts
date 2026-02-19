import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { SocialAccountRow } from "./SocialAccountRow";
import { SocialPlatform } from "./SocialPlatform";

export interface SocialAccountColumns {
    SocialAccountId: Column<SocialAccountRow>;
    Platform: Column<SocialAccountRow>;
    AccountName: Column<SocialAccountRow>;
    ProfileUrl: Column<SocialAccountRow>;
    ConnectedDate: Column<SocialAccountRow>;
    IsActive: Column<SocialAccountRow>;
}

export class SocialAccountColumns extends ColumnsBase<SocialAccountRow> {
    static readonly columnsKey = 'Communication.SocialAccount';
    static readonly Fields = fieldsProxy<SocialAccountColumns>();
}

[SocialPlatform]; // referenced types