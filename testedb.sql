--
-- PostgreSQL database dump
--

-- Dumped from database version 12.4
-- Dumped by pg_dump version 12.4

-- Started on 2020-11-19 04:13:46

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

SET default_table_access_method = heap;

--
-- TOC entry 203 (class 1259 OID 49391)
-- Name: books; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.books (
    "Id" integer NOT NULL,
    "Name" character varying(50),
    "Pages" integer,
    "AuthorName" character varying(50),
    "IsRented" boolean
);


ALTER TABLE public.books OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 49411)
-- Name: rentals_rentals_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.rentals_rentals_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.rentals_rentals_id_seq OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 49396)
-- Name: rentals; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rentals (
    "Id" integer DEFAULT nextval('public.rentals_rentals_id_seq'::regclass) NOT NULL,
    "BookId" integer,
    "InitialDate" date,
    "ExpiryDate" date,
    "UserId" integer
);


ALTER TABLE public.rentals OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 49386)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    "Id" integer NOT NULL,
    "Name" character varying(50),
    "Username" character varying(50),
    "Password" character varying(300)
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 2831 (class 0 OID 49391)
-- Dependencies: 203
-- Data for Name: books; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.books ("Id", "Name", "Pages", "AuthorName", "IsRented") FROM stdin;
1	O Conto da Aia	200	Teste	t
2	O colecionador	158	Teste	\N
\.


--
-- TOC entry 2832 (class 0 OID 49396)
-- Dependencies: 204
-- Data for Name: rentals; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.rentals ("Id", "BookId", "InitialDate", "ExpiryDate", "UserId") FROM stdin;
17	1	2020-11-19	2020-12-04	1
18	2	2020-11-19	2020-12-04	1
\.


--
-- TOC entry 2830 (class 0 OID 49386)
-- Dependencies: 202
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users ("Id", "Name", "Username", "Password") FROM stdin;
1	Daniela	daniela	teste
2	Teste	teste	teste
\.


--
-- TOC entry 2839 (class 0 OID 0)
-- Dependencies: 205
-- Name: rentals_rentals_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.rentals_rentals_id_seq', 18, true);


--
-- TOC entry 2699 (class 2606 OID 49395)
-- Name: books books_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT books_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2701 (class 2606 OID 49400)
-- Name: rentals rentals_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rentals
    ADD CONSTRAINT rentals_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2697 (class 2606 OID 49390)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2703 (class 2606 OID 49406)
-- Name: rentals rentals_book_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rentals
    ADD CONSTRAINT rentals_book_id_fkey FOREIGN KEY ("BookId") REFERENCES public.books("Id");


--
-- TOC entry 2702 (class 2606 OID 49401)
-- Name: rentals rentals_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rentals
    ADD CONSTRAINT rentals_user_id_fkey FOREIGN KEY ("UserId") REFERENCES public.users("Id");


-- Completed on 2020-11-19 04:13:46

--
-- PostgreSQL database dump complete
--

