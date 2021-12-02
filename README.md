# SourcefulTask

Back-end for test task.
Implemented Clear Architecture ans CQRS pattern in ASP.NET Core WebAPI.
3 simple Tables: Users(main) - Addresses - Films.
I did't code validation and authentification (for simply testing).
And I did't implement Unit tests and Logger.

When start By default you get Swagger page for simple testing.

NOTE! Before migration - please change Connection string in appsettings.json, like this:

 "ConnectionStrings": {
    "DbConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sourceful;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
  
