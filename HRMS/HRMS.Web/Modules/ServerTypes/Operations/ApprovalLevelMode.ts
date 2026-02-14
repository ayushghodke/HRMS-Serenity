import { registerEnum } from "@serenity-is/corelib";

export enum ApprovalLevelMode {
    Single = 1,
    FixedTwoLevel = 2
}
registerEnum(ApprovalLevelMode, 'HRMS.Operations.ApprovalLevelMode');