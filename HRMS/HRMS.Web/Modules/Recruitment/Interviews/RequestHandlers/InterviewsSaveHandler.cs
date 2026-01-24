using MyRow = HRMS.Recruitment.InterviewsRow;

namespace HRMS.Recruitment;

public interface IInterviewsSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class InterviewsSaveHandler(IRequestContext context) :
    SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IInterviewsSaveHandler
{
}
