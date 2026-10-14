using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MunicipalServicesApp
{
    public static class IssueManager
    {
        // Main data structure used to store reported issues
        public static List<Issue> Issues { get; private set; }  = new List<Issue>();

        // File used to preserve issues after the application closes
        private static readonly string issuesFilePath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory,  "issues.txt");

        // Runs automatically when IssueManager is first used
        static IssueManager()
        {
            LoadIssues();
        }

        // Add a new issue and save it
        public static void AddIssue(Issue issue)
        {
            Issues.Add(issue);

            SaveIssues();
        }

        // Save all issues to issues.txt
        private static void SaveIssues()
        {
            using (StreamWriter writer = new StreamWriter(issuesFilePath, false))
            {
                foreach (Issue issue in Issues)
                {
                    writer.WriteLine(
                        $"{Clean(issue.Location)}|" +
                        $"{Clean(issue.Category)}|" +
                        $"{Clean(issue.Description)}|" +
                        $"{Clean(issue.MediaPath)}|" +
                        $"{issue.ReportDate:O}|" +
                        $"{Clean(issue.Status)}"
                    );
                }
            }
        }

        // Load saved issues back into the List
        private static void LoadIssues()
        {
            if (!File.Exists(issuesFilePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(issuesFilePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');

                if (parts.Length != 6)
                {
                    continue;
                }

                Issue issue = new Issue(
                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3]
                );

                if (DateTime.TryParse(parts[4],  null, DateTimeStyles.RoundtripKind,out DateTime reportDate))
                {
                    issue.ReportDate = reportDate;
                }

                issue.Status = parts[5];

                Issues.Add(issue);
            }
        }

        // Prevent | from breaking our text-file format
        private static string Clean(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            return value
                .Replace("|", "/")
                .Replace("\r", " ")
                .Replace("\n", " ");
        }
    }
}