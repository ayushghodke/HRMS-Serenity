import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { LeaveApprovalRow } from "./LeaveApprovalRow";

export namespace LeaveApprovalService {
    export const baseUrl = 'Operations/LeaveApproval';

    export declare function Create(request: SaveRequest<LeaveApprovalRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<LeaveApprovalRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<LeaveApprovalRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<LeaveApprovalRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<LeaveApprovalRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<LeaveApprovalRow>>;

    export const Methods = {
        Create: "Operations/LeaveApproval/Create",
        Update: "Operations/LeaveApproval/Update",
        Delete: "Operations/LeaveApproval/Delete",
        Retrieve: "Operations/LeaveApproval/Retrieve",
        List: "Operations/LeaveApproval/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>LeaveApprovalService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}