
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

RUN dotnet new tool-manifest --force && \
    dotnet tool install --global dotnet-ef --version 5.0.11

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Hospital API/Hospital API.csproj" && \
    dotnet build "Hospital API/Hospital API.csproj" -c Release


RUN dotnet dotnet-ef migrations add TestingMigration --project "Hospital API/Hospital API.csproj" --context HospitalDbContext && \
    dotnet dotnet-ef database update --project "Hospital API/Hospital API.csproj" && \
    dotnet test "HospitalIntegrationTests/HospitalIntegrationTests.csproj"

FROM base AS final
ENV ASPNETCORE_URLS=http://*:$PORT
COPY --from=publish /app .
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Hospital API.dll"]
