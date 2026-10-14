using System;
using System.Collections.Generic;
using System.IO;

namespace MunicipalServicesApp
{
    public static class UserManager
    {
        // Dictionary:
        // Key   = Email address
        // Value = User object
        private static readonly Dictionary<string, User> users = new Dictionary<string, User>(StringComparer.OrdinalIgnoreCase);

        // Save users inside the project's Data folder
        private static readonly string usersFilePath = DataPathHelper.GetDataFilePath("users.txt");

        // Static constructor runs automatically when UserManager
        // is first used.
        static UserManager()
        {
            LoadUsers();

            // Make sure the default administrator always exists.
            if (!users.ContainsKey("admin@municipality.gov.za"))
            {
                User admin = new User( "Municipal Administrator",  "admin@municipality.gov.za", "Admin@123", "Admin");

                users.Add(admin.Email, admin);

                SaveUsers();
            }
        }

        // Registers a new citizen account
        public static bool RegisterUser(string fullName, string email,string password)
        {
            email = email.Trim();

            // Dictionary makes checking duplicate emails simple.
            if (users.ContainsKey(email))
            {
                return false;
            }

            // Citizens cannot register themselves as administrators.
            User newUser = new User( fullName.Trim(),email,password, "Citizen");

            users.Add(email, newUser);

            // Save the updated Dictionary to users.txt.
            SaveUsers();

            return true;
        }

        // Checks the user's login credentials
        public static User AuthenticateUser(string email, string password)
        {
            email = email.Trim();

            // Find the user using the email Dictionary key.
            if (users.TryGetValue(email, out User user))
            {
                if (user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        // Saves all users from the Dictionary into users.txt
        private static void SaveUsers()
        {
            using (StreamWriter writer = new StreamWriter(usersFilePath, false))
            {
                foreach (User user in users.Values)
                {
                    writer.WriteLine(
                        $"{user.FullName}|{user.Email}|{user.Password}|{user.Role}"
                    );
                }
            }
        }

        // Loads users from users.txt back into the Dictionary
        private static void LoadUsers()
        {
            if (!File.Exists(usersFilePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(usersFilePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');

                if (parts.Length != 4)
                {
                    continue;
                }

                string fullName = parts[0];
                string email = parts[1];
                string password = parts[2];
                string role = parts[3];

                if (!users.ContainsKey(email))
                {
                    User user = new User(fullName, email,password, role );

                    users.Add(email, user);
                }
            }
        }
    }
}