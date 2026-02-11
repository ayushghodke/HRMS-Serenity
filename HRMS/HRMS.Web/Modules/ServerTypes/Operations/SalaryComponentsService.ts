import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { SalaryComponentsRow } from "./SalaryComponentsRow";

export namespace SalaryComponentsService {
    export const baseUrl = 'Operations/SalaryComponents';

    export declare function Create(request: SaveRequest<SalaryComponentsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<SalaryComponentsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<SalaryComponentsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<SalaryComponentsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<SalaryComponentsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<SalaryComponentsRow>>;

    export const Methods = {
        Create: "Operations/SalaryComponents/Create",
        Update: "Operations/SalaryComponents/Update",
        Delete: "Operations/SalaryComponents/Delete",
        Retrieve: "Operations/SalaryComponents/Retrieve",
        List: "Operations/SalaryComponents/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>SalaryComponentsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}