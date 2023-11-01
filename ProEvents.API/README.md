// create migration

dotnet ef migrations add Migration_Name -o Data/Migrations

dotnet ef migrations remove

// create table

dotnet ef database update


// Apply DDD

dotnet new sln -n ProEvents

dotnet new classlib -n ProEvents.Persistence

dotnet new classlib -n ProEvents.Domain

dotnet new classlib -n ProEvents.Application

dotnet sln ProEvents.sln add ProEvents.Application

dotnet add ProEvents.API/Event.API.csproj reference ProEvents.Application

dotnet add ProEvents.Application/ProEvents.Application.csproj reference ProEvents.Domain
dotnet add ProEvents.Application/ProEvents.Application.csproj reference ProEvents.Persistence

dotnet add ProEvents.Persistence/ProEvents.Persistence.csproj reference ProEvents.Domain