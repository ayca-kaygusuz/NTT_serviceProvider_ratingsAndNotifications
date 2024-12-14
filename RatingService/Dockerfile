FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["RatingService/RatingService.csproj", "RatingService/"]
RUN dotnet restore "RatingService/RatingService.csproj"

COPY . .
WORKDIR "/src/RatingService"
RUN dotnet build "RatingService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RatingService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RatingService.dll"]