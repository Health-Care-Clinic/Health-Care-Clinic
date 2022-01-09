
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "HealthCareClinic/Hospital API/Hospital API.csproj" && \
    dotnet build "HealthCareClinic/Hospital API/Hospital API.csproj" -c Release
RUN dotnet new tool-manifest --force --name manifest 
RUN dotnet tool install --local dotnet-ef --version 5.0.11


RUN dotnet dotnet-ef migrations add TestingMigration --startup-project "HealthCareClinic/Hospital/Hospital.csproj"
RUN dotnet dotnet-ef database update --startup-project "HealthCareClinic/Hospital/Hospital.csproj"
RUN dotnet test "HealthCareClinic/HospitalIntegrationTests/HospitalIntegrationTests.csproj"

FROM base AS final
ENV ASPNETCORE_URLS=http://*:$PORT
COPY --from=publish /app .
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Hospital API.dll"]
