
FROM node:14.17.1-alpine as build 
WORKDIR /app
COPY . .
RUN npm install --force
RUN npm run build --prod

FROM nginx:alpine
#EXPOSE 4200
COPY --from=build /app/dist/ManagerApp /usr/share/nginx/html
#COPY ./ManagerApplication/ManagerApp/nginx.conf /etc/nginx/nginx.conf

#ENTRYPOINT ["nginx","-g","daemon off;"]