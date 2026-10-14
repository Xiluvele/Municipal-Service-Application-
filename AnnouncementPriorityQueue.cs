using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
    public class AnnouncementPriorityQueue
    {
        // =====================================================
        // PRIORITY QUEUE DATA STRUCTURE
        // =====================================================
        // SortedDictionary keeps the priority numbers sorted
        // automatically.
        //
        // Priority 1 = Critical
        // Priority 2 = High
        // Priority 3 = Normal
        //
        // Each priority contains its own Queue.
        //
        // The Queue follows FIFO:
        // First In, First Out.
        //
        // This means announcements with the same priority are
        // displayed in the order they were added.
        // =====================================================
        private readonly SortedDictionary<int, Queue<Announcement>>
            priorityQueue =
            new SortedDictionary<int, Queue<Announcement>>();


        // =====================================================
        // ADD ANNOUNCEMENT TO PRIORITY QUEUE
        // =====================================================
        public void Enqueue(Announcement announcement)
        {
            if (announcement == null)
            {
                return;
            }

            int priority = announcement.Priority;


            // Create a Queue for this priority if one
            // does not already exist.
            if (!priorityQueue.ContainsKey(priority))
            {
                priorityQueue[priority] =
                    new Queue<Announcement>();
            }


            // Add the announcement to its priority Queue.
            priorityQueue[priority].Enqueue(announcement);
        }


        // =====================================================
        // GET ALL ANNOUNCEMENTS BY PRIORITY
        // =====================================================
        // Returns announcements in this order:
        //
        // 1. Critical
        // 2. High
        // 3. Normal
        //
        // SortedDictionary automatically processes the
        // smallest priority number first.
        // =====================================================
        public List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> announcements =
                new List<Announcement>();


            foreach (
                KeyValuePair<int, Queue<Announcement>> entry
                in priorityQueue)
            {
                foreach (
                    Announcement announcement in entry.Value)
                {
                    announcements.Add(announcement);
                }
            }


            return announcements;
        }


        // =====================================================
        // FIND ANNOUNCEMENT BY ID
        // =====================================================
        // Searches through the Priority Queue for an
        // announcement with the specified unique ID.
        // =====================================================
        public Announcement FindById(int announcementId)
        {
            foreach (
                Queue<Announcement> queue
                in priorityQueue.Values)
            {
                Announcement announcement =
                    queue.FirstOrDefault(
                        a =>
                        a.AnnouncementId ==
                        announcementId);


                if (announcement != null)
                {
                    return announcement;
                }
            }


            return null;
        }


        // =====================================================
        // UPDATE ANNOUNCEMENT
        // =====================================================
        // Updating is slightly different for a Priority Queue.
        //
        // The priority might change, for example:
        //
        // Normal (3) → Critical (1)
        //
        // Therefore, after updating the announcement we rebuild
        // the Priority Queue so that the announcement appears
        // in its correct priority position.
        // =====================================================
        public bool Update(Announcement updatedAnnouncement)
        {
            if (updatedAnnouncement == null)
            {
                return false;
            }


            // Get all announcements before rebuilding.
            List<Announcement> announcements =
                GetAllAnnouncements();


            // Find the announcement being edited.
            Announcement existingAnnouncement =
                announcements.FirstOrDefault(
                    a =>
                    a.AnnouncementId ==
                    updatedAnnouncement.AnnouncementId);


            if (existingAnnouncement == null)
            {
                return false;
            }


            // Update its information.
            existingAnnouncement.Title =
                updatedAnnouncement.Title;

            existingAnnouncement.Message =
                updatedAnnouncement.Message;

            existingAnnouncement.Priority =
                updatedAnnouncement.Priority;

            existingAnnouncement.Date =
                updatedAnnouncement.Date;


            // Rebuild the Priority Queue.
            RebuildQueue(announcements);


            return true;
        }


        // =====================================================
        // DELETE ANNOUNCEMENT
        // =====================================================
        // Removes an announcement using its unique ID.
        //
        // After removing it, the Priority Queue is rebuilt.
        // =====================================================
        public bool Delete(int announcementId)
        {
            // Get all announcements.
            List<Announcement> announcements =
                GetAllAnnouncements();


            // Find the announcement to delete.
            Announcement announcementToDelete =
                announcements.FirstOrDefault(
                    a =>
                    a.AnnouncementId ==
                    announcementId);


            if (announcementToDelete == null)
            {
                return false;
            }


            // Remove the selected announcement.
            announcements.Remove(
                announcementToDelete);


            // Rebuild the Priority Queue without
            // the deleted announcement.
            RebuildQueue(announcements);


            return true;
        }


        // =====================================================
        // CLEAR PRIORITY QUEUE
        // =====================================================
        // Removes all announcements.
        //
        // This is useful when loading announcements from
        // announcements.txt or rebuilding the queue.
        // =====================================================
        public void Clear()
        {
            priorityQueue.Clear();
        }


        // =====================================================
        // REBUILD PRIORITY QUEUE
        // =====================================================
        // Clears the current Priority Queue and adds the
        // announcements again.
        //
        // This makes sure announcements are placed under
        // their correct priority after an Edit or Delete.
        // =====================================================
        private void RebuildQueue(
            List<Announcement> announcements)
        {
            priorityQueue.Clear();


            foreach (
                Announcement announcement
                in announcements)
            {
                Enqueue(announcement);
            }
        }


        // =====================================================
        // GET NUMBER OF ANNOUNCEMENTS
        // =====================================================
        public int Count()
        {
            int count = 0;


            foreach (
                Queue<Announcement> queue
                in priorityQueue.Values)
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