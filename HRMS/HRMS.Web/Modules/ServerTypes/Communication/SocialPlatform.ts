import { registerEnum } from "@serenity-is/corelib";

export enum SocialPlatform {
    Facebook = 1,
    Instagram = 2,
    LinkedIn = 3
}
registerEnum(SocialPlatform, 'HRMS.Communication.SocialPlatform');