# ClassroomSailor.API
API in dotnet core for ClassroomSailor API consumers.

App CLI commands (to be run on the root path)

1. build: dotnet restore
2. run: dotnet run

Database CLI Commands (to be run from the path ~/ClassroomSailor.DAL)

1. dotnet ef migrations add <migration-name> -s ../ClassroomSailor.API/
2. dotnet ef database update -s ../ClassroomSailor.API/

Dev URL: http://localhost:49837/
