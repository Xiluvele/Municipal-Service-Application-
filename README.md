# Municipal Services Application

## 1. Project Overview

The Municipal Services Application is a C# Windows Forms application developed to support communication between citizens and a municipality.

The application started as a citizen issue-reporting system and was expanded to include local events, municipal announcements, user accounts and an administration section.

Citizens can register and log in to the application, report municipal issues, view their reported issues, browse upcoming local events and read important municipal announcements. Events can also be searched by keyword, category and date.

The application includes a recommendation feature that keeps track of the event categories searched by a citizen and uses this information to recommend related upcoming events.

Municipal administrators have a separate dashboard where they can view reported issues and manage events and announcements.

The project was developed as a C# .NET Framework Windows Forms application and demonstrates the practical use of collections and data structures such as Lists, Dictionaries, Sorted Dictionaries, HashSets, Stacks, Queues and a Priority Queue.

---

## 2. Main Features

The application currently provides two main areas of functionality:

### Citizen Features

Citizens can:

- Register an account.
- Log in using their registered account.
- Report municipal issues.
- Select an issue category.
- Enter the location of an issue.
- Provide a description of the problem.
- Attach supporting images or PDF documents.
- View reported issues.
- View upcoming municipal events.
- Search events using keywords.
- Filter events by category.
- Filter events by date.
- View important municipal announcements.
- Receive event recommendations based on previous category searches.
- Log out of the application.

### Administrator Features

Municipal administrators can:

- Log in using the administrator account.
- Access a separate Admin Dashboard.
- View the total number of reported issues.
- View the number of upcoming events.
- View the number of municipal announcements.
- View all reported citizen issues.
- Add municipal events.
- Edit existing events.
- Delete events.
- Add municipal announcements.
- Edit announcements.
- Delete announcements.
- Assign different priorities to announcements.

---

## 3. Login and Registration

The application uses a login and registration system to separate normal citizens from municipal administrators.

A citizen can create an account by providing the required registration information. After registration, the citizen can use the registered credentials to log in.

The system also contains an administrator role. When an administrator logs in, the application opens the Admin Dashboard instead of the normal citizen dashboard.

The two roles used in the application are:

```text
Citizen
Admin
```

This allows the application to provide different functionality depending on the type of user who has logged in.



**Explanation:**  
The Login screen is the first screen presented to the user. Registered citizens can enter their email address and password to access the application. The same login process is also used by the administrator, with the application opening the correct dashboard according to the user's role.


## 4. Citizen Dashboard

After a citizen logs in successfully, the main citizen dashboard is displayed.

The dashboard provides access to the main municipal services currently available in the application.

These include:

- Report Issues
- Local Events and Announcements
- Service Request Status

The Service Request Status functionality is reserved for the next part of the project.

The dashboard also provides a quick overview of information available to the citizen.



## 5. Reporting a Municipal Issue

The Report Issue feature allows citizens to submit municipal problems and service requests.

To submit a report, the citizen:

1. Selects an issue category.
2. Enters the location of the problem.
3. Provides a description.
4. Attaches supporting evidence if available.
5. Submits the report.

Before the report is accepted, the application validates the required information.

### Issue Categories

The available issue categories include:

- Roads & Potholes
- Water & Sanitation
- Electricity
- Waste Management
- Public Safety
- Parks & Recreation
- Other

These categories make it easier to organise the different types of municipal problems reported by citizens.


---

## 6. Validation and User Feedback

Validation is performed before an issue can be submitted.

The application checks that:

- A category has been selected.
- A location has been entered.
- A description has been provided.

If required information is missing, a warning message is displayed and the citizen is given an opportunity to correct the information.

The reporting form also provides feedback during the submission process. A progress indicator and status messages help the citizen understand what is happening.

After a valid report has been submitted, a confirmation message is displayed.

---

## 7. File Attachments

The issue-reporting section uses the Windows Forms `OpenFileDialog` to allow supporting evidence to be attached to a report.

Supported files include:

- JPG
- JPEG
- PNG
- PDF

The selected file is displayed on the reporting form so that the citizen can confirm the correct attachment was selected.

---

## 8. Viewing Reported Issues

Submitted issues can be viewed through the My Reported Issues section.

The issue information includes details such as:

- Location
- Category
- Description
- Attachment
- Date reported
- Status



# Part 2 – Local Events and Announcements

## 9. Local Events and Announcements

The second part of the application introduces Local Events and Announcements.

Citizens can use this section to view upcoming activities taking place within the municipality and read important municipal notices.

The screen contains:

- Important Announcements
- Event Search
- Category Filtering
- Date Filtering
- Upcoming Events
- Recommended Events



## 10. Searching for Events

Citizens can search for upcoming events using different search options.

Events can be searched by:

- Keyword
- Category
- Date

For example, a citizen interested in sport can select the Sports category and search for matching upcoming events.

The application uses the event collections maintained by `EventManager` to perform these searches.


## 11. Event Recommendation Feature

The application includes a basic recommendation feature to make the events section more useful to citizens.

When a citizen searches using an event category, the application records the search preference.

For example:

```text
Sports = 3 searches
Education = 1 search
Culture = 1 search
```

In this example, Sports becomes the citizen's most frequently searched category.

The application can then recommend upcoming Sports events.

A `Dictionary<string, int>` is used to keep track of how often each category has been searched.


## 12. Data Structures Used

Several data structures are used in the Local Events and Announcements functionality.

### List

A `List<LocalEvent>` is used as the main event collection.

It provides a central collection that can be updated when an administrator adds, edits or deletes an event.

### SortedDictionary

A:

```csharp
SortedDictionary<DateTime, List<LocalEvent>>
```

organises events according to their dates.

Because the keys remain sorted, events can be processed in chronological order.

### Dictionary

A:

```csharp
Dictionary<string, List<LocalEvent>>
```

groups events according to their categories.

This is useful when a citizen searches for a particular category.

Another dictionary:

```csharp
Dictionary<string, int>
```

records category search preferences and supports the recommendation feature.

### HashSet

A:

```csharp
HashSet<string>
```

stores unique event categories.

A HashSet prevents the same category from being stored repeatedly.

### Stack

A:

```csharp
Stack<string>
```

is used for recent searches.

A Stack follows the Last In, First Out (LIFO) principle, meaning the most recent search is placed at the top.

### Queue

A:

```csharp
Queue<LocalEvent>
```

stores upcoming events.

The Queue follows the First In, First Out (FIFO) principle.

### Announcement Priority Queue

Municipal announcements use a custom priority queue based on:

```csharp
SortedDictionary<int, Queue<Announcement>>
```

The priority levels are:

```text
1 = Critical
2 = High
3 = Normal
```

The `SortedDictionary` keeps the priorities ordered, while each priority contains a `Queue<Announcement>`.

This means critical announcements are processed before high and normal announcements. Announcements that have the same priority follow First In, First Out order.

---

# Administration

## 13. Admin Dashboard

Administrators are provided with a separate dashboard.

The dashboard gives the administrator an overview of:

- Reported Issues
- Upcoming Events
- Announcements

It also provides links to the management screens.

### Screenshot – Admin Dashboard

> Add screenshot: `Screenshots/09-admin-dashboard.png`

```markdown
![Admin Dashboard](Screenshots/09-admin-dashboard.png)
```

**Explanation:**  
The Admin Dashboard gives the municipality a quick overview of the information currently stored by the application. The totals are updated from the application's collections, and the administrator can navigate to the relevant management screens.

---

## 14. Viewing Citizen Issues as an Administrator

The administrator can open the reported issues section to view reports submitted through the citizen reporting form.

### Screenshot – Admin Reported Issues

> Add screenshot: `Screenshots/10-admin-reported-issues.png`

```markdown
![Admin Reported Issues](Screenshots/10-admin-reported-issues.png)
```

**Explanation:**  
The administrator's reported issues screen provides a central view of citizen reports. The information is presented in a table so that municipal staff can review the location, category, description, date and current status of each report.

---

## 15. Managing Municipal Events

Administrators can manage the events displayed to citizens.

The Manage Events screen allows an administrator to:

- Add a new event.
- Edit an existing event.
- Delete an event.
- View all stored events.

When an event is added, edited or deleted, the application's event data structures are rebuilt so that the search, category and upcoming-event information stays up to date.


---

## 16. Managing Municipal Announcements

Administrators can also manage the notices displayed to citizens.

The Manage Announcements screen allows the administrator to:

- Add an announcement.
- Edit an announcement.
- Delete an announcement.
- Select a priority.
- View announcements in priority order.

The available priorities are Critical, High and Normal.

If an announcement's priority changes, the Priority Queue is rebuilt so that the notice appears in the correct position.


## 17. Data Storage

The application uses text files to keep important information available after the program has been closed.

The files are stored in the project's `Data` folder.

```text
Data
│
├── users.txt
├── issues.txt
├── events.txt
└── announcements.txt
```

### `users.txt`

Stores registered user information used by the login and registration functionality.

### `issues.txt`

Stores municipal issues submitted through the Report Issue form.

### `events.txt`

Stores municipal events created and managed by the administrator.

### `announcements.txt`

Stores municipal announcements managed through the Priority Queue.

This file-based approach is suitable for the current project and allows the information to remain available between application sessions without requiring a database.

For a production system, sensitive information such as passwords should not be stored as plain text. Password hashing and a secure database would be required.

---

## 18. Main Classes

The application is divided into several classes and forms, each with a specific responsibility.

Some of the main files are:

```text
MunicipalServicesApp
│
├── Program.cs
│
├── LoginForm.cs
├── RegisterForm.cs
├── User.cs
├── UserManager.cs
│
├── MainForm.cs
├── ReportIssueForm.cs
├── MyIssuesForm.cs
├── Issue.cs
├── IssueManager.cs
│
├── LocalEventsForm.cs
├── LocalEvent.cs
├── EventManager.cs
│
├── Announcement.cs
├── AnnouncementPriorityQueue.cs
│
├── AdminDashboardForm.cs
├── AdminIssuesForm.cs
├── ManageEventsForm.cs
├── EventForm.cs
├── ManageAnnouncementsForm.cs
├── AnnouncementForm.cs
│
├── DataPathHelper.cs
│
├── Data
│   ├── users.txt
│   ├── issues.txt
│   ├── events.txt
│   └── announcements.txt
│
└── README.md
```

The Windows Forms Designer files and resource files are also part of the project but are not shown above to keep the structure easy to read.

---

## 19. Technologies Used

| Technology / Concept | Use in the Application |
|---|---|
| C# | Main programming language |
| .NET Framework | Application framework |
| Windows Forms | Desktop user interface |
| Visual Studio | Development environment |
| `List<T>` | Main collections |
| `Dictionary<TKey,TValue>` | Event categories and search preferences |
| `SortedDictionary<TKey,TValue>` | Date ordering and announcement priorities |
| `HashSet<T>` | Unique event categories |
| `Stack<T>` | Recent searches |
| `Queue<T>` | Upcoming events and announcement ordering |
| `OpenFileDialog` | Selecting issue attachments |
| Text files | Persistent application data |

---

## 20. How to Run the Application

To run the project:

1. Clone or download the project repository.
2. Open the project folder.
3. Open the `.sln` solution file in Visual Studio.
4. Allow Visual Studio to finish loading the project.
5. Select **Build → Build Solution**.
6. Confirm that the project builds without errors.
7. Press `F5` or select **Start**.
8. The Login screen will open.
9. Register a citizen account or log in using an existing account.
10. After login, use the dashboard to access the available municipal services.

The application stores its runtime information in the `Data` folder, so the data files should remain with the project.

---

## 21. Testing

The application was tested throughout development to make sure the main features work together correctly.

| Test | Expected Result |
|---|---|
| Start application | Login screen opens |
| Register citizen | Citizen account is created |
| Login with valid citizen details | Citizen Dashboard opens |
| Login with administrator details | Admin Dashboard opens |
| Submit issue without category | Validation warning is displayed |
| Submit issue without location | Validation warning is displayed |
| Submit issue without description | Validation warning is displayed |
| Attach supporting file | Selected file is displayed |
| Submit valid issue | Issue is saved successfully |
| Open My Reported Issues | Reported issues are displayed |
| Open Local Events | Upcoming events and announcements display |
| Search by keyword | Matching events are displayed |
| Filter by category | Events from the selected category are displayed |
| Filter by date | Events for the selected date are displayed |
| Search categories repeatedly | Recommendations reflect search preference |
| Add event as Admin | Event appears in Manage Events |
| Edit event as Admin | Updated information is displayed |
| Delete event as Admin | Event is removed |
| Restart application | Saved events remain available |
| Add announcement as Admin | Announcement appears in priority order |
| Edit announcement priority | Announcement moves to the correct priority |
| Delete announcement | Announcement is removed |
| Restart application | Saved announcements remain available |
| Return to Citizen view | Updated events and announcements are displayed |

---

## 22. Source Code Examples

The following sections highlight some of the main implementation areas used in the project.

### Event Category Dictionary

```csharp
public static Dictionary<string, List<LocalEvent>>
    EventsByCategory =
    new Dictionary<string, List<LocalEvent>>(
        StringComparer.OrdinalIgnoreCase);
```

This dictionary groups events by category and is used when filtering events.

### Event Date Sorted Dictionary

```csharp
public static SortedDictionary<DateTime, List<LocalEvent>>
    EventsByDate =
    new SortedDictionary<DateTime, List<LocalEvent>>();
```

The `SortedDictionary` keeps event dates in order, which makes it useful when displaying upcoming events chronologically.

### Upcoming Events Queue

```csharp
public static Queue<LocalEvent> UpcomingEvents =
    new Queue<LocalEvent>();
```

The Queue stores upcoming events using FIFO ordering.

### Recent Searches Stack

```csharp
public static Stack<string> RecentSearches =
    new Stack<string>();
```

The Stack records recent searches using LIFO ordering.

### Unique Categories HashSet

```csharp
public static HashSet<string> Categories =
    new HashSet<string>(
        StringComparer.OrdinalIgnoreCase);
```

The HashSet prevents duplicate event categories.

### Announcement Priority Queue

```csharp
private readonly SortedDictionary<int, Queue<Announcement>>
    priorityQueue =
    new SortedDictionary<int, Queue<Announcement>>();
```

This structure combines a `SortedDictionary` with queues to process announcements according to priority while preserving FIFO ordering for announcements with the same priority.

### Recommendation Preferences

```csharp
public static Dictionary<string, int> SearchPreferences =
    new Dictionary<string, int>(
        StringComparer.OrdinalIgnoreCase);
```

This dictionary records how frequently each event category is searched and is used to identify the citizen's preferred category.

---

## 23. Current Project Status

The following functionality has been completed:

```text
Part 1
✓ Citizen issue reporting
✓ Issue categories
✓ Validation
✓ File attachments
✓ Submission feedback
✓ Issue storage
✓ View reported issues

Part 2
✓ User registration
✓ Login and role handling
✓ Citizen Dashboard
✓ Admin Dashboard
✓ Local events
✓ Municipal announcements
✓ Keyword search
✓ Category filtering
✓ Date filtering
✓ Recommendation feature
✓ List
✓ Dictionary
✓ SortedDictionary
✓ HashSet
✓ Stack
✓ Queue
✓ Announcement Priority Queue
✓ Admin event management
✓ Admin announcement management
✓ Persistent text-file storage

Part 3
○ Service Request Status
○ Additional issue/status functionality
```

---

## 24. Future Improvements

The application can be expanded further in the next part of the project.

Planned or possible improvements include:

- Service request status tracking.
- Allowing citizens to view only the issues associated with their own account.
- Allowing administrators to update the status of reported issues.
- Notifications when an issue status changes.
- Improved attachment management.
- Database storage instead of text files.
- Password hashing and improved authentication security.
- Reporting and analytics.
- Additional filtering and searching of service requests.

Some of these improvements are planned for Part 3 of the project.

---

## 25. Conclusion

The Municipal Services Application has developed from a basic issue-reporting form into a broader municipal services system.

Citizens can report problems, view municipal events, read important announcements and receive event recommendations based on their searches. Administrators have their own dashboard for viewing reported issues and maintaining the events and announcements shown to citizens.

The project also demonstrates the practical use of C# data structures rather than using them only as theoretical examples. Dictionaries support searching and recommendations, a SortedDictionary organises events by date, a HashSet keeps categories unique, a Stack records recent searches, Queues organise upcoming information, and the announcement Priority Queue ensures urgent notices are handled first.

The next stage of development will focus on Service Request Status and further improvements to the way citizen reports are managed.
