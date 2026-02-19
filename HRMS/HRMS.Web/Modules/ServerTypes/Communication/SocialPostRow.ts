import { fieldsProxy } from "@serenity-is/corelib";
import { SocialPlatform } from "./SocialPlatform";
import { SocialPostMediaRow } from "./SocialPostMediaRow";
import { SocialPostStatus } from "./SocialPostStatus";
import { SocialPostType } from "./SocialPostType";

export interface SocialPostRow {
    SocialPostId?: number;
    SocialAccountId?: number;
    SocialAccountName?: string;
    SocialAccountPlatform?: SocialPlatform;
    Title?: string;
    Content?: string;
    PostType?: SocialPostType;
    Status?: SocialPostStatus;
    ScheduledDate?: string;
    PublishedDate?: string;
    ExternalPostId?: string;
    ErrorMessage?: string;
    MediaList?: SocialPostMediaRow[];
    InsertUserId?: number;
    InsertDate?: string;
    UpdateUserId?: number;
    UpdateDate?: string;
}

export abstract class SocialPostRow {
    static readonly idProperty = 'SocialPostId';
    static readonly nameProperty = 'Title';
    static readonly localTextPrefix = 'Communication.SocialPost';
    static readonly deletePermission = 'HumanResources';
    static readonly insertPermission = 'HumanResources';
    static readonly readPermission = 'HumanResources';
    static readonly updatePermission = 'HumanResources';

    static readonly Fields = fieldsProxy<SocialPostRow>();
}