import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { HolidayRow } from "./HolidayRow";

export namespace HolidayService {
    export const baseUrl = 'Operations/Holiday';

    export declare function Create(request: SaveRequest<HolidayRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<HolidayRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<HolidayRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<HolidayRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<HolidayRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<HolidayRow>>;

    export const Methods = {
        Create: "Operations/Holiday/Create",
        Update: "Operations/Holiday/Update",
        Delete: "Operations/Holiday/Delete",
        Retrieve: "Operations/Holiday/Retrieve",
        List: "Operations/Holiday/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>HolidayService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}