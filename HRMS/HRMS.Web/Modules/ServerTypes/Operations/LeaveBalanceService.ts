import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { LeaveBalanceRow } from "./LeaveBalanceRow";

export namespace LeaveBalanceService {
    export const baseUrl = 'Operations/LeaveBalance';

    export declare function Create(request: SaveRequest<LeaveBalanceRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<LeaveBalanceRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<LeaveBalanceRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<LeaveBalanceRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<LeaveBalanceRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<LeaveBalanceRow>>;

    export const Methods = {
        Create: "Operations/LeaveBalance/Create",
        Update: "Operations/LeaveBalance/Update",
        Delete: "Operations/LeaveBalance/Delete",
        Retrieve: "Operations/LeaveBalance/Retrieve",
        List: "Operations/LeaveBalance/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>LeaveBalanceService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}