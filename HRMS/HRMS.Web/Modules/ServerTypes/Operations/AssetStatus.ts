import { registerEnum } from "@serenity-is/corelib";

export enum AssetStatus {
    Available = 1,
    In_Use = 2,
    In_Repair = 3,
    Retired = 4,
    Lost_Stolen = 5
}
registerEnum(AssetStatus, 'HRMS.Operations.AssetStatus');