FROM python:3.6-slim
WORKDIR /app

RUN pip install wheel setuptools
RUN apt-get update && \
    apt-get -y install gcc && \
    pip install uwsgi && \
    apt-get -y remove gcc && \
    apt-get -y autoremove && \
    rm -rf /var/lib/apt/lists/*

RUN pip install Flask flask-jwt-extended

COPY ./app.py .

ENTRYPOINT ["uwsgi", "--http", ":80", "-s", "/tmp/jimstagram-auth.sock", "--manage-script-name", "--mount", "/=app:app"]
