import { registerEnum } from "@serenity-is/corelib";

export enum SocialMediaType {
    Image = 1,
    Video = 2
}
registerEnum(SocialMediaType, 'HRMS.Communication.SocialMediaType');