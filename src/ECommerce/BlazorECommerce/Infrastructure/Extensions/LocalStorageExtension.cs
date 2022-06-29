using Blazored.LocalStorage;
using System.Security.Claims;

namespace BlazorECommerce.Infrastructure.Extensions
{
    public static class LocalStorageExtension
    {
        public const string TokenName = "token";
        public const string UserId = "userid";

        public static bool IsUserLoggedIn(this ISyncLocalStorageService localStorageService)
        {
            return !string.IsNullOrEmpty(GetToken(localStorageService));
        }

        public static Guid GetUserId(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<Guid>(UserId);
        }

        public static void SetUserId(this ISyncLocalStorageService localStorageService, Guid id)
        {
            localStorageService.SetItem(UserId, id);
        }

        public static async Task SetUserId(this ILocalStorageService localStorageService, Guid id)
        {
            await localStorageService.SetItemAsync(UserId, id);
        }

        public static async Task<Guid> GetUserId(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<Guid>(UserId);
        }


        public static string GetToken(this ISyncLocalStorageService localStorageService)
        {
            var token = localStorageService.GetItem<string>(TokenName);
            return token;
        }

        public static async Task<string> GetToken(this ILocalStorageService localStorageService)
        {
            var token = await localStorageService.GetItemAsync<string>(TokenName);
            return token;
        }

        public static void SetToken(this ISyncLocalStorageService localStorageService, string value)
        {
            localStorageService.SetItem(TokenName, value);
        }

        public static async Task SetToken(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsync(TokenName, value);
        }
    }
}
