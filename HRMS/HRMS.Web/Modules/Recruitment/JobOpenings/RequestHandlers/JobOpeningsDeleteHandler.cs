using MyRow = HRMS.Recruitment.JobOpeningsRow;

namespace HRMS.Recruitment;

public interface IJobOpeningsDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> { }

public class JobOpeningsDeleteHandler(IRequestContext context) :
    DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>(context),
    IJobOpeningsDeleteHandler
{
}
