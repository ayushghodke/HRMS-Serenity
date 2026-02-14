import { ListResponse, ServiceOptions, serviceRequest, ServiceResponse } from "@serenity-is/corelib";
import { DepartmentLeaveSummaryRow } from "./DepartmentLeaveSummaryRow";
import { LeaveReportFilterRequest } from "./LeaveReportFilterRequest";
import { LeaveReportPdfRequest } from "./LeaveReportPdfRequest";
import { LeaveReportRow } from "./LeaveReportRow";
import { MonthlyLeaveSummaryRow } from "./MonthlyLeaveSummaryRow";

export namespace LeaveReportsService {
    export const baseUrl = 'Operations/LeaveReports';

    export declare function LeaveHistory(request: LeaveReportFilterRequest, onSuccess?: (response: ListResponse<LeaveReportRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<LeaveReportRow>>;
    export declare function DepartmentSummary(request: LeaveReportFilterRequest, onSuccess?: (response: ListResponse<DepartmentLeaveSummaryRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<DepartmentLeaveSummaryRow>>;
    export declare function MonthlySummary(request: LeaveReportFilterRequest, onSuccess?: (response: ListResponse<MonthlyLeaveSummaryRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<MonthlyLeaveSummaryRow>>;
    export declare function ExportPdf(request: LeaveReportPdfRequest, onSuccess?: (response: ServiceResponse) => void, opt?: ServiceOptions<any>): PromiseLike<ServiceResponse>;

    export const Methods = {
        LeaveHistory: "Operations/LeaveReports/LeaveHistory",
        DepartmentSummary: "Operations/LeaveReports/DepartmentSummary",
        MonthlySummary: "Operations/LeaveReports/MonthlySummary",
        ExportPdf: "Operations/LeaveReports/ExportPdf"
    } as const;

    [
        'LeaveHistory',
        'DepartmentSummary',
        'MonthlySummary',
        'ExportPdf'
    ].forEach(x => {
        (<any>LeaveReportsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}