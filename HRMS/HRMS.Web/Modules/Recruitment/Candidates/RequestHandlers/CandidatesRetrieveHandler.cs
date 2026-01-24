using MyRow = HRMS.Recruitment.CandidatesRow;

namespace HRMS.Recruitment;

public interface ICandidatesRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class CandidatesRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    ICandidatesRetrieveHandler
{
}