export BUILD_IMAGE="ghcr.io/contensis/razor-page-leif-example/master/razor-example:buildimage"
export APP_IMAGE="ghcr.io/contensis/razor-page-leif-example/master/razor-example"
export APP_IMAGE_URI=$APP_IMAGE:build-local
/bin/bash build.sh
