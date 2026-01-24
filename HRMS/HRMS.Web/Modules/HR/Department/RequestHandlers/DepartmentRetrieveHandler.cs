using Serenity.Services;
using MyRow = HRMS.HR.DepartmentRow;

namespace HRMS.HR;

public interface IDepartmentRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> {}

public class DepartmentRetrieveHandler : RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>, IDepartmentRetrieveHandler
{
    public DepartmentRetrieveHandler(IRequestContext context) : base(context)
    {
    }
}
