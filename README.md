# Bangazon Financial Report 

## Dependencies

To ensure that the  Bangazon Financial Report App works as intended make sure that you have the following dependencies and technologies on your local machine

- dotnet 

If you need to download dotnet onto your local machine, visit [Microsoft's Documentation](https://www.microsoft.com/en-us/download/details.aspx?id=30653)

- DB Browser for SQLite

If you need to download DB Browser onto your local machine, visit [DB Browser's Documentation](http://sqlitebrowser.org/)

## Installation OSX/UNIX

Clone or fork the project. Navigate to where the project is saved on your machine. For all of the following commands enter them into your bash terminal to ensure that the application is installed correctly


Determine which directory you would like to store your database file and create a blank file with the following commands.
```Bash
touch "/path/to/bangazon.db"
```

On initial installation of the Banagazon CLI application you must set an environment variable to your local database.
```Bash
export REPORTING_DB_PATH="/path/to/bangazon.db"
```


Once your local variables have been set run the following commands to start.
```Bash
dotnet restore
dotnet run
```

## Installation Windows

Clone or fork the project. Navigate to where the project is saved on your machine. For all of the following commands enter them into your bash terminal to ensure that the application is installed correctly


Determine which directory you would like to store your database file and create a blank file with the following commands.
```Bash
touch "/path/to/bangazon.db"
```


On initial installation of the Banagazon CLI application you must set an environment variable to your local database.
```Bash
$env:REPORTING_DB_PATH="/path/to/bangazon.db"
```

Once your local variables have been set run the following commands to start.
```Bash
dotnet restore
dotnet run
```
