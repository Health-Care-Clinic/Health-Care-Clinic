FROM nginx
#COPY ["./conf/default.conf","/etc/nginx/conf.d/default.conf"]
#COPY ./conf/nginx.conf /etc/nginx/nginx.conf
#COPY ./conf/default.conf /etc/nginx/default.conf

#RUN useradd -u 5677 proxy-user
#USER proxy-user

RUN useradd -u 5000 app \
 && mkdir -p /var/run/nginx /var/tmp/nginx \
 && chown -R app:app /usr/share/nginx /var/run/nginx /var/tmp/nginx
COPY ./conf/nginx.conf /etc/nginx/nginx.conf
COPY ./conf/default.conf /etc/nginx/default.conf
USER app:app