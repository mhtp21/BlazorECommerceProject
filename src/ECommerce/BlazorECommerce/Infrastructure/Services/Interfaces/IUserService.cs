using Common.Models.Queries;

namespace BlazorECommerce.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserDetail(Guid? id);
        Task<UserDetailViewModel> GetUserDetail(string email);

        Task<bool> UpdateUser(UserDetailViewModel user);
    }
}
