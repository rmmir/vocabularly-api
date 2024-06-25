# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

WORKDIR /src

# Restore
COPY ["src/Vocabularly/Vocabularly.csproj", "Vocabularly/"]
RUN dotnet restore "Vocabularly/Vocabularly.csproj"

# Build
COPY ["src/Vocabularly", "Vocabularly/"]
WORKDIR /src/Vocabularly
RUN dotnet build "Vocabularly.csproj" -c Release -o /app/build

# Publish
FROM build as publish
RUN dotnet publish "Vocabularly.csproj" -c Release -o /app/publish

# Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vocabularly.dll"]