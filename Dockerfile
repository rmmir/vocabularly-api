# Use the SDK image for building and running the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the csproj and restore as distinct layers
COPY ["src/Vocabularly/Vocabularly.csproj", "./Vocabularly/"]
RUN dotnet restore "Vocabularly/Vocabularly.csproj"

# Copy everything else and build
COPY ["src/Vocabularly", "./Vocabularly/"]
WORKDIR /app/Vocabularly

# Perform build so that the bin and obj directories are created
RUN dotnet build "Vocabularly.csproj" -c Release -o /app/build

# Use the build image to run the application
FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app/Vocabularly

COPY --from=build /root/.nuget/packages /root/.nuget/packages
COPY --from=build /app/Vocabularly /app/Vocabularly

ENTRYPOINT ["dotnet", "watch", "run", "--urls=http://0.0.0.0:5001"]
