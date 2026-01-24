import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { CandidatesRow } from "./CandidatesRow";
import { CandidateStatus } from "./CandidateStatus";

export interface CandidatesColumns {
    CandidateId: Column<CandidatesRow>;
    JobTitle: Column<CandidatesRow>;
    FirstName: Column<CandidatesRow>;
    LastName: Column<CandidatesRow>;
    Email: Column<CandidatesRow>;
    Mobile: Column<CandidatesRow>;
    ResumePath: Column<CandidatesRow>;
    Status: Column<CandidatesRow>;
    AppliedDate: Column<CandidatesRow>;
}

export class CandidatesColumns extends ColumnsBase<CandidatesRow> {
    static readonly columnsKey = 'Recruitment.Candidates';
    static readonly Fields = fieldsProxy<CandidatesColumns>();
}

[CandidateStatus]; // referenced types