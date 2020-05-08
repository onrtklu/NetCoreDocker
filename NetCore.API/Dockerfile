
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NetCore.API/NetCore.API.csproj", "NetCore.API/"]
RUN dotnet restore "NetCore.API/NetCore.API.csproj"
COPY . .
WORKDIR "/src/NetCore.API"
RUN dotnet build "NetCore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCore.API.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore.API.dll"]