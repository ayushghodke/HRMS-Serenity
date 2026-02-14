using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.Operations.HolidayRow>;
using MyRow = HRMS.Operations.HolidayRow;

namespace HRMS.Operations;

public interface IHolidayRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class HolidayRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IHolidayRetrieveHandler
{
    public HolidayRetrieveHandler(IRequestContext context) : base(context) { }
}
