namespace SignalRNotificationDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using System.Collections.Generic;
    using System.Linq;

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public UsersController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        private static List<User> users = new List<User>
    {
        new User { Id = 1, Name = "Ayşe Yılmaz", Email = "ayse@example.com", Role = "Admin" },
        new User { Id = 2, Name = "Ali Demir", Email = "ali@example.com", Role = "User" }
    };

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);

            // send notification
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Yeni kullanıcı eklendi");

            return Ok(user);
        }
    }

}
