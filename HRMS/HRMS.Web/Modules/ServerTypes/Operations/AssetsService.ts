import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { AssetsRow } from "./AssetsRow";
import { AssetStatusUpdateRequest } from "./AssetStatusUpdateRequest";

export namespace AssetsService {
    export const baseUrl = 'Operations/Assets';

    export declare function Create(request: SaveRequest<AssetsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<AssetsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<AssetsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<AssetsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<AssetsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<AssetsRow>>;
    export declare function UpdateStatus(request: AssetStatusUpdateRequest, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;

    export const Methods = {
        Create: "Operations/Assets/Create",
        Update: "Operations/Assets/Update",
        Delete: "Operations/Assets/Delete",
        Retrieve: "Operations/Assets/Retrieve",
        List: "Operations/Assets/List",
        UpdateStatus: "Operations/Assets/UpdateStatus"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List',
        'UpdateStatus'
    ].forEach(x => {
        (<any>AssetsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}