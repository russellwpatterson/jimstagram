FROM nginx:1.14.0-alpine
COPY ./nginx/conf.d/* /etc/nginx/conf.d/
COPY ./nginx/proxy.d/* /etc/nginx/proxy.d/
COPY dist /usr/share/nginx/html
