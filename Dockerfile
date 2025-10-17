# ---------- build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj of all projects
COPY ["src/SampleCoreBank.Shared/SampleCoreBank.Shared.csproj", "SampleCoreBank.Shared/"]
COPY ["src/SampleCoreBank.Core.Domain/SampleCoreBank.Core.Domain.csproj", "SampleCoreBank.Core.Domain/"]
COPY ["src/SampleCoreBank.Infrastructures.Data/SampleCoreBank.Infrastructures.Data.csproj", "SampleCoreBank.Infrastructures.Data/"]
COPY ["src/SampleCoreBank.Core.Application/SampleCoreBank.Core.Application.csproj", "SampleCoreBank.Core.Application/"]
COPY ["src/SampleCoreBank.Middleware/SampleCoreBank.Middleware.csproj", "SampleCoreBank.Middleware/"]
COPY ["src/SampleCoreBank.Presentations.WebAPI/SampleCoreBank.Presentations.WebAPI.csproj", "SampleCoreBank.Presentations.WebAPI/"]

# copy entire project folders for dependencies
COPY src/SampleCoreBank.Shared/ SampleCoreBank.Shared/
COPY src/SampleCoreBank.Core.Domain/ SampleCoreBank.Core.Domain/
COPY src/SampleCoreBank.Infrastructures.Data/ SampleCoreBank.Infrastructures.Data/
COPY src/SampleCoreBank.Core.Application/ SampleCoreBank.Core.Application/
COPY src/SampleCoreBank.Middleware/ SampleCoreBank.Middleware/
COPY src/SampleCoreBank.Presentations.WebAPI/ SampleCoreBank.Presentations.WebAPI/

WORKDIR /src/SampleCoreBank.Presentations.WebAPI
RUN dotnet restore "SampleCoreBank.Presentations.WebAPI.csproj"

# copy everything else and build
COPY src/SampleCoreBank.Presentations.WebAPI/. ./ 
RUN dotnet publish "SampleCoreBank.Presentations.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ---------- runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# copy published output
COPY --from=build /app/publish ./

# environment
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "SampleCoreBank.Presentations.WebAPI.dll"]