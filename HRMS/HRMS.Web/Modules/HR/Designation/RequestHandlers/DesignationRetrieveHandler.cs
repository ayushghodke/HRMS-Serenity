using Serenity.Services;
using MyRow = HRMS.HR.DesignationRow;

namespace HRMS.HR;

public interface IDesignationRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> {}

public class DesignationRetrieveHandler : RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>, IDesignationRetrieveHandler
{
    public DesignationRetrieveHandler(IRequestContext context) : base(context)
    {
    }
}
