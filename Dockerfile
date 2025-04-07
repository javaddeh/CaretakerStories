# Stage 1: Build the app using .NET 9 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY . ./
RUN dotnet restore

# Build and publish the app
RUN dotnet publish -c Release -o /app/published --no-restore

# Stage 2: Run the app using .NET 9 runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/published ./

# Set the entry point (replace "CaretakerStories.dll" with your app’s DLL name)
ENTRYPOINT ["dotnet", "CaretakerStories.dll"]