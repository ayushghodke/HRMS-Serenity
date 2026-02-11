import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { SalaryGradeRow } from "./SalaryGradeRow";

export namespace SalaryGradeService {
    export const baseUrl = 'Operations/SalaryGrade';

    export declare function Create(request: SaveRequest<SalaryGradeRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<SalaryGradeRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<SalaryGradeRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<SalaryGradeRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<SalaryGradeRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<SalaryGradeRow>>;

    export const Methods = {
        Create: "Operations/SalaryGrade/Create",
        Update: "Operations/SalaryGrade/Update",
        Delete: "Operations/SalaryGrade/Delete",
        Retrieve: "Operations/SalaryGrade/Retrieve",
        List: "Operations/SalaryGrade/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>SalaryGradeService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}