import { fieldsProxy } from "@serenity-is/corelib";
import { SocialPlatform } from "./SocialPlatform";

export interface SocialPlatformConfigRow {
    SocialPlatformConfigId?: number;
    Platform?: SocialPlatform;
    ClientId?: string;
    ClientSecret?: string;
    RedirectUri?: string;
    IsEnabled?: boolean;
    InsertUserId?: number;
    InsertDate?: string;
    UpdateUserId?: number;
    UpdateDate?: string;
}

export abstract class SocialPlatformConfigRow {
    static readonly idProperty = 'SocialPlatformConfigId';
    static readonly nameProperty = 'ClientId';
    static readonly localTextPrefix = 'Communication.SocialPlatformConfig';
    static readonly deletePermission = 'Administration';
    static readonly insertPermission = 'Administration';
    static readonly readPermission = 'Administration';
    static readonly updatePermission = 'Administration';

    static readonly Fields = fieldsProxy<SocialPlatformConfigRow>();
}