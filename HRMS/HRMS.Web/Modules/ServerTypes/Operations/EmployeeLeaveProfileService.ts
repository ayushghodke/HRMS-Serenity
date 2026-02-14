import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { EmployeeLeaveProfileRow } from "./EmployeeLeaveProfileRow";

export namespace EmployeeLeaveProfileService {
    export const baseUrl = 'Operations/EmployeeLeaveProfile';

    export declare function Create(request: SaveRequest<EmployeeLeaveProfileRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<EmployeeLeaveProfileRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<EmployeeLeaveProfileRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<EmployeeLeaveProfileRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<EmployeeLeaveProfileRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<EmployeeLeaveProfileRow>>;

    export const Methods = {
        Create: "Operations/EmployeeLeaveProfile/Create",
        Update: "Operations/EmployeeLeaveProfile/Update",
        Delete: "Operations/EmployeeLeaveProfile/Delete",
        Retrieve: "Operations/EmployeeLeaveProfile/Retrieve",
        List: "Operations/EmployeeLeaveProfile/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>EmployeeLeaveProfileService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}