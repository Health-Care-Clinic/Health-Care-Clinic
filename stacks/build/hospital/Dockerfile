
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
 
# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
#RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
#USER appuser
RUN useradd -u 5678 app
USER app

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
