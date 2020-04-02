CREATE TABLE IF NOT EXISTS categoria
(
   id              serial        NOT NULL,
   descricao       varchar(30)   NOT NULL,
   idcategoriapai  integer
);

ALTER TABLE categoria
   ADD CONSTRAINT categoria_pkey
   PRIMARY KEY (id);

CREATE TABLE IF NOT EXISTS conta
(
   id             serial                        NOT NULL,
   idcontatipo    integer                       NOT NULL,
   descricao      varchar(30)                   NOT NULL,
   datacriacao    timestamp without time zone   NOT NULL,
   dataalteracao  timestamp without time zone   NOT NULL
);

ALTER TABLE conta
   ADD CONSTRAINT conta_pkey
   PRIMARY KEY (id);

CREATE TABLE IF NOT EXISTS contatipo
(
   id         integer       NOT NULL,
   descricao  varchar(30)   NOT NULL
);

ALTER TABLE contatipo
   ADD CONSTRAINT contatipo_pkey
   PRIMARY KEY (id);

CREATE TABLE IF NOT EXISTS meiopagamento
(
   id                      serial                        NOT NULL,
   descricao               varchar(30),
   idmeiopagamentotipo     integer                       NOT NULL,
   diaefetivacaopagamento  integer,
   datacriacao             timestamp without time zone   NOT NULL,
   dataalteracao           timestamp without time zone   NOT NULL,
   idcontapadrao           integer
);

ALTER TABLE meiopagamento
   ADD CONSTRAINT meiopagamento_pkey
   PRIMARY KEY (id);

CREATE TABLE IF NOT EXISTS meiopagamentofechamento
(
   id               serial                        NOT NULL,
   idmeiopagamento  integer                       NOT NULL,
   mesreferencia    integer                       NOT NULL,
   anoreferencia    integer                       NOT NULL,
   datafechamento   timestamp without time zone,
   datacriacao      timestamp without time zone   NOT NULL,
   dataalteracao    timestamp without time zone   NOT NULL
);

ALTER TABLE meiopagamentofechamento
   ADD CONSTRAINT meiopagamentofechamento_pkey
   PRIMARY KEY (id);

CREATE TABLE IF NOT EXISTS meiopagamentotipo
(
   id                             integer       NOT NULL,
   descricao                      varchar(30)   NOT NULL,
   efetivacaopagamentoimediata    boolean       NOT NULL,
   efetivacaopagamentoprogramada  boolean       NOT NULL
);

ALTER TABLE meiopagamentotipo
   ADD CONSTRAINT meiopagamentotipo_pkey
   PRIMARY KEY (id);

CREATE TABLE IF NOT EXISTS transacao
(
   id               serial                        NOT NULL,
   idcategoria      integer,
   idtransacaotipo  integer                       NOT NULL,
   idmeiopagamento  integer                       NOT NULL,
   valortotal       numeric(10,2)                 NOT NULL,
   datatransacao    timestamp without time zone   NOT NULL,
   observacoes      varchar(300),
   datacriacao      timestamp without time zone   NOT NULL,
   dataalteracao    timestamp without time zone   NOT NULL
);

ALTER TABLE transacao
   ADD CONSTRAINT transacao_pkey
   PRIMARY KEY (id);

CREATE TABLE IF NOT EXISTS transacaodetalhe
(
   id               serial                        NOT NULL,
   idtransacao      integer                       NOT NULL,
   idmeiopagamento  integer                       NOT NULL,
   dataefetivacao   timestamp without time zone   NOT NULL,
   valor            numeric(10,2)                 NOT NULL,
   datacriacao      timestamp without time zone   NOT NULL,
   dataalteracao    timestamp without time zone   NOT NULL,
   idconta          integer                       NOT NULL
);

ALTER TABLE transacaodetalhe
   ADD CONSTRAINT transacaodetalhe_pkey
   PRIMARY KEY (id);

CREATE TABLE IF NOT EXISTS transacaotipo
(
   id         integer       NOT NULL,
   descricao  varchar(30)
);

ALTER TABLE transacaotipo
   ADD CONSTRAINT transacaotipo_pkey
   PRIMARY KEY (id);


ALTER TABLE categoria
  ADD CONSTRAINT categoria_001_fk FOREIGN KEY (id)
  REFERENCES categoria (id)
  ON UPDATE CASCADE
  ON DELETE CASCADE;

ALTER TABLE conta
  ADD CONSTRAINT conta_001_fk FOREIGN KEY (idcontatipo)
  REFERENCES contatipo (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE meiopagamento
  ADD CONSTRAINT meiopagamento_002_fk FOREIGN KEY (idcontapadrao)
  REFERENCES conta (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE meiopagamento
  ADD CONSTRAINT meiopagamento_001_fk FOREIGN KEY (idmeiopagamentotipo)
  REFERENCES meiopagamentotipo (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE meiopagamentofechamento
  ADD CONSTRAINT meiopagamentofechamento_001_fk FOREIGN KEY (idmeiopagamento)
  REFERENCES meiopagamento (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE transacao
  ADD CONSTRAINT transacao_001_fk FOREIGN KEY (idcategoria)
  REFERENCES categoria (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE transacao
  ADD CONSTRAINT transacao_003_fk FOREIGN KEY (idmeiopagamento)
  REFERENCES meiopagamento (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE transacao
  ADD CONSTRAINT transacao_002_fk FOREIGN KEY (idtransacaotipo)
  REFERENCES transacaotipo (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE transacaodetalhe
  ADD CONSTRAINT transacaodetalhe_003_fk FOREIGN KEY (idconta)
  REFERENCES conta (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE transacaodetalhe
  ADD CONSTRAINT transacaodetalhe_002_fk FOREIGN KEY (idmeiopagamento)
  REFERENCES meiopagamento (id)
  ON UPDATE CASCADE
  ON DELETE RESTRICT;

ALTER TABLE transacaodetalhe
  ADD CONSTRAINT transacaodetalhe_001_fk FOREIGN KEY (idtransacao)
  REFERENCES transacao (id)
  ON UPDATE CASCADE
  ON DELETE CASCADE;