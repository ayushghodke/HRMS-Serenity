import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { DesignationRow } from "./DesignationRow";

export namespace DesignationService {
    export const baseUrl = 'HR/Designation';

    export declare function Create(request: SaveRequest<DesignationRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<DesignationRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<DesignationRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<DesignationRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<DesignationRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<DesignationRow>>;

    export const Methods = {
        Create: "HR/Designation/Create",
        Update: "HR/Designation/Update",
        Delete: "HR/Designation/Delete",
        Retrieve: "HR/Designation/Retrieve",
        List: "HR/Designation/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>DesignationService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}