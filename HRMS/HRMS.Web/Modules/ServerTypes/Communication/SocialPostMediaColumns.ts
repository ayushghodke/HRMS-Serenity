import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { SocialMediaType } from "./SocialMediaType";
import { SocialPostMediaRow } from "./SocialPostMediaRow";

export interface SocialPostMediaColumns {
    FileName: Column<SocialPostMediaRow>;
    MediaType: Column<SocialPostMediaRow>;
    DisplayOrder: Column<SocialPostMediaRow>;
}

export class SocialPostMediaColumns extends ColumnsBase<SocialPostMediaRow> {
    static readonly columnsKey = 'Communication.SocialPostMedia';
    static readonly Fields = fieldsProxy<SocialPostMediaColumns>();
}

[SocialMediaType]; // referenced types