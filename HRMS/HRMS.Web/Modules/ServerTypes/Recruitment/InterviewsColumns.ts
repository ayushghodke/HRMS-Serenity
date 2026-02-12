import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { InterviewRound } from "./InterviewRound";
import { InterviewsRow } from "./InterviewsRow";

export interface InterviewsColumns {
    InterviewId: Column<InterviewsRow>;
    CandidateName: Column<InterviewsRow>;
    InterviewerName: Column<InterviewsRow>;
    InterviewDate: Column<InterviewsRow>;
    Round: Column<InterviewsRow>;
    Rating: Column<InterviewsRow>;
    IsCompleted: Column<InterviewsRow>;
    CompletedOn: Column<InterviewsRow>;
    Comments: Column<InterviewsRow>;
}

export class InterviewsColumns extends ColumnsBase<InterviewsRow> {
    static readonly columnsKey = 'Recruitment.Interviews';
    static readonly Fields = fieldsProxy<InterviewsColumns>();
}

[InterviewRound]; // referenced types