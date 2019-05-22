-- Table: public.post

-- DROP TABLE public.post;

CREATE TABLE public.post
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    username character varying(100) COLLATE pg_catalog."default" NOT NULL,
    message text COLLATE pg_catalog."default" NOT NULL,
    image_filename character varying(100) COLLATE pg_catalog."default" NOT NULL,
    so_goods integer NOT NULL DEFAULT 0,
    thats_decents integer NOT NULL DEFAULT 0,
    not_so_goods integer NOT NULL DEFAULT 0,
    CONSTRAINT post_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.post
    OWNER to "Jimstagram";