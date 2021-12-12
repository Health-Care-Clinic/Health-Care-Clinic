
FROM node:14.17.1-alpine as build 
WORKDIR /app
COPY PatientApplication/PatientApp/. .
RUN npm install --force
RUN npm run build --prod

FROM nginx:alpine
EXPOSE 4200
COPY --from=build /app/dist/PatientApp /usr/share/nginx/html