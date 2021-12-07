# potential-parakeet
ASP.NET CORE 5
WEB API
CQRS 

Notification Scheduling system.
--- Setup ---

Start app. Swagger Endpoints: To Create Company and it's notification schedule: /api/Company

To Get Created Schedule: /api/Schedule/{CompanyId}

//In case DbMigration doesn't not work. //Delete Migrations folder in Infrastructure. //Open cmd in NotificationSchedulingSystem.Infrastructure and run

"dotnet-ef migrations add Init_Read --context ReadDbContext --startup-project ../NotificationSchedulingSystem.Web/ -o EF/Migrations"

//Try running app again.
