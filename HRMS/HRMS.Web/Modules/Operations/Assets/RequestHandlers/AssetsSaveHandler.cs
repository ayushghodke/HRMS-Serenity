using MyRow = HRMS.Operations.AssetsRow;

namespace HRMS.Operations;

public interface IAssetsSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class AssetsSaveHandler(IRequestContext context) :
    SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IAssetsSaveHandler
{
}
