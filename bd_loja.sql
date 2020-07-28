DROP DATABASE IF EXISTS loja;
CREATE DATABASE loja;

use loja;

CREATE TABLE `tb_clientes` (
`cod_cliente` INT NOT NULL AUTO_INCREMENT,
`nome_cliente` VARCHAR(80) NOT NULL,
`endereco` VARCHAR (100) NOT NULL,
`bairro` VARCHAR(50) NOT NULL,
`cidade` VARCHAR(50) NOT NULL,
`estado` VARCHAR(2) NOT NULL,		
  PRIMARY KEY (`cod_cliente`) );

CREATE TABLE `tb_usuarios` (
`cod_usuarios` INT NOT NULL AUTO_INCREMENT,
`nome` VARCHAR(80) NOT NULL,
`email` VARCHAR (100) NOT NULL,
`login` VARCHAR(50) NOT NULL,
`senha` VARCHAR(50) NOT NULL,
`cadastro` DATETIME NOT NULL,		
`situacao` VARCHAR(1) NOT NULL,
`perfil` INT NOT NULL,
  PRIMARY KEY (`cod_usuarios`) );


INSERT INTO tb_clientes (nome_cliente, endereco, bairro, cidade, estado)
VALUES ('Joao', 'Rua das Flores', 'Jd.Colorado', 'Mogi das Cruzes', 'SP');

INSERT INTO tb_clientes (nome_cliente, endereco, bairro, cidade, estado)
VALUES ('Maria', 'Rua ABC', 'Jd.Pink', 'Parati', 'RJ');

INSERT INTO tb_clientes (nome_cliente, endereco, bairro, cidade, estado)
VALUES ('Eduadro', 'Rua DEF', 'Vila Flor', 'Cabo Frio', 'RJ');

INSERT INTO tb_clientes (nome_cliente, endereco, bairro, cidade, estado)
VALUES ('Isabella', 'Rua XYZ', 'Vila Velha', 'Mogi das Cruzes', 'SP');

INSERT INTO tb_clientes (nome_cliente, endereco, bairro, cidade, estado)
VALUES ('Maria Rosa', 'Rua Joao XXIII', 'Vila Nova', 'Poá', 'SP');

INSERT INTO tb_usuarios (nome, login, email, senha, cadastro, situacao, perfil)
VALUES ('Joao', 'joao', 'joao@uol.com.br', 123, now(), 'A', 1);

INSERT INTO tb_usuarios (nome, login, email, senha, cadastro, situacao, perfil)
VALUES ('Maria', 'maria', 'maria@uol.com.br', 123, now(), 'A', 2);

INSERT INTO tb_usuarios (nome, login, email, senha, cadastro, situacao, perfil)
VALUES ('Eduardo', 'Edu', 'eduardo@gmail.com', 123, now(), 'A', 3);

INSERT INTO tb_usuarios (nome, login, email, senha, cadastro, situacao, perfil)
VALUES ('Isabele Oliveira', 'isabelle', 'isabelle@gmail.com', 123, now(), 'A', 3);
