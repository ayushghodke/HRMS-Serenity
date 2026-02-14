import { ServiceRequest } from "@serenity-is/corelib";

export interface YearEndProcessingRequest extends ServiceRequest {
    Year?: number;
}