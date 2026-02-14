using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Operations.HolidayRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Operations.HolidayRow;

namespace HRMS.Operations;

public interface IHolidaySaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class HolidaySaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IHolidaySaveHandler
{
    public HolidaySaveHandler(IRequestContext context) : base(context) { }

    protected override void BeforeSave()
    {
        base.BeforeSave();
        if (!Row.Year.HasValue && Row.HolidayDate.HasValue)
            Row.Year = Row.HolidayDate.Value.Year;
    }
}
