import { ServiceRequest } from "@serenity-is/corelib";
import { TaskStatus } from "./TaskStatus";

export interface TaskUpdateStatusRequest extends ServiceRequest {
    TaskId?: number;
    NewStatus?: TaskStatus;
}