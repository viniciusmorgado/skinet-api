# Skinet - E-commerce

Backend of an e-commerce platform for selling ski gear using C# ASP.NET

## Requirements

Development:

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- [Docker](https://www.docker.com/) ([or Podman](https://podman.io/))

Run the entire application:

- [Skinet Platform](https://github.com/viniciusmorgado/skinet-platform) - Application frontend written in Angular.

## Getting started (for development)

Clone repository:

```
git clone https://github.com/viniciusmorgado/skinet-api.git
```

Run the Docker Compose for development. This will set up the necessary services for development only, including RabbitMQ, Postgres, and Redis.

```
cd skinet-api/.docker
```
```
docker compose -f docker-compose-dev.yml -p "skinet-stack" up -d;
```
Note: Some Linux distributions may use docker-compose instead of docker compose.

Alternatively, you can run the up.ps1 script on Windows, or rename it to up.sh and run it on Unix systems."

```
.\up.ps1
```

## Project Files

- .docker - Contains all relevant files and scripts to run the Docker container environment.
    * Api.Dockerfile - Responsible for containerizing the application.
    * docker-compose-dev.yml - Sets up only the services strictly needed for development, including RabbitMQ, Redis, and Postgres. Tools for telemetry and the application itself are not run with this compose file; you should run the application via VSCode or terminal for debugging.
    * docker-compose.yml - Sets up all the services necessary to run the backend in production, including the application itself and observability tools.

## Observability

This project includes two redundant observability tools that can be deployed on separate servers. These tools generate, collect, manage, and export telemetry data such as traces, metrics, and logs.

**Logging Server** - Basic logging system and visualization with [Serilog](https://serilog.net/) and [SEQ](https://datalust.co/seq)
- **Data Flow**: Serilog (ingestion/generation) -> Feed -> SEQ (Visualization)

![A screenshot of the Seq logging tool displaying various log events for an application named "Api.Skinet". The logs include timestamps, log levels, and detailed messages. The interface shows the hosting status, connection details to a PostgreSQL database, and application environment settings. The log messages indicate that the application has started hosting on http://127.0.0.1:10401, connected to a PostgreSQL server, and executed several database commands. The sidebar contains navigation options for events, dashboards, alerts, data, settings, and support, along with a search function for active tool windows.](https://github.com/viniciusmorgado/skinet-api/blob/develop/src/Api.Skinet/wwwroot/images/github/seq.png)

**Telemetry Server** - Advanced telemetry information and visualization with [Grafana](https://grafana.com/), [Prometheus](https://prometheus.io/) and [OpenTelemetry](https://opentelemetry.io/).
- **Data Flow**: OTL/Prometheus (ingestion/generation) -> Feed -> Grafana/Prometheus (Visualization)

Note: Grafana is used in combination with Prometheus to enhance data collection. However, we also have dashboards with data coming directly from the Prometheus ingestion engine, completely independent of OTL.

<IMAGE>

### Architecture

Work in Progress

### Important Design Patterns Considerations

Work in Progress

### Testing

Work in Progress

### Deployment Pipelines

Work in Progress

### Infrastructure as Code

Work in Progress

### Production Setup

Work in Progress
