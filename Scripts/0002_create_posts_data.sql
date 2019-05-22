--
-- PostgreSQL database dump
--

-- Dumped from database version 11.3 (Debian 11.3-1.pgdg90+1)
-- Dumped by pg_dump version 11.3 (Ubuntu 11.3-1.pgdg18.04+1)

-- Started on 2019-05-29 16:47:13 EDT

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 196 (class 1259 OID 16385)
-- Name: post; Type: TABLE; Schema: public; Owner: Jimstagram
--

CREATE TABLE public.post (
    id bigint NOT NULL,
    username character varying(100) NOT NULL,
    message text NOT NULL,
    image_filename character varying(100) NOT NULL,
    so_goods integer DEFAULT 0 NOT NULL,
    thats_decents integer DEFAULT 0 NOT NULL,
    not_so_goods integer DEFAULT 0 NOT NULL
);


ALTER TABLE public.post OWNER TO "Jimstagram";

--
-- TOC entry 197 (class 1259 OID 16393)
-- Name: post_id_seq; Type: SEQUENCE; Schema: public; Owner: Jimstagram
--

ALTER TABLE public.post ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.post_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 2866 (class 0 OID 16385)
-- Dependencies: 196
-- Data for Name: post; Type: TABLE DATA; Schema: public; Owner: Jimstagram
--

COPY public.post (id, username, message, image_filename, so_goods, thats_decents, not_so_goods) FROM stdin;
9	jim	MICROSERVICES!!!!	3ef14585-5145-4f69-b6e2-443f7e95b5ba.png	8	4	3
16	jim	Kubernetes.	ad3ff2ed-2f20-426a-9e55-f4909359955e.png	30	0	0
6	hannah	This is an adorable kitten. Thank you for looking at my post.	22d519f5-47c5-4648-8250-fdbe15988c01.jpg	18	19	20
4	jim	I fondly remember my time at the College of William and Mary. I went there. Second oldest university in the country.	f36d3ab8-20dc-490c-b32c-d02707121dc4.jpg	1	1	9
12	jim	#YoungProfessionalsToday	41aef3c9-be3b-40b5-a1d6-4e5ca2c19474.jpg	8	0	0
14	jim	So, so good.	edad08e1-0457-4ed7-a5a8-790c400223f8.png	0	1	0
13	jim	Kids today.	d473f658-8c90-4f34-9bb8-278f4c631234.jpg	7	5	1
3	jim	Python is the best programming language, and it should always be used with a Subversion backend.	55bcc52c-c190-4e4e-b08a-a38afa1340c6.png	50	2	1
5	jim	Ohio is - without a doubt - the best state. Way better than Colorado and Virginia.	81556c64-7bde-4742-93dc-d61cca30ae78.jpg	7	29	7
\.


--
-- TOC entry 2873 (class 0 OID 0)
-- Dependencies: 197
-- Name: post_id_seq; Type: SEQUENCE SET; Schema: public; Owner: Jimstagram
--

SELECT pg_catalog.setval('public.post_id_seq', 16, true);


--
-- TOC entry 2744 (class 2606 OID 16392)
-- Name: post post_pkey; Type: CONSTRAINT; Schema: public; Owner: Jimstagram
--

ALTER TABLE ONLY public.post
    ADD CONSTRAINT post_pkey PRIMARY KEY (id);


-- Completed on 2019-05-29 16:47:13 EDT

--
-- PostgreSQL database dump complete
--

