using MyRow = HRMS.Recruitment.CandidatesRow;

namespace HRMS.Recruitment;

public interface ICandidatesListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> { }

public class CandidatesListHandler(IRequestContext context) :
    ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>(context),
    ICandidatesListHandler
{
}