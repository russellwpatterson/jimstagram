all: build docker

build:
	- @rm -rf dist
	@npm install
	@npm run build

run: build
	@npm run serve

docker: build
	@docker build -t jimstagram-web:latest .
