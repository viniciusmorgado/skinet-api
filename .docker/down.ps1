# Delete the development stack and clean volumes (lost persistent data)
docker compose -f docker-compose-dev.yml -p "skinet-stack" down --volumes;

# Delete all unused images from the system. (purge more than just skinet images)
docker image prune -a -f;
