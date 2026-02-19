import { registerEnum } from "@serenity-is/corelib";

export enum SocialPostType {
    Text = 1,
    Image = 2,
    Video = 3,
    Carousel = 4
}
registerEnum(SocialPostType, 'HRMS.Communication.SocialPostType');