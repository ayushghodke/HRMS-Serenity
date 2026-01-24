using Serenity.Services;
using MyRow = HRMS.HR.DesignationRow;

namespace HRMS.HR;

public interface IDesignationDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> {}

public class DesignationDeleteHandler : DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>, IDesignationDeleteHandler
{
    public DesignationDeleteHandler(IRequestContext context) : base(context)
    {
    }
}
