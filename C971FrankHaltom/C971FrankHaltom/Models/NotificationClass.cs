using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace C971FrankHaltom.Models
{
    public class NotificationClass
    {
        [PrimaryKey, AutoIncrement]
        public int NoteId { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime NotifyTime { get; set; }

        public NotificationClass(string title, string body, DateTime notifyTime)
        {
            Title = title;
            Body = body;
            NotifyTime = notifyTime;
        }
        public NotificationClass()
        {

        }
    }
}
