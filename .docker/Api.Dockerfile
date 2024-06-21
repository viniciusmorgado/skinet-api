# https://hub.docker.com/_/microsoft-dotnet-aspnet/

FROM mcr.microsoft.com/dotnet/sdk:8.0-cbl-mariner2.0 AS build
WORKDIR /app
COPY . /app
RUN dotnet restore;
RUN dotnet publish --configuration Release --output output --runtime linux-x64;
RUN rm /app/output/Api.Skinet

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine3.19 AS runtime
RUN apk add icu-dev nano;
WORKDIR /app
COPY --from=build /app/output .

EXPOSE 10401
ENTRYPOINT ["dotnet", "Api.Skinet.dll"]
CMD ["--port", "10401"]

# Debug: Uncommend this line to debug the container, will run even with fatal errors and exceptions.
# CMD ["tail", "-f", "/dev/null"]
