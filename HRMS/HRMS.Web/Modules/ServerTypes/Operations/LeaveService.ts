import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { LeaveRow } from "./LeaveRow";

export namespace LeaveService {
    export const baseUrl = 'Operations/Leave';

    export declare function Create(request: SaveRequest<LeaveRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<LeaveRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<LeaveRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<LeaveRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<LeaveRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<LeaveRow>>;

    export const Methods = {
        Create: "Operations/Leave/Create",
        Update: "Operations/Leave/Update",
        Delete: "Operations/Leave/Delete",
        Retrieve: "Operations/Leave/Retrieve",
        List: "Operations/Leave/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>LeaveService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}