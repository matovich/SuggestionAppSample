using Microsoft.AspNetCore.Components.Authorization;

namespace SuggestionAppUI.Helpers
{
    public static class AuthenticationStateProvidersHelpers
    {
        public static async Task<UserModel> GetUserFromAuth(this AuthenticationStateProvider provider, IUserData userData)
        {
            var authState = await provider.GetAuthenticationStateAsync();
            var objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
            return await userData.GetUserFromAuthenticationAsync(objectId);
        }
    }
}
