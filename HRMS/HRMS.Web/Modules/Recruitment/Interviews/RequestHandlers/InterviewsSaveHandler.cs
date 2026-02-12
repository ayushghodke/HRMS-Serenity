using MyRow = HRMS.Recruitment.InterviewsRow;
using CandidateRow = HRMS.Recruitment.CandidatesRow;

namespace HRMS.Recruitment;

public interface IInterviewsSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class InterviewsSaveHandler(IRequestContext context) :
    SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IInterviewsSaveHandler
{
    protected override void BeforeSave()
    {
        base.BeforeSave();

        // Sync Status -> IsCompleted
        // If Status is Interviewed, mark as Completed.
        // Otherwise (Scheduled, Cancelled), mark as Not Completed.
        // We check Row.Status (new value) and fall back to Old.Status (existing value) for updates.
        var status = Row.Status ?? (IsCreate ? InterviewStatus.Scheduled : Old.Status ?? InterviewStatus.Scheduled);

        if (status == InterviewStatus.Interviewed)
            Row.IsCompleted = true;
        else
            Row.IsCompleted = false;

        if (Row.IsCompleted == true)
            Row.CompletedOn = Row.CompletedOn ?? DateTime.Now;
        else
            Row.CompletedOn = null;
    }

    protected override void AfterSave()
    {
        base.AfterSave();

        if (Row.CandidateId == null)
            return;

        var candidate = Connection.TryById<CandidateRow>(Row.CandidateId.Value);
        if (candidate == null)
            return;

        var hasCompletedInterview = Connection.TryFirst<MyRow>(
            MyRow.Fields.CandidateId == Row.CandidateId.Value &
            MyRow.Fields.IsCompleted == 1) != null;

        var nextStatus = candidate.Status;

        if (hasCompletedInterview)
        {
            if (candidate.Status is CandidateStatus.Applied or CandidateStatus.Shortlisted or CandidateStatus.Interviewed)
                nextStatus = CandidateStatus.Interviewed;
        }
        else
        {
            if (candidate.Status is CandidateStatus.Applied or CandidateStatus.Shortlisted or CandidateStatus.Interviewed)
                nextStatus = CandidateStatus.Shortlisted;
        }

        if (nextStatus != candidate.Status)
        {
            Connection.UpdateById(new CandidateRow
            {
                CandidateId = Row.CandidateId,
                Status = nextStatus
            });
        }
    }
}
