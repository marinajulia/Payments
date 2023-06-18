using Microsoft.AspNetCore.Mvc;
using WeatherReport.Domain.Service.User;
using WeatherReport.Domain.Service.User.Dto;
using WeatherReport.SharedKernel.Utils.Notifications;

namespace WeatherReport.Api.Controllers.User
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly INotification _notification;
        private readonly IUserService _userService;

        public UserController(INotification notification, IUserService userService)
        {
            _notification = notification;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post(UserDto user)
        {
            var response = _userService.Post(user);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }
    }
}
