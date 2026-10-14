using System;

namespace MunicipalServicesApp
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int Priority { get; set; }
        public DateTime Date { get; set; }

        public Announcement( int announcementId, string title,string message, int priority, DateTime date)
        {
            AnnouncementId = announcementId;
            Title = title;
            Message = message;
            Priority = priority;
            Date = date;
        }
    }
}