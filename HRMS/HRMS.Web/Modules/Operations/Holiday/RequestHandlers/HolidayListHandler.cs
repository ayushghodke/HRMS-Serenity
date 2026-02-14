using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.Operations.HolidayRow>;
using MyRow = HRMS.Operations.HolidayRow;

namespace HRMS.Operations;

public interface IHolidayListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class HolidayListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IHolidayListHandler
{
    public HolidayListHandler(IRequestContext context) : base(context) { }
}
