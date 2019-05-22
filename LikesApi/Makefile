all: build

PG_SETTINGS=export PGUSER=Jimstagram && export PGDATABASE=Jimstagram && export PGPASSWORD=jimbooktwopointoh && export PGPORT=5432 && 

build:
	npm install

run: build
	$(PG_SETTINGS) node_modules/.bin/babel-node app.js

docker:
	docker build -t jimstagram-likes:latest .
