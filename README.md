# sample-core-bank


#### MIGRATIONS
On the startup project
> cd src/SampleCoreBank.Presentations.WebAPI

Add package Microsoft.EntityFrameworkCore.Design
> dotnet add package Microsoft.EntityFrameworkCore.Design

On the data layer
> cd src/SampleCoreBank.Infrastructures.Data

#### dotnet-ef install
> dotnet tool install --global dotnet-ef

#### dotnet-ef update
> dotnet tool update --global dotnet-ef

#### Add new Migration
> dotnet ef --startup-project ../SampleCoreBank.Presentations.WebAPI migrations add InitialMigrationCoreBankDbContext -c CoreBankDbContext -o CoreBank/Migrations
