#!/usr/bin/bash

docker build -f ./src/Api.Skinet/Dockerfile -t vinimorgado/skinet-api .;
docker push vinimorgado/skinet-api:latest;
docker compose down -v;
docker compose up -d;
