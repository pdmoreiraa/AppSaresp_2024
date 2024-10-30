-- drop database Saresp_2024;
create database Saresp_2024;
use Saresp_2024;

create table professorAplicador(
idProfessor int primary key auto_increment,
nome varchar(50) not null,
CPF varchar(11) not null,
RG varchar(9) not null,
telefone varchar(11) not null,
dataNasc datetime not null
);

create table aluno(
idAluno int primary key auto_increment,
nome varchar(50) not null,
email varchar(150) not null,
serie varchar(1) not null,
turma varchar(30) not null,
telefone varchar(11) not null,
dataNasc datetime not null
);