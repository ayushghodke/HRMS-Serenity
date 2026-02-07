import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { EmployeeDocsRow } from "./EmployeeDocsRow";

export namespace EmployeeDocsService {
    export const baseUrl = 'HR/EmployeeDocs';

    export declare function Create(request: SaveRequest<EmployeeDocsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<EmployeeDocsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<EmployeeDocsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<EmployeeDocsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<EmployeeDocsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<EmployeeDocsRow>>;

    export const Methods = {
        Create: "HR/EmployeeDocs/Create",
        Update: "HR/EmployeeDocs/Update",
        Delete: "HR/EmployeeDocs/Delete",
        Retrieve: "HR/EmployeeDocs/Retrieve",
        List: "HR/EmployeeDocs/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>EmployeeDocsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}