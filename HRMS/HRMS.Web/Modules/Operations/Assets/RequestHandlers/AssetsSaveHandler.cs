using MyRow = HRMS.Operations.AssetsRow;
using Serenity.Services;

namespace HRMS.Operations;

public interface IAssetsSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class AssetsSaveHandler(IRequestContext context) :
    SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IAssetsSaveHandler
{
    protected override void BeforeSave()
    {
        base.BeforeSave();

        var status = Row.Status ?? (IsCreate ? AssetStatus.Available : Old.Status ?? AssetStatus.Available);
        var assignedTo = Row.AssignedTo ?? (IsCreate ? null : Old.AssignedTo);

        if (status == AssetStatus.In_Use && (!assignedTo.HasValue || assignedTo.Value <= 0))
            throw new ValidationError("AssignedToRequired", "AssignedTo", "Assigned To is required when status is In Use.");
    }
}
