import { registerEnum } from "@serenity-is/corelib";

export enum SocialPostStatus {
    Draft = 1,
    Scheduled = 2,
    Published = 3,
    Failed = 4
}
registerEnum(SocialPostStatus, 'HRMS.Communication.SocialPostStatus');