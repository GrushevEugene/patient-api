CREATE DATABASE patient;

\c patient

CREATE TABLE patient (
    id UUID PRIMARY KEY,
    gender VARCHAR(255),
    birthDate TIMESTAMP,
    active BOOLEAN
);

CREATE TABLE name (
    id UUID PRIMARY KEY,
    use VARCHAR(255),
    family VARCHAR(255),
    given TEXT[]
);

ALTER TABLE patient
ADD COLUMN name_id UUID,
ADD FOREIGN KEY (name_id) REFERENCES name(id);
