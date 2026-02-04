import { ServiceRequest } from "@serenity-is/corelib";

export interface UpcomingCelebrationsRequest extends ServiceRequest {
    Days?: number;
}