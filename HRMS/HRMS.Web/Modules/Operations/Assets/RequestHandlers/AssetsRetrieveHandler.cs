using MyRow = HRMS.Operations.AssetsRow;

namespace HRMS.Operations;

public interface IAssetsRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class AssetsRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IAssetsRetrieveHandler
{
}
