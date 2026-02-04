import { registerEnum } from "@serenity-is/corelib";

export enum AssetType {
    Laptop = 1,
    Desktop = 2,
    Mobile = 3,
    Tablet = 4,
    Monitor = 5,
    Furniture = 6,
    Vehicle = 7,
    Other = 99
}
registerEnum(AssetType, 'HRMS.Operations.AssetType');