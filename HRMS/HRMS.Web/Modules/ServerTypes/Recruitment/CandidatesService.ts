import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { CandidatesRow } from "./CandidatesRow";

export namespace CandidatesService {
    export const baseUrl = 'Recruitment/Candidates';

    export declare function Create(request: SaveRequest<CandidatesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<CandidatesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<CandidatesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<CandidatesRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<CandidatesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<CandidatesRow>>;

    export const Methods = {
        Create: "Recruitment/Candidates/Create",
        Update: "Recruitment/Candidates/Update",
        Delete: "Recruitment/Candidates/Delete",
        Retrieve: "Recruitment/Candidates/Retrieve",
        List: "Recruitment/Candidates/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>CandidatesService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}