FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -
RUN apt-get install -y nodejs

# Copy csproj and restore as distinct layers
COPY "./AuthServer.sln" "./AuthServer.sln"
COPY "./src/AuthServer/AuthServer.csproj" "./src/AuthServer/AuthServer.csproj"
COPY "./src/AuthServer.Infrastructure/AuthServer.Infrastructure.csproj" "./src/AuthServer.Infrastructure/AuthServer.Infrastructure.csproj"

RUN dotnet restore "./AuthServer.sln"

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

# Run the app on container startup
#ENTRYPOINT [ "dotnet", "AuthServer.dll" ]
# Use the following instead for Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet AuthServer.dll