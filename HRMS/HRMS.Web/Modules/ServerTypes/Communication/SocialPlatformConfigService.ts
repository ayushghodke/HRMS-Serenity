import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { SocialPlatformConfigRow } from "./SocialPlatformConfigRow";

export namespace SocialPlatformConfigService {
    export const baseUrl = 'Communication/SocialPlatformConfig';

    export declare function Create(request: SaveRequest<SocialPlatformConfigRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<SocialPlatformConfigRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<SocialPlatformConfigRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<SocialPlatformConfigRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<SocialPlatformConfigRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<SocialPlatformConfigRow>>;

    export const Methods = {
        Create: "Communication/SocialPlatformConfig/Create",
        Update: "Communication/SocialPlatformConfig/Update",
        Delete: "Communication/SocialPlatformConfig/Delete",
        Retrieve: "Communication/SocialPlatformConfig/Retrieve",
        List: "Communication/SocialPlatformConfig/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>SocialPlatformConfigService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}