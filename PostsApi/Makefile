all: build docker

build:
	dotnet build

run: build
	dotnet run --project Jimstagram.PostsApi

docker:
	docker build -t jimstagram-posts:latest Jimstagram.PostsApi
