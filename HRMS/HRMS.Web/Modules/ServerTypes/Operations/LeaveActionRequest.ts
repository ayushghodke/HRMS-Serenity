import { ServiceRequest } from "@serenity-is/corelib";

export interface LeaveActionRequest extends ServiceRequest {
    LeaveId?: number;
    Remarks?: string;
}