using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
    public class AnnouncementPriorityQueue
    {
        // SortedDictionary keeps priorities sorted automatically.
        //
        // Priority 1 = Critical
        // Priority 2 = High
        // Priority 3 = Normal
        //
        // A Queue is used for announcements with the same priority
        // so they are displayed in the order they were added.
        private readonly SortedDictionary<int, Queue<Announcement>>
            priorityQueue = new SortedDictionary<int, Queue<Announcement>>();


        // =====================================================
        // ADD ANNOUNCEMENT TO PRIORITY QUEUE
        // =====================================================
        public void Enqueue(Announcement announcement)
        {
            int priority = announcement.Priority;

            // Create a Queue for this priority if one
            // does not already exist.
            if (!priorityQueue.ContainsKey(priority))
            {
                priorityQueue[priority] = new Queue<Announcement>();
            }

            // Add the announcement to its priority queue.
            priorityQueue[priority].Enqueue(announcement);
        }


        // =====================================================
        // GET ALL ANNOUNCEMENTS BY PRIORITY
        // =====================================================
        public List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> announcements =  new List<Announcement>();

            // SortedDictionary automatically processes:
            // 1 - Critical
            // 2 - High
            // 3 - Normal
            foreach ( KeyValuePair<int, Queue<Announcement>> entry in priorityQueue)
            {
                foreach (Announcement announcement in entry.Value)
                {
                    announcements.Add(announcement);
                }
            }

            return announcements;
        }


        // =====================================================
        // GET NUMBER OF ANNOUNCEMENTS
        // =====================================================
        public int Count()
        {
            int count = 0;

            foreach (Queue<Announcement> queue in priorityQueue.Values)
            {
                count += queue.Count;
            }

            return count;
        }


        // =====================================================
        // CHECK IF PRIORITY QUEUE IS EMPTY
        // =====================================================
        public bool IsEmpty()
        {
            return Count() == 0;
        }
    }
}