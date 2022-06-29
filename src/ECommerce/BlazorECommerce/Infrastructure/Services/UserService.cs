using Common.Infrastructure.Exceptions;
using Common.Infrastructure.Results;
using Common.Models.Queries;
using BlazorECommerce.Infrastructure.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorECommerce.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;

        public UserService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<UserDetailViewModel> GetUserDetail(Guid? id)
        {
            var userDetail = await client.GetFromJsonAsync<UserDetailViewModel>($"/api/user/{id}");

            return userDetail;
        }

        public async Task<UserDetailViewModel> GetUserDetail(string email)
        {
            var userDetail = await client.GetFromJsonAsync<UserDetailViewModel>($"/api/user/email/{email}");

            return userDetail;
        }

        public async Task<bool> UpdateUser(UserDetailViewModel user)
        {
            var res = await client.PostAsJsonAsync($"/api/user/update", user);

            return res.IsSuccessStatusCode;
        }
    }
}
