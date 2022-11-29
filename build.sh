#!/bin/bash
#First Login to the registry i.e docker login ghcr.io -u USERNAME --password-stdin if running locally

echo Build image: $BUILD_IMAGE
echo App Image Uri: $APP_IMAGE_URI
docker pull $BUILD_IMAGE
RESULT=$?
if [ $RESULT -eq 0 ]; then
  echo build image allready exists
else
  docker pull mcr.microsoft.com/dotnet/sdk:7.0
  docker tag mcr.microsoft.com/dotnet/sdk:7.0 $BUILD_IMAGE
  docker push $BUILD_IMAGE
fi

docker build -t $BUILD_IMAGE --build-arg builder_image=$BUILD_IMAGE --target build -f Dockerfile .
docker push $BUILD_IMAGE
docker build -t $APP_IMAGE_URI --build-arg builder_image=$BUILD_IMAGE --target final -f Dockerfile .
docker push $APP_IMAGE_URI