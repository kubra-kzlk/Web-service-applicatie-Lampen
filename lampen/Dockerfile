# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory
WORKDIR /app

# Copy the .csproj file and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the app files
COPY . ./

# Publish the app
RUN dotnet publish -c Release -o out

# Generate runtime image with the published app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Set the environment variable to tell ASP.NET Core to listen on the correct port
ENV ASPNETCORE_URLS=http://+:5000

# Expose the application on port 5000 (or your preferred port)
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "LampifyAPI.dll"]
