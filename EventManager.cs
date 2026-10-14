using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MunicipalServicesApp
{
    public static class EventManager
    {
        // =====================================================
        // MAIN EVENT COLLECTION
        // =====================================================
        // This List is the main source of all municipal events.
        //
        // When an administrator adds, edits or deletes an event,
        // this List is updated first.
        //
        // The other event data structures are rebuilt from this
        // collection so that they always contain the latest data.
        // =====================================================
        private static readonly List<LocalEvent> allEvents =
            new List<LocalEvent>();


        // =====================================================
        // EVENT DATA FILE
        // =====================================================
        // events.txt is stored inside the project's Data folder.
        // =====================================================
        private static readonly string eventsFilePath =
            DataPathHelper.GetDataFilePath("events.txt");


        // =====================================================
        // ANNOUNCEMENT DATA FILE
        // =====================================================
        // announcements.txt is also stored inside the project's
        // Data folder.
        //
        // This allows announcements created, edited or deleted
        // by the administrator to remain after restarting the
        // application.
        // =====================================================
        private static readonly string announcementsFilePath =
            DataPathHelper.GetDataFilePath("announcements.txt");


        // =====================================================
        // SORTED DICTIONARY
        // =====================================================
        // Key   = Event date
        // Value = Events taking place on that date
        //
        // SortedDictionary automatically keeps dates sorted.
        // =====================================================
        public static SortedDictionary<DateTime, List<LocalEvent>>
            EventsByDate =
            new SortedDictionary<DateTime, List<LocalEvent>>();


        // =====================================================
        // DICTIONARY
        // =====================================================
        // Key   = Event category
        // Value = Events belonging to that category
        //
        // Used for fast category-based searching.
        // =====================================================
        public static Dictionary<string, List<LocalEvent>>
            EventsByCategory =
            new Dictionary<string, List<LocalEvent>>(
                StringComparer.OrdinalIgnoreCase);


        // =====================================================
        // HASHSET
        // =====================================================
        // Stores each category only once.
        // =====================================================
        public static HashSet<string> Categories =
            new HashSet<string>(
                StringComparer.OrdinalIgnoreCase);


        // =====================================================
        // STACK
        // =====================================================
        // Stores recent searches.
        //
        // Stack = Last In, First Out (LIFO).
        // =====================================================
        public static Stack<string> RecentSearches =
            new Stack<string>();


        // =====================================================
        // QUEUE
        // =====================================================
        // Stores upcoming events chronologically.
        //
        // Queue = First In, First Out (FIFO).
        // =====================================================
        public static Queue<LocalEvent> UpcomingEvents =
            new Queue<LocalEvent>();


        // =====================================================
        // PRIORITY QUEUE
        // =====================================================
        // Stores announcements according to priority.
        //
        // Priority 1 = Critical
        // Priority 2 = High
        // Priority 3 = Normal
        // =====================================================
        public static AnnouncementPriorityQueue Announcements =
            new AnnouncementPriorityQueue();


        // =====================================================
        // DICTIONARY - SEARCH PREFERENCES
        // =====================================================
        // Tracks how often a citizen searches each category.
        //
        // Used by the recommendation algorithm.
        // =====================================================
        public static Dictionary<string, int> SearchPreferences =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);


        // =====================================================
        // STATIC CONSTRUCTOR
        // =====================================================
        // Runs automatically the first time EventManager is used.
        //
        // EVENTS:
        // If events.txt exists, load the saved events.
        // Otherwise create the four sample events.
        //
        // ANNOUNCEMENTS:
        // If announcements.txt exists, load saved announcements.
        // Otherwise create the four sample announcements.
        // =====================================================
        static EventManager()
        {
            // -------------------------------------------------
            // EVENTS
            // -------------------------------------------------
            bool eventsFileExists =
                File.Exists(eventsFilePath);

            LoadEvents();

            // Only create sample events on the very first run.
            //
            // IMPORTANT:
            // We check whether the FILE exists instead of checking
            // allEvents.Count. This means if an administrator
            // deliberately deletes every event, the sample events
            // will NOT come back after restarting the application.
            if (!eventsFileExists)
            {
                LoadSampleEvents();
                SaveEvents();
            }

            // Build all event-related data structures.
            RebuildEventDataStructures();


            // -------------------------------------------------
            // ANNOUNCEMENTS
            // -------------------------------------------------
            bool announcementsFileExists =
                File.Exists(announcementsFilePath);

            LoadAnnouncements();

            // Only create sample announcements on first run.
            //
            // If the administrator later deletes every
            // announcement, they will stay deleted.
            if (!announcementsFileExists)
            {
                LoadSampleAnnouncements();
                SaveAnnouncements();
            }
        }


        // =====================================================
        // SAMPLE EVENTS
        // =====================================================
        // Used only when events.txt does not exist yet.
        // =====================================================
        private static void LoadSampleEvents()
        {
            allEvents.Add(
                new LocalEvent(
                    1,
                    "Community Clean-Up Campaign",
                    "Join residents in keeping our community clean and safe.",
                    "Environment",
                    DateTime.Today.AddDays(3),
                    "Pretoria Central"
                )
            );


            allEvents.Add(
                new LocalEvent(
                    2,
                    "Youth Career Workshop",
                    "A career development workshop for young people.",
                    "Education",
                    DateTime.Today.AddDays(6),
                    "Municipal Community Hall"
                )
            );


            allEvents.Add(
                new LocalEvent(
                    3,
                    "Heritage Celebration",
                    "Celebrate local culture, heritage and community.",
                    "Culture",
                    DateTime.Today.AddDays(10),
                    "Pretoria City Hall"
                )
            );


            allEvents.Add(
                new LocalEvent(
                    4,
                    "Community Sports Day",
                    "A community sports programme for residents and families.",
                    "Sports",
                    DateTime.Today.AddDays(14),
                    "Municipal Sports Ground"
                )
            );
        }


        // =====================================================
        // SAMPLE MUNICIPAL ANNOUNCEMENTS
        // =====================================================
        // These are created only if announcements.txt does not
        // exist yet.
        // =====================================================
        private static void LoadSampleAnnouncements()
        {
            // Normal priority
            Announcements.Enqueue(
                new Announcement(
                    1,
                    "Municipal Office Operating Hours",
                    "Municipal offices will operate from 08:00 to 16:30 on weekdays.",
                    3,
                    DateTime.Today
                )
            );


            // Critical priority
            Announcements.Enqueue(
                new Announcement(
                    2,
                    "Emergency Water Supply Interruption",
                    "Residents are advised of an emergency water supply interruption affecting selected areas.",
                    1,
                    DateTime.Today
                )
            );


            // High priority
            Announcements.Enqueue(
                new Announcement(
                    3,
                    "Planned Electricity Maintenance",
                    "Scheduled electricity maintenance will take place in selected areas this week.",
                    2,
                    DateTime.Today.AddDays(1)
                )
            );


            // Normal priority
            Announcements.Enqueue(
                new Announcement(
                    4,
                    "Community Meeting Notice",
                    "Residents are invited to attend the upcoming municipal community meeting.",
                    3,
                    DateTime.Today.AddDays(2)
                )
            );
        }


        // =====================================================
        // ADD EVENT
        // =====================================================
        public static void AddEvent(LocalEvent localEvent)
        {
            if (localEvent == null)
            {
                return;
            }

            allEvents.Add(localEvent);

            RebuildEventDataStructures();

            SaveEvents();
        }


        // =====================================================
        // UPDATE EVENT
        // =====================================================
        public static bool UpdateEvent(
            LocalEvent updatedEvent)
        {
            if (updatedEvent == null)
            {
                return false;
            }


            LocalEvent existingEvent =
                allEvents.FirstOrDefault(
                    e =>
                    e.EventId ==
                    updatedEvent.EventId);


            if (existingEvent == null)
            {
                return false;
            }


            existingEvent.Title =
                updatedEvent.Title;

            existingEvent.Description =
                updatedEvent.Description;

            existingEvent.Category =
                updatedEvent.Category;

            existingEvent.EventDate =
                updatedEvent.EventDate;

            existingEvent.Location =
                updatedEvent.Location;


            // Rebuild because the administrator may have
            // changed the date or category.
            RebuildEventDataStructures();

            SaveEvents();

            return true;
        }


        // =====================================================
        // DELETE EVENT
        // =====================================================
        public static bool DeleteEvent(int eventId)
        {
            LocalEvent eventToDelete =
                allEvents.FirstOrDefault(
                    e => e.EventId == eventId);


            if (eventToDelete == null)
            {
                return false;
            }


            allEvents.Remove(eventToDelete);


            // Rebuild all structures so that the event is
            // removed from the Dictionary, SortedDictionary,
            // HashSet and Queue as well.
            RebuildEventDataStructures();

            SaveEvents();

            return true;
        }


        // =====================================================
        // GET NEXT EVENT ID
        // =====================================================
        public static int GetNextEventId()
        {
            if (allEvents.Count == 0)
            {
                return 1;
            }


            return allEvents
                .Max(e => e.EventId) + 1;
        }


        // =====================================================
        // GET ALL EVENTS
        // =====================================================
        // Used mainly by ManageEventsForm.
        // =====================================================
        public static List<LocalEvent> GetAllEvents()
        {
            return allEvents
                .OrderBy(e => e.EventDate)
                .ToList();
        }


        // =====================================================
        // ADD ANNOUNCEMENT
        // =====================================================
        // Adds an announcement to the Priority Queue and saves
        // it permanently.
        // =====================================================
        public static void AddAnnouncement(
            Announcement announcement)
        {
            if (announcement == null)
            {
                return;
            }


            Announcements.Enqueue(announcement);

            SaveAnnouncements();
        }


        // =====================================================
        // UPDATE ANNOUNCEMENT
        // =====================================================
        // The Priority Queue will be rebuilt if the priority
        // changes.
        //
        // Example:
        // Normal (3) -> Critical (1)
        // =====================================================
        public static bool UpdateAnnouncement(
            Announcement updatedAnnouncement)
        {
            if (updatedAnnouncement == null)
            {
                return false;
            }


            bool updated =
                Announcements.Update(
                    updatedAnnouncement);


            if (updated)
            {
                SaveAnnouncements();
            }


            return updated;
        }


        // =====================================================
        // DELETE ANNOUNCEMENT
        // =====================================================
        public static bool DeleteAnnouncement(
            int announcementId)
        {
            bool deleted =
                Announcements.Delete(
                    announcementId);


            if (deleted)
            {
                SaveAnnouncements();
            }


            return deleted;
        }


        // =====================================================
        // GET ALL ANNOUNCEMENTS
        // =====================================================
        // Returns announcements according to their priority:
        //
        // Critical -> High -> Normal
        // =====================================================
        public static List<Announcement>
            GetAllAnnouncements()
        {
            return Announcements
                .GetAllAnnouncements();
        }


        // =====================================================
        // GET NEXT ANNOUNCEMENT ID
        // =====================================================
        public static int GetNextAnnouncementId()
        {
            List<Announcement> announcements =
                Announcements
                    .GetAllAnnouncements();


            if (announcements.Count == 0)
            {
                return 1;
            }


            return announcements
                .Max(a => a.AnnouncementId) + 1;
        }


        // =====================================================
        // REBUILD EVENT DATA STRUCTURES
        // =====================================================
        // Keeps all required assignment data structures
        // synchronised with allEvents.
        // =====================================================
        private static void RebuildEventDataStructures()
        {
            // Remove the previous data.
            EventsByDate.Clear();
            EventsByCategory.Clear();
            Categories.Clear();
            UpcomingEvents.Clear();


            // Sort events chronologically before rebuilding
            // the required structures.
            foreach (
                LocalEvent localEvent in
                allEvents.OrderBy(
                    e => e.EventDate))
            {
                // ---------------------------------------------
                // SORTED DICTIONARY
                // ---------------------------------------------
                DateTime date =
                    localEvent.EventDate.Date;


                if (!EventsByDate.ContainsKey(date))
                {
                    EventsByDate[date] =
                        new List<LocalEvent>();
                }


                EventsByDate[date]
                    .Add(localEvent);


                // ---------------------------------------------
                // DICTIONARY
                // ---------------------------------------------
                if (!EventsByCategory.ContainsKey(
                        localEvent.Category))
                {
                    EventsByCategory[
                        localEvent.Category] =
                        new List<LocalEvent>();
                }


                EventsByCategory[
                    localEvent.Category]
                    .Add(localEvent);


                // ---------------------------------------------
                // HASHSET
                // ---------------------------------------------
                Categories.Add(
                    localEvent.Category);
            }


            // Rebuild the upcoming-events Queue.
            BuildUpcomingQueue();
        }


        // =====================================================
        // BUILD UPCOMING EVENTS QUEUE
        // =====================================================
        private static void BuildUpcomingQueue()
        {
            UpcomingEvents.Clear();


            foreach (
                KeyValuePair<DateTime, List<LocalEvent>>
                    entry in EventsByDate)
            {
                // Ignore past events.
                if (entry.Key >= DateTime.Today)
                {
                    foreach (
                        LocalEvent localEvent
                        in entry.Value)
                    {
                        UpcomingEvents.Enqueue(
                            localEvent);
                    }
                }
            }
        }


        // =====================================================
        // GET ALL UPCOMING EVENTS
        // =====================================================
        public static List<LocalEvent>
            GetAllUpcomingEvents()
        {
            return UpcomingEvents.ToList();
        }


        // =====================================================
        // SAVE EVENTS
        // =====================================================
        // Writes events to Data\events.txt.
        //
        // Format:
        //
        // ID|Title|Description|Category|Date|Location
        // =====================================================
        private static void SaveEvents()
        {
            using (
                StreamWriter writer =
                    new StreamWriter(
                        eventsFilePath,
                        false))
            {
                foreach (
                    LocalEvent localEvent in
                    allEvents.OrderBy(
                        e => e.EventId))
                {
                    writer.WriteLine(
                        $"{localEvent.EventId}|" +
                        $"{CleanText(localEvent.Title)}|" +
                        $"{CleanText(localEvent.Description)}|" +
                        $"{CleanText(localEvent.Category)}|" +
                        $"{localEvent.EventDate:O}|" +
                        $"{CleanText(localEvent.Location)}"
                    );
                }
            }
        }


        // =====================================================
        // LOAD EVENTS
        // =====================================================
        private static void LoadEvents()
        {
            if (!File.Exists(eventsFilePath))
            {
                return;
            }


            string[] lines =
                File.ReadAllLines(
                    eventsFilePath);


            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }


                string[] parts =
                    line.Split('|');


                // Expected:
                //
                // 0 = ID
                // 1 = Title
                // 2 = Description
                // 3 = Category
                // 4 = Date
                // 5 = Location
                if (parts.Length != 6)
                {
                    continue;
                }


                int eventId;
                DateTime eventDate;


                if (!int.TryParse(
                        parts[0],
                        out eventId))
                {
                    continue;
                }


                if (!DateTime.TryParse(
                        parts[4],
                        out eventDate))
                {
                    continue;
                }


                LocalEvent localEvent =
                    new LocalEvent(
                        eventId,
                        parts[1],
                        parts[2],
                        parts[3],
                        eventDate,
                        parts[5]
                    );


                allEvents.Add(localEvent);
            }
        }


        // =====================================================
        // SAVE ANNOUNCEMENTS
        // =====================================================
        // Writes announcements from the Priority Queue into
        // Data\announcements.txt.
        //
        // Format:
        //
        // ID|Title|Message|Priority|Date
        // =====================================================
        private static void SaveAnnouncements()
        {
            List<Announcement> announcements =
                Announcements
                    .GetAllAnnouncements();


            using (
                StreamWriter writer =
                    new StreamWriter(
                        announcementsFilePath,
                        false))
            {
                foreach (
                    Announcement announcement
                    in announcements)
                {
                    writer.WriteLine(
                        $"{announcement.AnnouncementId}|" +
                        $"{CleanText(announcement.Title)}|" +
                        $"{CleanText(announcement.Message)}|" +
                        $"{announcement.Priority}|" +
                        $"{announcement.Date:O}"
                    );
                }
            }
        }


        // =====================================================
        // LOAD ANNOUNCEMENTS
        // =====================================================
        // Reads Data\announcements.txt and restores each notice
        // to the Priority Queue.
        // =====================================================
        private static void LoadAnnouncements()
        {
            // Start with an empty Priority Queue.
            Announcements.Clear();


            if (!File.Exists(
                    announcementsFilePath))
            {
                return;
            }


            string[] lines =
                File.ReadAllLines(
                    announcementsFilePath);


            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }


                string[] parts =
                    line.Split('|');


                // Expected:
                //
                // 0 = Announcement ID
                // 1 = Title
                // 2 = Message
                // 3 = Priority
                // 4 = Date
                if (parts.Length != 5)
                {
                    continue;
                }


                int announcementId;
                int priority;
                DateTime announcementDate;


                // Validate ID.
                if (!int.TryParse(
                        parts[0],
                        out announcementId))
                {
                    continue;
                }


                // Validate priority.
                if (!int.TryParse(
                        parts[3],
                        out priority))
                {
                    continue;
                }


                // Only the three supported priorities
                // are accepted.
                if (priority < 1 ||
                    priority > 3)
                {
                    continue;
                }


                // Validate date.
                if (!DateTime.TryParse(
                        parts[4],
                        out announcementDate))
                {
                    continue;
                }


                Announcement announcement =
                    new Announcement(
                        announcementId,
                        parts[1],
                        parts[2],
                        priority,
                        announcementDate
                    );


                // Enqueue automatically places the notice
                // under the correct priority.
                Announcements.Enqueue(
                    announcement);
            }
        }


        // =====================================================
        // CLEAN TEXT BEFORE SAVING
        // =====================================================
        // | is used as the separator in our text files.
        //
        // Replace it in user-entered text to prevent the file
        // structure from becoming corrupted.
        //
        // Also remove line breaks so one record stays on one
        // line.
        // =====================================================
        private static string CleanText(
            string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }


            return text
                .Replace("|", "/")
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Trim();
        }


        // =====================================================
        // SEARCH EVENTS
        // =====================================================
        // Search by:
        //
        // 1. Keyword
        // 2. Category
        // 3. Date
        // =====================================================
        public static List<LocalEvent> SearchEvents(
            string keyword,
            string category,
            DateTime? selectedDate)
        {
            // Start with upcoming events from the Queue.
            List<LocalEvent> results =
                UpcomingEvents.ToList();


            // ---------------------------------------------
            // SEARCH BY KEYWORD
            // ---------------------------------------------
            if (!string.IsNullOrWhiteSpace(
                    keyword))
            {
                results =
                    results
                    .Where(e =>
                        e.Title.IndexOf(
                            keyword,
                            StringComparison
                                .OrdinalIgnoreCase) >= 0
                        ||
                        e.Description.IndexOf(
                            keyword,
                            StringComparison
                                .OrdinalIgnoreCase) >= 0
                        ||
                        e.Location.IndexOf(
                            keyword,
                            StringComparison
                                .OrdinalIgnoreCase) >= 0)
                    .ToList();
            }


            // ---------------------------------------------
            // SEARCH BY CATEGORY
            // ---------------------------------------------
            // Uses the Dictionary.
            // ---------------------------------------------
            if (!string.IsNullOrWhiteSpace(category)
                && category != "All Categories")
            {
                if (EventsByCategory.ContainsKey(category))
                {
                    List<LocalEvent> categoryEvents =
                        EventsByCategory[category];


                    results =
                        results
                        .Where(e =>
                            categoryEvents.Contains(e))
                        .ToList();
                }
                else
                {
                    results.Clear();
                }
            }


            // ---------------------------------------------
            // SEARCH BY DATE
            // ---------------------------------------------
            if (selectedDate.HasValue)
            {
                results =
                    results
                    .Where(e =>
                        e.EventDate.Date ==
                        selectedDate.Value.Date)
                    .ToList();
            }


            return results
                .OrderBy(e => e.EventDate)
                .ToList();
        }


        // =====================================================
        // RECORD SEARCH PREFERENCE
        // =====================================================
        // Records how often a citizen searches each category.
        //
        // Example:
        //
        // Sports    = 3
        // Education = 1
        //
        // Sports becomes the favourite category.
        // =====================================================
        public static void RecordSearchPreference(string category)
        {
            if (string.IsNullOrWhiteSpace(
                    category)
                ||
                category == "All Categories")
            {
                return;
            }


            if (SearchPreferences.ContainsKey(
                    category))
            {
                SearchPreferences[category]++;
            }
            else
            {
                SearchPreferences[category] = 1;
            }
        }


        // =====================================================
        // GET FAVOURITE CATEGORY
        // =====================================================
        public static string GetFavouriteCategory()
        {
            if (SearchPreferences.Count == 0)
            {
                return null;
            }


            return SearchPreferences
                .OrderByDescending(
                    item => item.Value)
                .ThenBy(
                    item => item.Key)
                .First()
                .Key;
        }


        // =====================================================
        // RECOMMENDATION ALGORITHM
        // =====================================================
        // Recommends up to three upcoming events from the
        // citizen's most frequently searched category.
        // =====================================================
        public static List<LocalEvent>
            GetRecommendedEvents()
        {
            string favouriteCategory =
                GetFavouriteCategory();


            if (string.IsNullOrWhiteSpace(
                    favouriteCategory))
            {
                return new List<LocalEvent>();
            }


            if (!EventsByCategory.ContainsKey(
                    favouriteCategory))
            {
                return new List<LocalEvent>();
            }


            return EventsByCategory[
                    favouriteCategory]
                .Where(e =>
                    e.EventDate.Date >=
                    DateTime.Today)
                .OrderBy(e =>
                    e.EventDate)
                .Take(3)
                .ToList();
        }
    }
}