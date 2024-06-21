# Build the Api.Dockerfile to generate a local image.
docker build -f .\.docker\Api.Dockerfile . -t vinimorgado/skinet-api:latest; 

# Push the changes to the skinet repo (replace with you own)
docker push vinimorgado/skinet-api:latest;
