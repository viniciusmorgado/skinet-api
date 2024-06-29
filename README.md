# Skinet - E-commerce

Backend of ecommerce platform for selling ski gear using C# ASP.NET

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

Run the docker compose for development, this will setup the services needs for development-only (RabbitMQ, Postgres and Redis)

```
cd skinet-api/.docker
```
```
docker compose -f docker-compose-dev.yml -p "skinet-stack" up -d;
```
Obs: Some linux distros packages maybe use docker-compose instead of "docker compose".

Alternatively you can just run the up.ps1 script on Windows, or rename it to up.sh and run on Unix systems:
```
.\up.ps1
```

## Project Files

- .docker - Contains all relevant files and scripts to run docker container environment.
    * Api.Dockerfile - Responsible to containerize the application.
    * docker-compose-dev.yml - Only setup the services strictly need for development, in this case: RabbitMQ, Redis and Postgres, tools for telemetry and the application itself are not run for this composer, you should run the application via vscode or terminal for debugging.
    * docker-compose.yml - Setup all the services necessary for run the backend on production including the application itself and observability tools.

## Observability

The project has two redundant observability tools that can be deploy in separate servers to generate, collect, management, and export telemetry data like traces, metrics, and logs.

**Logging Server** - Basic logging system and visualization with [Serilog](https://serilog.net/) and [SEQ](https://datalust.co/seq)
- **Data Flow**: Serilog (ingestion/generation) -> Feed -> SEQ (Visualization)

<IMAGE>

**Telemetry Server** - Advanced telemetry information and visualization with [Grafana](https://grafana.com/), [Prometheus](https://prometheus.io/) and [OpenTelemetry](https://opentelemetry.io/).
- **Data Flow**: OTL/Prometheus (ingestion/generation) -> Feed -> Grafana/Prometheus (Visualization)

Obs: Grafana are used in combinaton with Prometheus to improve data collection, but we also have dashboards with data coming directly from prometheus ingestion engine itself completly independent from OTL.

<IMAGE>

### Architecture

Under construction

### Important Design Patterns Considerations

Under construction

### Testing

Under construction

### Deployment Pipelines

Under construction

### Infrastructure as Code

Under construction

### Production Setup

Under construction