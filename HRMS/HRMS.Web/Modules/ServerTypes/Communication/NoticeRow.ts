import { fieldsProxy } from "@serenity-is/corelib";
import { NoticePriority } from "./NoticePriority";

export interface NoticeRow {
    NoticeId?: number;
    Title?: string;
    Description?: string;
    Priority?: NoticePriority;
    PublishDate?: string;
    ExpiryDate?: string;
    IsActive?: boolean;
}

export abstract class NoticeRow {
    static readonly idProperty = 'NoticeId';
    static readonly nameProperty = 'Title';
    static readonly localTextPrefix = 'Communication.Notice';
    static readonly deletePermission = 'HumanResources';
    static readonly insertPermission = 'HumanResources';
    static readonly readPermission = '*';
    static readonly updatePermission = 'HumanResources';

    static readonly Fields = fieldsProxy<NoticeRow>();
}