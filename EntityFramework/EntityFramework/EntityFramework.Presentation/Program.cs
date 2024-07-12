// See https://aka.ms/new-console-template for more information

using EntityFramework.Presentation.UI;
using Serilog;
using Serilog.Core;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/mylog.txt")
    .CreateLogger();
Log.Information("Application Started");
Log.Debug("This is a debug message");


//Controller---> Services(business logic)--->Repositories(will take to databse)--> data access layer(entity framework, dapper)

// ManageDepartment manageDepartment = new ManageDepartment();
// manageDepartment.Run();

try
{
    ManageEmployee manageEmployee = new ManageEmployee();
    manageEmployee.Run();
    //throw new InvalidOperationException("An exception occured");
}
catch (Exception ex)
{
    Log.Warning("An unexpeted warning occured");
    Log.Error("An error occured while processing");
    Log.Fatal("A fatal error has occured");
}


//RequestModel---> Entity(for request from users)
//Entity ---> ResponseModel (for response from the database)

//ResponseModel--> will contain data that you want to display in UI


//Serilog : third party library for logging
