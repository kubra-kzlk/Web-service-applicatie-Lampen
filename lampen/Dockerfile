# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["lampen/lampen.csproj", "lampen/"]
RUN dotnet restore "lampen/lampen.csproj"
COPY . .
WORKDIR "/src/lampen"
RUN dotnet build "lampen.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lampen.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lampen.dll"]
