CREATE TABLE categoria (
  id serial not null,
  descricao varchar (30) not null,
  idcategoriapai integer,
  PRIMARY KEY (id)
);

ALTER TABLE categoria
ADD CONSTRAINT categoria_001_fk FOREIGN KEY (id)
REFERENCES categoria (id)
ON UPDATE CASCADE
ON DELETE CASCADE;

CREATE TABLE transacaotipo (
  id integer not null,
  descricao varchar (30),
  PRIMARY KEY (id)
);

INSERT INTO transacaotipo (id, descricao) VALUES(1, 'ENTRADA');
INSERT INTO transacaotipo (id, descricao) VALUES(2, 'SAÍDA');

CREATE TABLE transacao (
  id serial not null,
  idcategoria integer,
  idtransacaotipo integer not null,
  datatransacao timestamp without time zone not null,
  observacoes varchar (300),
  PRIMARY KEY (id)
);

ALTER TABLE transacao
ADD CONSTRAINT transacao_001_fk FOREIGN KEY (idcategoria)
REFERENCES categoria (id)
ON UPDATE CASCADE
ON DELETE RESTRICT,
ADD CONSTRAINT transacao_002_fk FOREIGN KEY (idtransacaotipo)
REFERENCES transacaotipo (id)
ON UPDATE CASCADE
ON DELETE RESTRICT;
