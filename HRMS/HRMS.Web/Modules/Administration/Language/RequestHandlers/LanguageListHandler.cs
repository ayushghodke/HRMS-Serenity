using MyRow = HRMS.Administration.LanguageRow;

namespace HRMS.Administration;

public interface ILanguageListHandler : IListHandler<MyRow> { }

public class LanguageListHandler(IRequestContext context)
    : ListRequestHandler<MyRow>(context), ILanguageListHandler
{
}