import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { SocialPlatform } from "./SocialPlatform";

export interface SocialAccountRow {
    SocialAccountId?: number;
    Platform?: SocialPlatform;
    AccountName?: string;
    ProfileUrl?: string;
    AccessToken?: string;
    RefreshToken?: string;
    TokenExpiry?: string;
    IsActive?: boolean;
    ConnectedDate?: string;
    InsertUserId?: number;
    InsertDate?: string;
    UpdateUserId?: number;
    UpdateDate?: string;
}

export abstract class SocialAccountRow {
    static readonly idProperty = 'SocialAccountId';
    static readonly nameProperty = 'AccountName';
    static readonly localTextPrefix = 'Communication.SocialAccount';
    static readonly lookupKey = 'Communication.SocialAccount';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<SocialAccountRow>('Communication.SocialAccount') }
    static async getLookupAsync() { return getLookupAsync<SocialAccountRow>('Communication.SocialAccount') }

    static readonly deletePermission = 'HumanResources';
    static readonly insertPermission = 'HumanResources';
    static readonly readPermission = 'HumanResources';
    static readonly updatePermission = 'HumanResources';

    static readonly Fields = fieldsProxy<SocialAccountRow>();
}