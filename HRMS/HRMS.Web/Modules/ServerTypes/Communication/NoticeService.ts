import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { NoticeRow } from "./NoticeRow";

export namespace NoticeService {
    export const baseUrl = 'Communication/Notice';

    export declare function Create(request: SaveRequest<NoticeRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<NoticeRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<NoticeRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<NoticeRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<NoticeRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<NoticeRow>>;

    export const Methods = {
        Create: "Communication/Notice/Create",
        Update: "Communication/Notice/Update",
        Delete: "Communication/Notice/Delete",
        Retrieve: "Communication/Notice/Retrieve",
        List: "Communication/Notice/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>NoticeService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}