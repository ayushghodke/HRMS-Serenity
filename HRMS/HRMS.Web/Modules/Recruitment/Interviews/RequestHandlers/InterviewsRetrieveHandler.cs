using MyRow = HRMS.Recruitment.InterviewsRow;

namespace HRMS.Recruitment;

public interface IInterviewsRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class InterviewsRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IInterviewsRetrieveHandler
{
}
