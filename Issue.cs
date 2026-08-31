using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaPath { get; set; } // Stores the path to the attached file
        public DateTime ReportDate { get; set; } // Automatically capture date
        public string Status { get; set; } = "Submitted"; // Status of the issue

        // Constructor
        public Issue(string location, string category, string description, string mediaPath)
        {
            Location = location;
            Category = category;
            Description = description;
            MediaPath = mediaPath;
            ReportDate = DateTime.Now;
            Status = "Submitted"; // Default status
        }
    }
}