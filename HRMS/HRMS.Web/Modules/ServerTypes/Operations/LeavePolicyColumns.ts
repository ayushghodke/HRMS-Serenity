import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { ApprovalLevelMode } from "./ApprovalLevelMode";
import { LeavePolicyRow } from "./LeavePolicyRow";

export interface LeavePolicyColumns {
    LeavePolicyId: Column<LeavePolicyRow>;
    PolicyName: Column<LeavePolicyRow>;
    ApplicableFromDate: Column<LeavePolicyRow>;
    Branch: Column<LeavePolicyRow>;
    DepartmentName: Column<LeavePolicyRow>;
    MaxConsecutiveLeavesAllowed: Column<LeavePolicyRow>;
    ApprovalLevels: Column<LeavePolicyRow>;
    PayrollCutoffDay: Column<LeavePolicyRow>;
    Status: Column<LeavePolicyRow>;
}

export class LeavePolicyColumns extends ColumnsBase<LeavePolicyRow> {
    static readonly columnsKey = 'Operations.LeavePolicy';
    static readonly Fields = fieldsProxy<LeavePolicyColumns>();
}

[ApprovalLevelMode]; // referenced types