import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { EmployeeSalaryRow } from "./EmployeeSalaryRow";
import { SalaryStructureRequest } from "./SalaryStructureRequest";

export namespace EmployeeSalaryService {
    export const baseUrl = 'HR/EmployeeSalary';

    export declare function Create(request: SaveRequest<EmployeeSalaryRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<EmployeeSalaryRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<EmployeeSalaryRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<EmployeeSalaryRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<EmployeeSalaryRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<EmployeeSalaryRow>>;
    export declare function GetSalaryStructure(request: SalaryStructureRequest, onSuccess?: (response: EmployeeSalaryRow) => void, opt?: ServiceOptions<any>): PromiseLike<EmployeeSalaryRow>;

    export const Methods = {
        Create: "HR/EmployeeSalary/Create",
        Update: "HR/EmployeeSalary/Update",
        Delete: "HR/EmployeeSalary/Delete",
        Retrieve: "HR/EmployeeSalary/Retrieve",
        List: "HR/EmployeeSalary/List",
        GetSalaryStructure: "HR/EmployeeSalary/GetSalaryStructure"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List',
        'GetSalaryStructure'
    ].forEach(x => {
        (<any>EmployeeSalaryService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}