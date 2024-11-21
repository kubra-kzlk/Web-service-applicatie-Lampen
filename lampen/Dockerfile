# Use the official .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["lampen/lampen.csproj", "lampen/"]
RUN dotnet restore "lampen/lampen.csproj"

# Copy the rest of the application
COPY . .

# Set the working directory to where the project is located
WORKDIR "/src/lampen"
RUN dotnet build "lampen.csproj" -c Release -o /app/build

# Publish the app to the /app/publish directory
FROM build AS publish
RUN dotnet publish "lampen.csproj" -c Release -o /app/publish

# Use the official .NET runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=publish /app/publish .

# Expose the port the app runs on
EXPOSE 8080

# Set the entry point for the container
ENTRYPOINT ["dotnet", "lampen.dll"]
