FROM nginx
#COPY ["./conf/default.conf","/etc/nginx/conf.d/default.conf"]

RUN useradd -u 5001 app \
 && mkdir -p /var/run/nginx /var/tmp/nginx \
 && chown -R app:app /usr/share/nginx /var/run/nginx /var/tmp/nginx
COPY ./conf/nginx.conf /etc/nginx/nginx.conf
COPY ./conf/default.conf /etc/nginx/default.conf
USER app:app