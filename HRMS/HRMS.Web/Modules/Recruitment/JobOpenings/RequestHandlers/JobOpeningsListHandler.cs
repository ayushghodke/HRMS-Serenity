using MyRow = HRMS.Recruitment.JobOpeningsRow;

namespace HRMS.Recruitment;

public interface IJobOpeningsListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> { }

public class JobOpeningsListHandler(IRequestContext context) :
    ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IJobOpeningsListHandler
{
}
