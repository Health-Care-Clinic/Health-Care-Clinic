
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
 

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "HealthCareClinic/Integration API/Integration API.csproj" && \
    dotnet build "HealthCareClinic/Integration API/Integration API.csproj" -c Release
 

FROM build AS publish
RUN dotnet publish "HealthCareClinic/Integration API/Integration API.csproj" -c Release -o /app/publish 


FROM base AS final
ENV ASPNETCORE_URLS=http://*:$PORT
COPY --from=publish /app .
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Integration API.dll"]