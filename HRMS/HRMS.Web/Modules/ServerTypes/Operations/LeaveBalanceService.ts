import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, ServiceRequest, serviceRequest, ServiceResponse } from "@serenity-is/corelib";
import { LeaveBalanceRow } from "./LeaveBalanceRow";
import { YearEndProcessingRequest } from "./YearEndProcessingRequest";

export namespace LeaveBalanceService {
    export const baseUrl = 'Operations/LeaveBalance';

    export declare function Create(request: SaveRequest<LeaveBalanceRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<LeaveBalanceRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<LeaveBalanceRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<LeaveBalanceRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<LeaveBalanceRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<LeaveBalanceRow>>;
    export declare function RecalculateAllBalances(request: ServiceRequest, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function RunYearEndProcessing(request: YearEndProcessingRequest, onSuccess?: (response: ServiceResponse) => void, opt?: ServiceOptions<any>): PromiseLike<ServiceResponse>;

    export const Methods = {
        Create: "Operations/LeaveBalance/Create",
        Update: "Operations/LeaveBalance/Update",
        Delete: "Operations/LeaveBalance/Delete",
        Retrieve: "Operations/LeaveBalance/Retrieve",
        List: "Operations/LeaveBalance/List",
        RecalculateAllBalances: "Operations/LeaveBalance/RecalculateAllBalances",
        RunYearEndProcessing: "Operations/LeaveBalance/RunYearEndProcessing"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List',
        'RecalculateAllBalances',
        'RunYearEndProcessing'
    ].forEach(x => {
        (<any>LeaveBalanceService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}