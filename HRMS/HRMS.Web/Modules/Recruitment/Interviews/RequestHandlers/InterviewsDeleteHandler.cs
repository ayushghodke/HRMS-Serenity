using MyRow = HRMS.Recruitment.InterviewsRow;

namespace HRMS.Recruitment;

public interface IInterviewsDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> { }

public class InterviewsDeleteHandler(IRequestContext context) :
    DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>(context),
    IInterviewsDeleteHandler
{
}
