using MyRow = HRMS.Operations.AssetsRow;

namespace HRMS.Operations;

public interface IAssetsDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> { }

public class AssetsDeleteHandler(IRequestContext context) :
    DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>(context),
    IAssetsDeleteHandler
{
}
