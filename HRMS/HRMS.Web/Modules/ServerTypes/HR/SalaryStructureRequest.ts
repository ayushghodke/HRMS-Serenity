import { ServiceRequest } from "@serenity-is/corelib";

export interface SalaryStructureRequest extends ServiceRequest {
    EmployeeId?: number;
}