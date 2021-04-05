cd ./InfoTrace.Back-End
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --build
cd ../InfoTrace.Front-End
docker-compose -f docker-compose.yml up -d --build