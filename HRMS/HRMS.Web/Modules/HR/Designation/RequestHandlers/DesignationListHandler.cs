using Serenity.Services;
using MyRow = HRMS.HR.DesignationRow;

namespace HRMS.HR;

public interface IDesignationListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> {}

public class DesignationListHandler : ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>, IDesignationListHandler
{
    public DesignationListHandler(IRequestContext context) : base(context)
    {
    }
}
