FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:$PORT

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["Pharmacy API/Pharmacy API/Pharmacy API.csproj", "Pharmacy API/Pharmacy API/"]
RUN dotnet restore "Pharmacy API/Pharmacy API/Pharmacy API.csproj"
COPY . .
WORKDIR "/src/Pharmacy API/Pharmacy API"
RUN dotnet build "Pharmacy API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pharmacy API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pharmacy API.dll"]