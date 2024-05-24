# https://hub.docker.com/_/microsoft-dotnet-aspnet/

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . /app
RUN dotnet restore;
RUN dotnet publish --configuration Release --output output --runtime linux-x64;

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/output .
ENTRYPOINT ["dotnet", "Api.Skinet.dll"]

# docker pull mcr.microsoft.com/dotnet/sdk:8.0-alpine3.19 REPROVED - 1202 packages
# docker pull mcr.microsoft.com/dotnet/aspnet:8.0-alpine3.19 APPROVED - 329 packages

# docker pull mcr.microsoft.com/dotnet/sdk:8.0-cbl-mariner2.0 APPROVED - 1617
# docker pull mcr.microsoft.com/dotnet/aspnet:8.0-cbl-mariner2.0 - APPROVED - 389 packages
