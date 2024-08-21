using FAN.App.Models.Session;
using FAN.App.Redis;
using StackExchange.Redis;
using System.Text.Json;

namespace FAN.App.Session
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetUserSetting(UserSetting userSetting)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string userSettingJson = JsonSerializer.Serialize(userSetting);

            session.SetString("UserSetting", userSettingJson);

        }

        public UserSetting GetUserSetting()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string userSettingJson = session.GetString("UserSetting");

             
            if (!string.IsNullOrEmpty(userSettingJson))
            {
                return JsonSerializer.Deserialize<UserSetting>(userSettingJson);
            }

            return null;
        }

        public void RemoveUserSetting()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string username = session.GetString("Username");
 
            session.Remove("UserSetting");
        }
    }
}
