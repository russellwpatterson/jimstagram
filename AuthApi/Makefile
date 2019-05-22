PYTHON=python3.6

ENV_DIR=.env_$(PYTHON)

IN_ENV=. $(ENV_DIR)/bin/activate &&

all: build

env: $(ENV_DIR)

$(ENV_DIR):
	$(PYTHON) -m venv $(ENV_DIR)
	$(IN_ENV) pip install wheel setuptools

build_reqs: env
	$(IN_ENV) pip install Flask flask-jwt-extended

build: build_reqs

run: build
	$(IN_ENV) FLASK_APP=app.py flask run --host=localhost --port=5001

docker:
	docker build -t jimstagram-auth:latest .
