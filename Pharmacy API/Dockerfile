FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
 

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
ENV API="Pharmacy API.sln"
ENV CSPROJ="Pharmacy API"
WORKDIR /src
COPY ${API} ./
COPY Pharmacy/*.csproj ./Pharmacy/
COPY ${CSPROJ}/*.csproj ./PharmacyAPI/
COPY PharmacyTests/*.csproj ./PharmacyApiTests/
RUN dotnet restore 

COPY . ./ 

WORKDIR /src/Pharmacy
RUN dotnet build -c Release -o /app 
WORKDIR /src/PharmacyAPI
RUN dotnet build -c Release -o /app

 

FROM build AS publish
RUN dotnet publish -c Release -o /app


#FROM base AS final
#ENV ASPNETCORE_URLS=http://*:$PORT
#COPY --from=publish /app .
#WORKDIR /app/publish
#ENTRYPOINT ["dotnet", "Pharmacy API.dll"]

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=build /app .
ENTRYPOINT [ "dotnet","Pharmacy API.dll" ]