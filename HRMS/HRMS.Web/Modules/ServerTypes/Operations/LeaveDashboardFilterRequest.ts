import { ServiceRequest } from "@serenity-is/corelib";

export interface LeaveDashboardFilterRequest extends ServiceRequest {
    Branch?: string;
    DepartmentId?: number;
    EmployeeId?: number;
    LeaveTypeId?: number;
    DateFrom?: string;
    DateTo?: string;
}