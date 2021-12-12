FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
 

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Pharmacy API/Pharmacy API/Pharmacy API.csproj" && \
    dotnet build "Pharmacy API/Pharmacy API/Pharmacy API.csproj" -c Release
 

FROM build AS publish
RUN dotnet publish "Pharmacy API/Pharmacy API/Pharmacy API.csproj" -c Release -o /app/publish 


FROM base AS final
ENV ASPNETCORE_URLS=http://*:$PORT
COPY --from=publish /app .
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Pharmacy API.dll"]