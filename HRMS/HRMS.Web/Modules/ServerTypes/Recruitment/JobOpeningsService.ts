import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { JobOpeningsRow } from "./JobOpeningsRow";

export namespace JobOpeningsService {
    export const baseUrl = 'Recruitment/JobOpenings';

    export declare function Create(request: SaveRequest<JobOpeningsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<JobOpeningsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<JobOpeningsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<JobOpeningsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<JobOpeningsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<JobOpeningsRow>>;

    export const Methods = {
        Create: "Recruitment/JobOpenings/Create",
        Update: "Recruitment/JobOpenings/Update",
        Delete: "Recruitment/JobOpenings/Delete",
        Retrieve: "Recruitment/JobOpenings/Retrieve",
        List: "Recruitment/JobOpenings/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>JobOpeningsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}