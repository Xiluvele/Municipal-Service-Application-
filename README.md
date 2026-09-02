# Municipality Citizen Reporting Application

## 1. Project Overview

The Municipality Citizen Reporting Application is a C# Windows Forms application developed to make it easier for citizens to report municipal issues and service requests.

The application provides a simple interface where citizens can enter information about an issue, select the relevant category, provide the location and description, and attach supporting files such as images or PDF documents.

The main purpose of the application is to provide a user-friendly way for citizens to submit issues while giving clear feedback throughout the reporting process.

---

## 2. Features

The application includes the following features:

* Select an issue category from a dropdown list.
* Enter the location where the issue occurred.
* Provide a description of the issue.
* Attach supporting files using a file selection dialog.
* Display the selected attachment.
* Validate required information before submission.
* Display progress and feedback during submission.
* Display a confirmation message after a successful submission.
* Clear the form to allow a new report to be entered.
* Navigate back to the previous screen.
* Store submitted issues using an `Issue` object and a `List<Issue>`.

---

## 3. Issue Categories

The application provides several categories that citizens can use when reporting an issue:

* Roads & Potholes
* Water & Sanitation
* Electricity
* Waste Management
* Public Safety
* Parks & Recreation
* Other

These categories help organise the different types of issues that can be reported.

---

## 4. Technologies Used

The application was developed using the following technologies:

| Technology     | Purpose                                |
| -------------- | -------------------------------------- |
| C#             | Main programming language              |
| .NET Framework | Application framework                  |
| Windows Forms  | Graphical user interface               |
| Visual Studio  | Development environment                |
| `List<Issue>`  | Temporary storage of submitted reports |
| OpenFileDialog | Selecting supporting files             |

---

## 5. System Requirements

To run the application, the computer should have:

* Windows operating system
* Visual Studio with Windows Forms support
* .NET Framework compatible with the project
* Sufficient storage space for the application and supporting files

---

## 6. How to Run the Application

1. Clone or download the project from the repository.
2. Open the solution file (`.sln`) in Visual Studio.
3. Allow Visual Studio to load the project dependencies.
4. Build the solution using **Build → Build Solution**.
5. Run the application using the **Start** button or press `F5`.
6. Navigate to the reporting section.
7. Complete the required fields.
8. Attach a supporting file if required.
9. Select **Submit** to submit the report.

---

## 7. How to Report an Issue

To submit a report:

### Step 1: Select a Category

Choose the category that best describes the issue.

### Step 2: Enter the Location

Enter the location where the issue occurred.

### Step 3: Describe the Issue

Provide enough information to explain the problem clearly.

### Step 4: Attach Supporting Evidence

Use the **Attach File** button to select a supporting image or document.

### Step 5: Submit the Report

Click the **Submit** button.

The application validates the information before creating the report. If the information is valid, the issue is added to the list of reported issues and the user receives confirmation.

---

## 8. Validation

The application performs validation before a report is submitted.

The following information is checked:

* A category must be selected.
* A location must be provided.
* A description must be provided.

If required information is missing, the application displays a warning message and allows the user to correct the information before submitting.

This helps prevent incomplete reports from being submitted.

---

## 9. File Attachments

The application uses the Windows Forms `OpenFileDialog` to allow users to select supporting files.

Supported file types include:

* JPG
* JPEG
* PNG
* PDF

The selected file name is displayed to the user after the file has been selected.

---

## 10. Issue Data Structure

Each submitted report is represented using the `Issue` class.

The class contains information such as:

```text
Category
Location
Description
FilePath
DateReported
```

Submitted issues are stored in a:

```csharp
List<Issue>
```

This allows multiple reports to be stored during the application's execution.

---

## 11. User Feedback

The application provides feedback to the citizen during the reporting process.

A progress indicator is used to show that the report is being processed. Status messages provide additional information about what the application is doing.

After successful submission, the user receives a confirmation message.

This helps the user understand whether their report has been successfully processed.

---

## 12. Testing

The application was tested to ensure that the main functionality works as expected.

| Test                       | Expected Result                     |
| -------------------------- | ----------------------------------- |
| Open application           | Application opens successfully      |
| Open category dropdown     | Categories are displayed            |
| Submit without category    | Validation message is displayed     |
| Submit without location    | Validation message is displayed     |
| Submit without description | Validation message is displayed     |
| Enter valid report details | Information is accepted             |
| Attach a file              | File selection dialog opens         |
| Select a file              | Selected file is displayed          |
| Submit valid report        | Issue is added to the issue list    |
| Submit valid report        | Success message is displayed        |
| Click Clear                | Form fields are reset               |
| Click Back                 | User returns to the previous screen |

---

## 13. Project Structure

The main project files include:

```text
MunicipalityCitizenReporting
│
├── ReportIssueForm.cs
├── ReportIssueForm.Designer.cs
├── Issue.cs
├── Program.cs
└── README.md
```

The exact file structure may differ depending on the forms and additional components included in the project.

---

## 14. Future Improvements

The current application stores issues in memory using a `List<Issue>`. If the system were developed further, the following features could be added:

* Database storage for permanent issue records.
* User registration and login.
* A municipality administrator dashboard.
* Issue status tracking.
* Notifications when an issue is updated.
* Search and filtering of reported issues.
* GPS/location services.
* Improved attachment management.
* Cloud storage for uploaded files.
* Reporting and analytics.

---

## 15. Conclusion

The Municipality Citizen Reporting Application provides a simple way for citizens to report municipal issues. The application focuses on usability by providing clear input fields, validation, file attachment functionality, progress feedback and confirmation messages.

The project also demonstrates the use of C# programming concepts such as classes, objects, collections, event handling, validation and Windows Forms controls.
