using MyRow = HRMS.Administration.LanguageRow;

namespace HRMS.Administration;

public interface ILanguageRetrieveHandler : IRetrieveHandler<MyRow> { }

public class LanguageRetrieveHandler(IRequestContext context)
    : RetrieveRequestHandler<MyRow>(context), ILanguageRetrieveHandler
{
}