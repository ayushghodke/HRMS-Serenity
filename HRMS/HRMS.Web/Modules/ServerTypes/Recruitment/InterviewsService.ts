import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest, ServiceResponse } from "@serenity-is/corelib";
import { InterviewsRow } from "./InterviewsRow";
import { MarkInterviewDoneRequest } from "./MarkInterviewDoneRequest";

export namespace InterviewsService {
    export const baseUrl = 'Recruitment/Interviews';

    export declare function Create(request: SaveRequest<InterviewsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<InterviewsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<InterviewsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<InterviewsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<InterviewsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<InterviewsRow>>;
    export declare function MarkDone(request: MarkInterviewDoneRequest, onSuccess?: (response: ServiceResponse) => void, opt?: ServiceOptions<any>): PromiseLike<ServiceResponse>;

    export const Methods = {
        Create: "Recruitment/Interviews/Create",
        Update: "Recruitment/Interviews/Update",
        Delete: "Recruitment/Interviews/Delete",
        Retrieve: "Recruitment/Interviews/Retrieve",
        List: "Recruitment/Interviews/List",
        MarkDone: "Recruitment/Interviews/MarkDone"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List',
        'MarkDone'
    ].forEach(x => {
        (<any>InterviewsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}