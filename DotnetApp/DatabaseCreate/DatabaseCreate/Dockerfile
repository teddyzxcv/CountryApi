FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["DatabaseCreate/DatabaseCreate.csproj", "DatabaseCreate/"]
RUN dotnet restore "DatabaseCreate/DatabaseCreate.csproj"
COPY . .
WORKDIR "/src/DatabaseCreate"
RUN dotnet build "DatabaseCreate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DatabaseCreate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DatabaseCreate.dll"]
