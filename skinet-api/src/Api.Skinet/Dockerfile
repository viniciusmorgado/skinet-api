FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . /app
RUN dotnet restore;
RUN dotnet publish --configuration Release --output output;

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/output .
ENTRYPOINT ["dotnet", "Api.Skinet.dll"]
