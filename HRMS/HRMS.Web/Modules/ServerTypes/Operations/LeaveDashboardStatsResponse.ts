import { ServiceResponse } from "@serenity-is/corelib";

export interface LeaveDashboardStatsResponse extends ServiceResponse {
    TotalAllocated?: number;
    LeaveTaken?: number;
    PendingApproval?: number;
    RemainingBalance?: number;
    LOPDays?: number;
    UpcomingLeaves?: number;
    EmployeesOnLeaveToday?: number;
}