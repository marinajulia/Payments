using Microsoft.AspNetCore.Authorization;
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
            var response = _userService.PostRegister(user);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            var response = _userService.Get();
            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }

        [HttpGet]
        [Route("id")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var response = _userService.GetById(id);
            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }
    }
}
