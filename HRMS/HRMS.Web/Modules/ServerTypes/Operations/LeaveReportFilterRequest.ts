import { ServiceRequest } from "@serenity-is/corelib";

export interface LeaveReportFilterRequest extends ServiceRequest {
    EmployeeId?: number;
    DepartmentId?: number;
    LeaveTypeId?: number;
    DateFrom?: string;
    DateTo?: string;
}