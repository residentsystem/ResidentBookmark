# Resident Bookmark
Save and manage URL addresses of specific Web pages for future reference.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine.

## Prerequisites
To start working on this project you need to download and install the following components:

* .NET Core SDK (Software Development Kit)
* Visual Studio Code (Code editor)
* git (Distributed version control system)
* Download the files from Github.
* Install and configure MySQL (optional)

## Download and install

### Install .NET Core SDK
1. Get the latest version of .NET Core on the <a href="https://dotnet.microsoft.com/download" target="_blank">dotnet</a> web site.

2. When the installation is complete, open a new command prompt and run the following command:

> \\> dotnet --list

3. The command should print out information about the version, the runtime environment and a list of .NET Core SDKs installed.

> .NET Core SDK (reflecting any global.json):<br>
> Version:   2.2.204<br>
> Commit:    8757db13ec<br>
>
> Runtime Environment:<br>
> OS Name:     Windows<br>
> OS Version:  10.0.17763<br>
> OS Platform: Windows<br>
> RID:         win10-x64<br>
> Base Path:   C:\Program Files\dotnet\sdk\2.2.204\<br>

### Install Visual Studio Code
1. Download the latest version of <a href="https://go.microsoft.com/fwlink/?LinkID=534107" target="_blank">Visual Studio Code</a> installer for Windows.

2. Once it is downloaded, run the installer (VSCodeUserSetup-{version}.exe).

3. By default, Visual Studio Code is installed under C:\users\{username \AppData\Local\Programs\Microsoft VS Code.

### Install Git
> This procedure assumes you want to use a distributed version control system to contribute to this project. Git is not mandatory to develop or to simply run an ASP.NET Core web application. In this case, simply download the repository from Github using the ZIP file option.   

1. Download the latest version of the <a href="https://git-scm.com/download/win" target="_blank">git</a> installer for Windows.

2. Run the installer (Git-{version}-64-bit.exe).

3. The installer allow you to select the default text editor for Git. Accept the default if you prefer to change this later. 

4. When the installation is complete, open Git Bash and run the following command:

> \\> git --version

5. The command should print out information about the version.

> git version 2.22.0.windows.1

### Clone this project from Github

Create a directory where you want the project and library to be cloned.

> \\> mkdir C:\ResidentSystemProject<br>
> \\> cd C:\ResidentSystemProject

#### Clone the project 

1. Open your browser and navigate to Github. Access the main page of the <a href="https://github.com/residentsystem/ResidentBookmark" target="_blank">repository</a>.

2. Under the repository name, click Clone or download.

3. In the Clone with HTTPs section, copy the clone URL for the repository.

4. Go back to your terminal and make sure you're still in the project root directory (C:\ResidentSystemApp).

5. Run git clone in your terminal and paste the URL from Step 3 to complete the command:

> \\>git clone https://github.com/residentsystem/ResidentSystemApp.git

6. Press Enter to clone the project.

## Verify the installation

1. Go into the project folder:

> \\> cd C:\ResidentSystemProject\ResidentSystemApp\ResidentBookmark

2. Run the application.

> \\> dotnet run

3. The command should print information about the hosting environment, url and port listening.

> Hosting environment: Development
> Content root path: C:\ResidentSystemProject\ResidentSystemApp\ResidentBookmark
> Now listening on: http://localhost:5001
> Application started. Press Ctrl+C to shut down.

4. Open your browser and navigate to http://localhost:5000.

5. The application will open and you can start creating and editing bookmarks.

## Setup the database for MySQL

The application is already configured to use SQLite and the database file already exist (Bookmark.db). The following section show you the steps you need to do to use MySQL instead.

1. Go to the project folder.

> \\> cd C:\ResidentSystem\ResidentSystemApp\ResidentBookmark

2. Open Data\BookmarkContext.cs and uncomment the optionsBuilder that use MySQL. Remove the double "/" in front of each lines so it look like this:

> optionsBuilder.UseMySql(_database.GetConnectionString(),
> new MySqlServerVersion(new Version(8, 0, 19)), 
> mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend));

3. Modify Properties\launchSettings.json with the environment you wish to use. Development is already used by SQLite so lets use staging. 

> "ASPNETCORE_ENVIRONMENT": "Staging"

4. Assign the connection string to the environment variable named CONNSTR_BOOKMARK.

Windows Command Prompt:
> set CONNSTR_BOOKMARK="server=localhost;port=3306;database=database;user=username;password=password"

Linux Bash:
> export CONNSTR_BOOKMARK="server=localhost;port=3306;database=database;user=username;password=password"

Note: Use connection details related to your environment.

5. Create the database.

> \\>dotnet ef migrations add CreateStagingDatabase -o Migrations\Staging
> \\>dotnet ef database update

Important: You will need to have a MySQL server up and running before creating the database. Please find more information about installing MySQL Server on your system.

- <a href="https://dev.mysql.com/doc/mysql-installation-excerpt/8.0/en/windows-installation.html" target="_blank"> Install MySQL on Windows</a>.

- <a href="https://dev.mysql.com/doc/mysql-installation-excerpt/8.0/en/linux-installation.html" target="_blank"> Install MySQL on Linux</a>.

### Host and deploy ASP.NET Core

When done publishing the app, you need to deploy the published files to a folder on the hosting server. Then you need to set up a process manager that starts the app when requests arrive and restarts the app after it crashes or the server reboots. For configuration of a reverse proxy, set up a reverse proxy to forward requests to the app. For more information, read on how to <a href="https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-2.2" target="_blank">host ASP.NET Core on Windows with IIS</a>.

## Built With
* Visual Studio Code - Code editor
* .NET Core SDK 7.0.100 - Open-source development platform

## Contributing
Please read CONTRIBUTING for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning
We use SemVer for versioning. For the versions available, see the tags on this repository.

## Authors
Eric Lacroix - Initial work

See also the list of contributors who participated in this project.

## License
This project is licensed under the MIT License - see the LICENSE file for details
