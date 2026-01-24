using MyRow = HRMS.Recruitment.CandidatesRow;

namespace HRMS.Recruitment;

public interface ICandidatesSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class CandidatesSaveHandler(IRequestContext context) :
    SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    ICandidatesSaveHandler
{
}