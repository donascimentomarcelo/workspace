## run locally

dotnet watch run

## create migration

dotnet ef migrations add Migration_Name -o Data/Migrations

dotnet ef migrations remove

## create table

dotnet ef database update

## Apply DDD

# create new solution

dotnet new sln -n ProEvents

# create new csharp project

dotnet new classlib -n ProEvents.Persistence

dotnet new classlib -n ProEvents.Domain

dotnet new classlib -n ProEvents.Application

# add project to solution

dotnet sln ProEvents.sln add ProEvents.Application

# associate projects each other

dotnet add ProEvents.API/Event.API.csproj reference ProEvents.Application

dotnet add ProEvents.Application/ProEvents.Application.csproj reference ProEvents.Domain

dotnet add ProEvents.Application/ProEvents.Application.csproj reference ProEvents.Persistence

dotnet add ProEvents.Persistence/ProEvents.Persistence.csproj reference ProEvents.Domain

# crating migrations and adding identity

dotnet ef migrations add Add-Identity -p ProEvents.Persistence/ -s ProEvents.API/

dotnet ef database update -s ProEvents.API
