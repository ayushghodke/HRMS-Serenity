using MyRow = HRMS.Recruitment.JobOpeningsRow;

namespace HRMS.Recruitment;

public interface IJobOpeningsRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class JobOpeningsRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IJobOpeningsRetrieveHandler
{
}
