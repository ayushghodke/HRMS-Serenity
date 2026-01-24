using MyRow = HRMS.Administration.UserRow;

namespace HRMS.Administration;

public interface IUserListHandler : IListHandler<MyRow, UserListRequest, ListResponse<MyRow>> { }

public class UserListHandler(IRequestContext context)
    : ListRequestHandler<MyRow, UserListRequest, ListResponse<MyRow>>(context), IUserListHandler
{
}