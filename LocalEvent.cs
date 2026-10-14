using System;

namespace MunicipalServicesApp
{
    public class LocalEvent
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

        public LocalEvent(int eventId, string title,string description,  string category, DateTime eventDate, string location)
        {
            EventId = eventId;
            Title = title;
            Description = description;
            Category = category;
            EventDate = eventDate;
            Location = location;
        }
    }
}