import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { LeaveTypeRow } from "./LeaveTypeRow";

export namespace LeaveTypeService {
    export const baseUrl = 'Operations/LeaveType';

    export declare function Create(request: SaveRequest<LeaveTypeRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<LeaveTypeRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<LeaveTypeRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<LeaveTypeRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<LeaveTypeRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<LeaveTypeRow>>;

    export const Methods = {
        Create: "Operations/LeaveType/Create",
        Update: "Operations/LeaveType/Update",
        Delete: "Operations/LeaveType/Delete",
        Retrieve: "Operations/LeaveType/Retrieve",
        List: "Operations/LeaveType/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>LeaveTypeService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}