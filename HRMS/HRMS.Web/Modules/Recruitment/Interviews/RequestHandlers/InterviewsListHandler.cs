using MyRow = HRMS.Recruitment.InterviewsRow;

namespace HRMS.Recruitment;

public interface IInterviewsListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> { }

public class InterviewsListHandler(IRequestContext context) :
    ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IInterviewsListHandler
{
}
