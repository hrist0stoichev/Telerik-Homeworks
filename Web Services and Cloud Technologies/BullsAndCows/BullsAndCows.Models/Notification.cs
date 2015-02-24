﻿namespace BullsAndCows.Models
{
    using System;

    public class Notification
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public NotificationType Type { get; set; }

        public NotificationState State { get; set; }

        public virtual Game Game { get; set; }

        public int GameId { get; set; }
    }
}