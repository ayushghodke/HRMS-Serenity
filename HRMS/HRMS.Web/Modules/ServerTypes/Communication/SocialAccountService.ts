import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { SocialAccountRow } from "./SocialAccountRow";

export namespace SocialAccountService {
    export const baseUrl = 'Communication/SocialAccount';

    export declare function Create(request: SaveRequest<SocialAccountRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<SocialAccountRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<SocialAccountRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<SocialAccountRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<SocialAccountRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<SocialAccountRow>>;

    export const Methods = {
        Create: "Communication/SocialAccount/Create",
        Update: "Communication/SocialAccount/Update",
        Delete: "Communication/SocialAccount/Delete",
        Retrieve: "Communication/SocialAccount/Retrieve",
        List: "Communication/SocialAccount/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>SocialAccountService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}
