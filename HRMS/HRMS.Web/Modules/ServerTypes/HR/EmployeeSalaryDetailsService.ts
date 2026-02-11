import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { EmployeeSalaryDetailsRow } from "./EmployeeSalaryDetailsRow";

export namespace EmployeeSalaryDetailsService {
    export const baseUrl = 'HR/EmployeeSalaryDetails';

    export declare function Create(request: SaveRequest<EmployeeSalaryDetailsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<EmployeeSalaryDetailsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<EmployeeSalaryDetailsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<EmployeeSalaryDetailsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<EmployeeSalaryDetailsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<EmployeeSalaryDetailsRow>>;

    export const Methods = {
        Create: "HR/EmployeeSalaryDetails/Create",
        Update: "HR/EmployeeSalaryDetails/Update",
        Delete: "HR/EmployeeSalaryDetails/Delete",
        Retrieve: "HR/EmployeeSalaryDetails/Retrieve",
        List: "HR/EmployeeSalaryDetails/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>EmployeeSalaryDetailsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}