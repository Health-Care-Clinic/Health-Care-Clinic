using System.Collections.Generic;
using Integration.Interface.Service;
using Integration.Notifications.Model;
using Microsoft.AspNetCore.Mvc;

namespace Integration_API.Controller.Notifications
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

        [HttpPost("tenderOffer")]
        public IActionResult CreateNotificationForTenderOffer(string name)
        {
            _notificationService.CreateNewTenderResponseNotification(name);
            return Ok();
        }
    }
}
