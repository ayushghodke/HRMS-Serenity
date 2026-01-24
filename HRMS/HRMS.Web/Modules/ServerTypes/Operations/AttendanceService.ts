import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest, ServiceResponse } from "@serenity-is/corelib";
import { AttendanceRow } from "./AttendanceRow";

export namespace AttendanceService {
    export const baseUrl = 'Operations/Attendance';

    export declare function Create(request: SaveRequest<AttendanceRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<AttendanceRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<AttendanceRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<AttendanceRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<AttendanceRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<AttendanceRow>>;
    export declare function PunchIn(request: SaveRequest<AttendanceRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function PunchOut(request: SaveRequest<AttendanceRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Approve(request: SaveRequest<AttendanceRow>, onSuccess?: (response: ServiceResponse) => void, opt?: ServiceOptions<any>): PromiseLike<ServiceResponse>;

    export const Methods = {
        Create: "Operations/Attendance/Create",
        Update: "Operations/Attendance/Update",
        Delete: "Operations/Attendance/Delete",
        Retrieve: "Operations/Attendance/Retrieve",
        List: "Operations/Attendance/List",
        PunchIn: "Operations/Attendance/PunchIn",
        PunchOut: "Operations/Attendance/PunchOut",
        Approve: "Operations/Attendance/Approve"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List',
        'PunchIn',
        'PunchOut',
        'Approve'
    ].forEach(x => {
        (<any>AttendanceService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}