# RemindersApp

**Version 1.0.0**

This application is a working prototype that effectively mimics the functionality of a reminder app. It allows a user to enter information about their upcoming event and choose how many days prior to their event, they would like to recieve an email reminder. 

The application was developed in C# with the use of Windows Presentation Foundation (WPF) framework to design the user interface. It is supportd with a MySQL Database which stores all reminders set by the user. The project also consists of a windows service that will run automotically in the background and poll the database for changes, every 10 minutes.

# Service Installation
## In order to install the reminder service and have it run, the following must be done
1. After having cloned the repo, open a command prompt **as an administrator**
2. Navigate to the location of the repository then run the following command:
  -  >cd RemindersApp\SMTPService\bin\Debug
3. Next, run the following command:
  - >SMTPService.exe install start
4. If done correctly, the following screen can be seen:
![Install](https://user-images.githubusercontent.com/41601768/149646638-e050819e-1d59-428b-bb82-8867a5442f19.PNG)


## Tech Stack
- **User Interface**: Windows Presentation Foundation (WPF)
- **Languages Used**: C#
- **Database**: MySQL
- **Deployment**: Windows Installer

## Features
- Minimalistic and easy to use user interface
- Clear and concise feedback on user input and selections
- Functionialities of a reminder app which includes:
  - Deleting an active reminder
  - Setting a reminder:
    - Date selection for the event
    - Time selection for the event
    - Title/description of the event
    - Email to be used for the event
    - Selection for when the user would like the reminder to be sent
 
 ## Future Features
 - Sending not only email reminder but sms and desktop notifications
 - Mobile compatibility
 - Ability to edit an existing reminder
 - Ability to choose specific time for the reminder.

# Application Preview
## 1. App startup page
![Welcome](https://user-images.githubusercontent.com/41601768/149637402-b4171c9d-e6af-46b5-ad19-eab953fea261.PNG)

Upon launching the app, the user is welcomed by the username that they have set on their machine. The user has the option of setting a new reminder or deleting an active one.

## 2. Setting a reminder
![SetAReminder](https://user-images.githubusercontent.com/41601768/149637637-58dbd0c5-633b-49bf-8db8-e68dace4475d.PNG)

If the user chooses to set a new reminder, they are directed to this page. The user will be able to select a date and time for their event, enter a title/description for their event, as well as an email that they would like the reminder to be sent to. Furthermore, depending on the selected date, the user can choose when they would like the reminder to be sent.

## 3. Deleting a reminder
![DeleteAReminder](https://user-images.githubusercontent.com/41601768/149637944-70bda675-810e-4160-888d-fa777cce0d45.PNG)

If the user chooses to delete a reminder, they will be directed to this page which displays a list of all active reminders. Upon selecting a reminder, the "Remove Reminder" button is enabled which can be used to remove the reminder from the list.

## 4. Email
![Email](https://user-images.githubusercontent.com/41601768/149638018-cfecb392-b7a2-4f3f-81b7-f7d4be067ea6.PNG)

When the service detects an active reminder, which matches the conditions selected by the user, it sends an email containing the event title/description, as well as its date and time.
