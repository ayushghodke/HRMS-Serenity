import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { InterviewsRow } from "./InterviewsRow";

export namespace InterviewsService {
    export const baseUrl = 'Recruitment/Interviews';

    export declare function Create(request: SaveRequest<InterviewsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<InterviewsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<InterviewsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<InterviewsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<InterviewsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<InterviewsRow>>;

    export const Methods = {
        Create: "Recruitment/Interviews/Create",
        Update: "Recruitment/Interviews/Update",
        Delete: "Recruitment/Interviews/Delete",
        Retrieve: "Recruitment/Interviews/Retrieve",
        List: "Recruitment/Interviews/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>InterviewsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}