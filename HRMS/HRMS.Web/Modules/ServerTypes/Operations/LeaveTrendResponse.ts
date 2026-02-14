import { ServiceResponse } from "@serenity-is/corelib";

export interface LeaveTrendResponse extends ServiceResponse {
    Labels?: string[];
    Values?: number[];
}