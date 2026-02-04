import { ServiceResponse } from "@serenity-is/corelib";
import { EmployeeRow } from "./EmployeeRow";

export interface UpcomingCelebrationsResponse extends ServiceResponse {
    Birthdays?: EmployeeRow[];
    Anniversaries?: EmployeeRow[];
}