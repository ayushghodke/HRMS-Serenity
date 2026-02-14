import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { LeavePolicyRow } from "./LeavePolicyRow";

export namespace LeavePolicyService {
    export const baseUrl = 'Operations/LeavePolicy';

    export declare function Create(request: SaveRequest<LeavePolicyRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<LeavePolicyRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<LeavePolicyRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<LeavePolicyRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<LeavePolicyRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<LeavePolicyRow>>;

    export const Methods = {
        Create: "Operations/LeavePolicy/Create",
        Update: "Operations/LeavePolicy/Update",
        Delete: "Operations/LeavePolicy/Delete",
        Retrieve: "Operations/LeavePolicy/Retrieve",
        List: "Operations/LeavePolicy/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>LeavePolicyService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}