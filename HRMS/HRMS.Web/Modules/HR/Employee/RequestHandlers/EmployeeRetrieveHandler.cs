using Serenity.Services;
using MyRow = HRMS.HR.EmployeeRow;

namespace HRMS.HR;

public interface IEmployeeRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> {}

public class EmployeeRetrieveHandler : RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>, IEmployeeRetrieveHandler
{
    public EmployeeRetrieveHandler(IRequestContext context) : base(context)
    {
    }
}
