using FAN.App.Models.Session;
using FAN.App.Redis;
using Microsoft.AspNetCore.Authentication;
using StackExchange.Redis;
using System.Text.Json;

namespace FAN.App.Session
{
    public class SessionService(IHttpContextAccessor httpContextAccessor) : ISessionService
    {
        public void SetUserSetting(UserSetting userSetting)
        {
            var session = httpContextAccessor.HttpContext.Session;
            string userSettingJson = JsonSerializer.Serialize(userSetting);

            session.SetString("UserSetting", userSettingJson);
        }

        public UserSetting GetUserSetting()
        {
            var session = httpContextAccessor.HttpContext.Session;
            string userSettingJson = session.GetString("UserSetting");

            if (!string.IsNullOrEmpty(userSettingJson))
            {
                return JsonSerializer.Deserialize<UserSetting>(userSettingJson);
            }

            return null;
        }

        public void RemoveUserSetting()
        {
            var context= httpContextAccessor.HttpContext;
            context.SignOutAsync().Wait();

            context.Session.Clear();
        }
    }
}
