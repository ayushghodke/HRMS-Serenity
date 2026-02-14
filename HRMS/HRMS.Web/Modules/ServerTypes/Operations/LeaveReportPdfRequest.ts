import { ServiceRequest } from "@serenity-is/corelib";
import { LeaveReportFilterRequest } from "./LeaveReportFilterRequest";

export interface LeaveReportPdfRequest extends ServiceRequest {
    ReportType?: string;
    Filter?: LeaveReportFilterRequest;
}