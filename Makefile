all: deploy

run_postgres:
	- @docker stop postgres
	- @docker rm postgres
	docker run -d -p "5432:5432" -v "${PWD}/pg-data:/var/lib/postgresql/data" --name postgres -e "POSTGRES_USER=Jimstagram" -e "POSTGRES_PASSWORD=jimbooktwopointoh" -e "POSTGRES_DB=Jimstagram" postgres:11.3

auth:
	cd AuthApi && $(MAKE) docker

likes:
	cd LikesApi && $(MAKE) docker

posts:
	cd PostsApi && $(MAKE) docker

web:
	cd Web && $(MAKE) docker

clean:
	@docker system prune -f

build: auth likes posts web clean

stop_run:
	- docker-compose down

run: stop_run build
	docker-compose up -d
