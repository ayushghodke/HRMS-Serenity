import { fieldsProxy } from "@serenity-is/corelib";
import { SocialMediaType } from "./SocialMediaType";

export interface SocialPostMediaRow {
    SocialPostMediaId?: number;
    SocialPostId?: number;
    FileName?: string;
    MediaType?: SocialMediaType;
    DisplayOrder?: number;
}

export abstract class SocialPostMediaRow {
    static readonly idProperty = 'SocialPostMediaId';
    static readonly nameProperty = 'FileName';
    static readonly localTextPrefix = 'Communication.SocialPostMedia';
    static readonly deletePermission = 'HumanResources';
    static readonly insertPermission = 'HumanResources';
    static readonly readPermission = 'HumanResources';
    static readonly updatePermission = 'HumanResources';

    static readonly Fields = fieldsProxy<SocialPostMediaRow>();
}
