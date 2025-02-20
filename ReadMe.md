##################################################################################

This app takes an ICS file and splits it into two new files, 
formatting each file as necessary for importing in the likes of Google Calendar. 

##################################################################################

"Another .ics splitter?", you say.
Answer: Why not? :) I had to split a large .ics manually in order to import it into
Google Calendar once and it was a headache. At the time, I couldn't find a user-friendly
GUI app that could do this for me. So I hope this helps at least one person out there. 

Setup:

1. To install the app use the setup.exe inside the folder.
2. If your PC doesn't have .NET installed, you will be prompted to download and install it. 
The app runs on it.
3. After this, you should be able to open the app from the Start Menu and use it.

Using the app:

In case you get the "UnathorizedAccessException" error when selecting a file, 
place your .ics file where no Admin permission is required to access and edit it in the directory.
The app creates two smaller .ics files and always tries to place them in C:\\. 
So make sure your Windows user has writing permissions there.
You can split the resulting files as many times as necessary until you end up with many smaller
files that are below the .ics file size limit for importing. In Google Calendar, the maximum size
for imported calendar files is 1 MB, per this Help Center article: https://support.google.com/calendar/answer/45654



This app was published to ClickOnce in Visual Studio to make it as lightweight as possible.
It doesn't modify or access any other data except the .ics file provided by the user 
through the file selection button.


Question mark PNG used in GUI by Freepik;
App icon by ByteDance IconPark

Runs on .NET 8. Created in Visual Studio with Windows Forms and C#.

Free to modify, improve and to distribute free of charge and in good faith.
