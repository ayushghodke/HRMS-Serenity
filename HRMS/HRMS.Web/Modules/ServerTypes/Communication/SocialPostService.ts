import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { SocialPostRow } from "./SocialPostRow";

export namespace SocialPostService {
    export const baseUrl = 'Communication/SocialPost';

    export declare function Create(request: SaveRequest<SocialPostRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<SocialPostRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<SocialPostRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<SocialPostRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<SocialPostRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<SocialPostRow>>;

    export const Methods = {
        Create: "Communication/SocialPost/Create",
        Update: "Communication/SocialPost/Update",
        Delete: "Communication/SocialPost/Delete",
        Retrieve: "Communication/SocialPost/Retrieve",
        List: "Communication/SocialPost/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>SocialPostService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}
