import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { JobOpeningsRow } from "./JobOpeningsRow";
import { JobOpeningStatus } from "./JobOpeningStatus";

export interface JobOpeningsColumns {
    JobId: Column<JobOpeningsRow>;
    Title: Column<JobOpeningsRow>;
    Description: Column<JobOpeningsRow>;
    DepartmentName: Column<JobOpeningsRow>;
    HiringManagerName: Column<JobOpeningsRow>;
    Status: Column<JobOpeningsRow>;
    CreatedDate: Column<JobOpeningsRow>;
}

export class JobOpeningsColumns extends ColumnsBase<JobOpeningsRow> {
    static readonly columnsKey = 'Recruitment.JobOpenings';
    static readonly Fields = fieldsProxy<JobOpeningsColumns>();
}

[JobOpeningStatus]; // referenced types