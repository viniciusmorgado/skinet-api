FROM mcr.microsoft.com/dotnet/sdk:8.0 AS BUILD
WORKDIR /src
COPY "./Api.Skinet.csproj" .
RUN dotnet restore "Api.Skinet.csproj"
COPY . .
RUN dotnet publish "Api.Skinet.csproj" -c Release --self-contained true -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS FINAL
WORKDIR /app
COPY --from=BUILD /publish .

# Remove temporary port expouse after development
EXPOSE 8080

ENTRYPOINT [ "dotnet", "Api.Skinet.dll" ]
