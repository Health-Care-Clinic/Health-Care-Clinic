
FROM node:15.14.0-alpine as build 
WORKDIR /app
COPY ManagerApplication/ManagerApp/. .
RUN npm install --force
RUN npm run build

FROM nginx:alpine
EXPOSE 4200
COPY --from=build /app/dist/ManagerApp /usr/share/nginx/html