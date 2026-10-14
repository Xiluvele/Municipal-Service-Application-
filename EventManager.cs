using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
    public static class EventManager
    {
        // =====================================================
        // SORTED DICTIONARY
        // Keeps events organised chronologically by date.
        // =====================================================
        public static SortedDictionary<DateTime, List<LocalEvent>> EventsByDate = new SortedDictionary<DateTime, List<LocalEvent>>();


        // =====================================================
        // DICTIONARY
        // Allows fast lookup of events by category.
        // =====================================================
        public static Dictionary<string, List<LocalEvent>> EventsByCategory =  new Dictionary<string, List<LocalEvent>>( StringComparer.OrdinalIgnoreCase);


        // =====================================================
        // HASHSET
        // Stores unique event categories.
        // =====================================================
        public static HashSet<string> Categories = new HashSet<string>( StringComparer.OrdinalIgnoreCase);


        // =====================================================
        // STACK
        // Stores the user's most recent searches.
        // =====================================================
        public static Stack<string> RecentSearches =  new Stack<string>();


        // =====================================================
        // QUEUE
        // Stores upcoming events in chronological order.
        // =====================================================
        public static Queue<LocalEvent> UpcomingEvents = new Queue<LocalEvent>();


        // =====================================================
        // PRIORITY QUEUE
        // Stores municipal announcements according to priority.
        //
        // Priority 1 = Critical
        // Priority 2 = High
        // Priority 3 = Normal
        // =====================================================
        public static AnnouncementPriorityQueue Announcements =  new AnnouncementPriorityQueue();


        // =====================================================
        // DICTIONARY - SEARCH PREFERENCES
        // Tracks how often the user searches each category.
        // Used by the recommendation algorithm.
        // =====================================================
        public static Dictionary<string, int> SearchPreferences =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);


        // =====================================================
        // STATIC CONSTRUCTOR
        // =====================================================
        static EventManager()
        {
            LoadSampleEvents();
            LoadSampleAnnouncements();
        }


        // =====================================================
        // SAMPLE EVENTS
        // =====================================================
        private static void LoadSampleEvents()
        {
            AddEvent(new LocalEvent(
                1,
                "Community Clean-Up Campaign",
                "Join residents in keeping our community clean and safe.",
                "Environment",
                DateTime.Today.AddDays(3),
                "Pretoria Central"
            ));

            AddEvent(new LocalEvent(
                2,
                "Youth Career Workshop",
                "A career development workshop for young people.",
                "Education",
                DateTime.Today.AddDays(6),
                "Municipal Community Hall"
            ));

            AddEvent(new LocalEvent(
                3,
                "Heritage Celebration",
                "Celebrate local culture, heritage and community.",
                "Culture",
                DateTime.Today.AddDays(10),
                "Pretoria City Hall"
            ));

            AddEvent(new LocalEvent(
                4,
                "Community Sports Day",
                "A community sports programme for residents and families.",
                "Sports",
                DateTime.Today.AddDays(14),
                "Municipal Sports Ground"
            ));

            BuildUpcomingQueue();
        }


        // =====================================================
        // SAMPLE MUNICIPAL ANNOUNCEMENTS
        // =====================================================
        private static void LoadSampleAnnouncements()
        {
            // Normal priority
            Announcements.Enqueue(new Announcement( 1, "Municipal Office Operating Hours", "Municipal offices will operate from 08:00 to 16:30 on weekdays.", 3,DateTime.Today ));

            // Critical priority
            Announcements.Enqueue(new Announcement(2, "Emergency Water Supply Interruption", "Residents are advised of an emergency water supply interruption affecting selected areas.", 1, DateTime.Today ));

            // High priority
            Announcements.Enqueue(new Announcement(3, "Planned Electricity Maintenance","Scheduled electricity maintenance will take place in selected areas this week.", 2, DateTime.Today.AddDays(1)));

            // Normal priority
            Announcements.Enqueue(new Announcement(4,  "Community Meeting Notice", "Residents are invited to attend the upcoming municipal community meeting.", 3, DateTime.Today.AddDays(2) ));
        }


        // =====================================================
        // ADD EVENT
        // =====================================================
        public static void AddEvent(LocalEvent localEvent)
        {
            // -----------------------------
            // SortedDictionary
            // -----------------------------
            DateTime date = localEvent.EventDate.Date;

            if (!EventsByDate.ContainsKey(date))
            {
                EventsByDate[date] = new List<LocalEvent>();
            }

            EventsByDate[date].Add(localEvent);


            // -----------------------------
            // Dictionary
            // -----------------------------
            if (!EventsByCategory.ContainsKey(localEvent.Category))
            {
                EventsByCategory[localEvent.Category] = new List<LocalEvent>();
            }

            EventsByCategory[localEvent.Category]
                .Add(localEvent);


            // -----------------------------
            // HashSet
            // -----------------------------
            Categories.Add(localEvent.Category);
        }


        // =====================================================
        // BUILD UPCOMING EVENTS QUEUE
        // =====================================================
        private static void BuildUpcomingQueue()
        {
            UpcomingEvents.Clear();

            foreach ( KeyValuePair<DateTime, List<LocalEvent>> entry in EventsByDate)
            {
                if (entry.Key >= DateTime.Today)
                {
                    foreach (LocalEvent localEvent in entry.Value)
                    {
                        UpcomingEvents.Enqueue(localEvent);
                    }
                }
            }
        }


        // =====================================================
        // GET ALL UPCOMING EVENTS
        // =====================================================
        public static List<LocalEvent> GetAllUpcomingEvents()
        {
            return UpcomingEvents.ToList();
        }


        // =====================================================
        // SEARCH EVENTS
        // Search by:
        // 1. Keyword
        // 2. Category
        // 3. Date
        // =====================================================
        public static List<LocalEvent> SearchEvents( string keyword,string category, DateTime? selectedDate)
        {
            // Start with all upcoming events from the Queue
            List<LocalEvent> results = UpcomingEvents.ToList();


            // -----------------------------
            // Search by keyword
            // -----------------------------
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                results = results
                    .Where(e =>
                        e.Title.IndexOf(
                            keyword,
                            StringComparison.OrdinalIgnoreCase) >= 0
                        ||
                        e.Description.IndexOf(
                            keyword,
                            StringComparison.OrdinalIgnoreCase) >= 0
                        ||
                        e.Location.IndexOf(
                            keyword,
                            StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }


            // -----------------------------
            // Search by category
            // Uses Dictionary
            // -----------------------------
            if (!string.IsNullOrWhiteSpace(category) &&
                category != "All Categories")
            {
                if (EventsByCategory.ContainsKey(category))
                {
                    List<LocalEvent> categoryEvents =
                        EventsByCategory[category];

                    results = results
                        .Where(e => categoryEvents.Contains(e))
                        .ToList();
                }
                else
                {
                    results.Clear();
                }
            }


            // -----------------------------
            // Search by date
            // -----------------------------
            if (selectedDate.HasValue)
            {
                results = results
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
        // Used for personalised recommendations.
        // =====================================================
        public static void RecordSearchPreference(string category)
        {
            if (string.IsNullOrWhiteSpace(category) ||
                category == "All Categories")
            {
                return;
            }


            if (SearchPreferences.ContainsKey(category))
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
                .OrderByDescending(item => item.Value)
                .ThenBy(item => item.Key)
                .First()
                .Key;
        }


        // =====================================================
        // RECOMMENDATION ALGORITHM
        // =====================================================
        public static List<LocalEvent> GetRecommendedEvents()
        {
            string favouriteCategory = GetFavouriteCategory();

            if (string.IsNullOrWhiteSpace(favouriteCategory))
            {
                return new List<LocalEvent>();
            }


            if (!EventsByCategory.ContainsKey(favouriteCategory))
            {
                return new List<LocalEvent>();
            }


            return EventsByCategory[favouriteCategory]
                .Where(e =>
                    e.EventDate.Date >= DateTime.Today)
                .OrderBy(e => e.EventDate)
                .Take(3)
                .ToList();
        }
    }
}