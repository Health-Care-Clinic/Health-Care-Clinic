
FROM node:14.17.1-alpine as build 
WORKDIR /app
COPY PatientApplication/PatientApp/. .
RUN npm install --force
RUN npm run build --prod

FROM nginx:alpine
#EXPOSE 80
COPY --from=build /app/dist/PatientApp /usr/share/nginx/html
#COPY ./PatientApplication/PatientApp/nginx.conf /etc/nginx/nginx.conf

#ENTRYPOINT ["nginx","-g","daemon off;"]