using FAN.App.Models.Session;
using FAN.App.Session;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FAN.App.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ISessionService _sessionService;

        public AccountController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public IActionResult Login(string id)
        {
            // UserSetting nesnesini oluştur
            var userSetting = new UserSetting
            {
                 Id = Guid.NewGuid(),
            };

            // Session ve Redis'te UserSetting nesnesini sakla
            _sessionService.SetUserSetting(userSetting);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            // UserSetting nesnesini sil
            _sessionService.RemoveUserSetting();

            // Session'u temizle
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetUserSetting()
        {
            var userSetting = _sessionService.GetUserSetting();

            if (userSetting != null)
            {
                return Content($"User: {userSetting.Id}");
            }

            return Content("User setting not found.");
        }

    }
}
