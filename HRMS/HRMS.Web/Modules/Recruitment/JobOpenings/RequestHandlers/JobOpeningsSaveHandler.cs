using MyRow = HRMS.Recruitment.JobOpeningsRow;

namespace HRMS.Recruitment;

public interface IJobOpeningsSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class JobOpeningsSaveHandler(IRequestContext context) :
    SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IJobOpeningsSaveHandler
{
}
