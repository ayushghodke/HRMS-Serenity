using MyRow = HRMS.Recruitment.CandidatesRow;

namespace HRMS.Recruitment;

public interface ICandidatesDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> { }

public class CandidatesDeleteHandler(IRequestContext context) :
    DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>(context),
    ICandidatesDeleteHandler
{
}