import { ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { LeaveDashboardFilterRequest } from "./LeaveDashboardFilterRequest";
import { LeaveDashboardStatsResponse } from "./LeaveDashboardStatsResponse";
import { LeaveTrendResponse } from "./LeaveTrendResponse";

export namespace LeaveDashboardService {
    export const baseUrl = 'Operations/LeaveDashboard';

    export declare function GetStats(request: LeaveDashboardFilterRequest, onSuccess?: (response: LeaveDashboardStatsResponse) => void, opt?: ServiceOptions<any>): PromiseLike<LeaveDashboardStatsResponse>;
    export declare function GetMonthlyTrend(request: LeaveDashboardFilterRequest, onSuccess?: (response: LeaveTrendResponse) => void, opt?: ServiceOptions<any>): PromiseLike<LeaveTrendResponse>;

    export const Methods = {
        GetStats: "Operations/LeaveDashboard/GetStats",
        GetMonthlyTrend: "Operations/LeaveDashboard/GetMonthlyTrend"
    } as const;

    [
        'GetStats',
        'GetMonthlyTrend'
    ].forEach(x => {
        (<any>LeaveDashboardService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}