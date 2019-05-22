FROM node:10.15-alpine

ENV PGHOST postgres
ENV PGUSER Jimstagram 
ENV PGDATABASE Jimstagram
ENV PGPASSWORD jimbooktwopointoh
ENV PGPORT 5432

WORKDIR /app

COPY app.js .
COPY .babelrc .
COPY package.json .
COPY package-lock.json .

RUN npm install

ENTRYPOINT [ "node_modules/.bin/babel-node", "app.js" ]