import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { NoticePriority } from "./NoticePriority";
import { NoticeRow } from "./NoticeRow";

export interface NoticeColumns {
    NoticeId: Column<NoticeRow>;
    Title: Column<NoticeRow>;
    Priority: Column<NoticeRow>;
    PublishDate: Column<NoticeRow>;
    ExpiryDate: Column<NoticeRow>;
    IsActive: Column<NoticeRow>;
}

export class NoticeColumns extends ColumnsBase<NoticeRow> {
    static readonly columnsKey = 'Communication.Notice';
    static readonly Fields = fieldsProxy<NoticeColumns>();
}

[NoticePriority]; // referenced types