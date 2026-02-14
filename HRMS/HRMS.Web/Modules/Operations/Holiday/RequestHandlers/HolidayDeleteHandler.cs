using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.Operations.HolidayRow;

namespace HRMS.Operations;

public interface IHolidayDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class HolidayDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IHolidayDeleteHandler
{
    public HolidayDeleteHandler(IRequestContext context) : base(context) { }
}
