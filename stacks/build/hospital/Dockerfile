
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
 

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Hospital API/Hospital API.csproj" && \
    dotnet build "Hospital API/Hospital API.csproj" -c Release
 

FROM build AS publish
RUN dotnet publish "Hospital API/Hospital API.csproj" -c Release -o /app/publish 


FROM base AS final
ENV ASPNETCORE_URLS=http://*:$PORT
COPY --from=publish /app .
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Hospital API.dll"]
