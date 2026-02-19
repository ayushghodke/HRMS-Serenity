import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { SocialPlatform } from "./SocialPlatform";
import { SocialPlatformConfigRow } from "./SocialPlatformConfigRow";

export interface SocialPlatformConfigColumns {
    SocialPlatformConfigId: Column<SocialPlatformConfigRow>;
    Platform: Column<SocialPlatformConfigRow>;
    ClientId: Column<SocialPlatformConfigRow>;
    RedirectUri: Column<SocialPlatformConfigRow>;
    IsEnabled: Column<SocialPlatformConfigRow>;
}

export class SocialPlatformConfigColumns extends ColumnsBase<SocialPlatformConfigRow> {
    static readonly columnsKey = 'Communication.SocialPlatformConfig';
    static readonly Fields = fieldsProxy<SocialPlatformConfigColumns>();
}

[SocialPlatform]; // referenced types