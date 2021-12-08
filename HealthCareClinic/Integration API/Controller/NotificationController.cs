using Integration.Interface.Service;
using Integration.Notifications.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.Controller
{
    [Route("hospital/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("dummy")]
        public IActionResult CreateDummyData()
        {
            List<Notification> notifications = (List<Notification>)_notificationService.CreateDummy();
            return Ok(notifications);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Notification> notifications = (List<Notification>)_notificationService.GetAll();
            return Ok(notifications);
        }

        [HttpPut("seen")]
        public IActionResult MarkAllNotificationsAsSeen()
        {
            _notificationService.MarkAllAsSeen();
            return Ok();
        }
    }
}
