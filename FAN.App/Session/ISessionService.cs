using FAN.App.Models.Session;

namespace FAN.App.Session
{
    public interface ISessionService
    {
        void SetUserSetting(UserSetting userSetting);
        UserSetting GetUserSetting();
        void RemoveUserSetting();
    }
}
