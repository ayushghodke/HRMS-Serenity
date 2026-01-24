import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { PayrollRow } from "./PayrollRow";

export namespace PayrollService {
    export const baseUrl = 'Operations/Payroll';

    export declare function Create(request: SaveRequest<PayrollRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<PayrollRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<PayrollRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<PayrollRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<PayrollRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<PayrollRow>>;

    export const Methods = {
        Create: "Operations/Payroll/Create",
        Update: "Operations/Payroll/Update",
        Delete: "Operations/Payroll/Delete",
        Retrieve: "Operations/Payroll/Retrieve",
        List: "Operations/Payroll/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>PayrollService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}