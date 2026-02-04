using MyRow = HRMS.Operations.AssetsRow;

namespace HRMS.Operations;

public interface IAssetsListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> { }

public class AssetsListHandler(IRequestContext context) :
    ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IAssetsListHandler
{
}
