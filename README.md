# sample-core-bank

.NET 9

O Projeto está configurado para executar no docker já com banco no compose.
Caso prefira executar sem basta alterar a conectionString no ".\sample-core-bank\src\SampleCoreBank.Presentations.WebAPI\appsettings.Development.json"

#### Docker
> docker-compose up --build

#### POSTMAN COLLECTION
> docs/Postman

#### SWAGGER
> http://localhost:5000/swagger/index.html


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
