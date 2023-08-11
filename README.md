Add a file called appsettings.json to PierresTreatsAndFlavors. Change the word "add" to use pass and uid(username) used in MySQL, note also remove the quotes around add.

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=pierres_treats_with_auth;uid="add";pwd="add";"
  }
}

Notes on authentication setup

To create a migration in MySQL
$ dotnet ef migrations add Initial

To update MySQL with all migrations
$ dotnet ef database update

packages you need are in PierresTreatsAndFlavors.csproj

For Entity Framework Core, we use a tool called dotnet-ef to create migrations and update our database. We'll install this tool globally so that it is always available in all of our projects. Run the following command in your terminal now:
$ dotnet tool install --global dotnet-ef --version 6.0.0

In order to use dotnet-ef, we also need to install the Microsoft.EntityFrameworkCore.Design package in our ASP.NET Core projects. Within the production directory of our To Do List app, run the following command:
$ dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0
