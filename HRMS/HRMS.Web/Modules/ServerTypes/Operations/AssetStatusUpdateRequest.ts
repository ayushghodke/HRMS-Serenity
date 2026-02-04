import { ServiceRequest } from "@serenity-is/corelib";

export interface AssetStatusUpdateRequest extends ServiceRequest {
    AssetId?: number;
    NewStatus?: number;
}