CREATE DATABASE dbacademico;

drop database dbacademico;

USE dbacademico;

-----------------------------------------------------------
--LOGIN----------------------------------------------------

CREATE TABLE tblusuarios(
	usuid		int			not null,
	usunome		varchar(50)	not null,
	usuemail	varchar(50)	not null unique,
	ususenha	varchar(25)	not null,
	usuativo	varchar(1)	not null default 'S',
	primary key (usuid) 
);

INSERT INTO tblusuarios(usuid, usunome, usuemail, ususenha, usuativo) 
	VALUES(1, 'CASSIO', 'cassiocamargos@gmail.com', '12345678','S');

UPDATE tblusuarios SET usunome = 'Admin', usuemail = 'cassio@admin.com', ususenha = 'admin123', usuativo = 'S' WHERE usuid = 1; 

SELECT * 
	FROM tblusuarios;


-----------------------------------------------------------
--FACULDADE------------------------------------------------

CREATE TABLE tblperiodos(
	perid		int			not null,
	pernome		varchar(50)	not null,
	persigla	varchar(5)	not null,
	primary key (perid) 
);

CREATE TABLE tblcursos(
	curid			int				not null,
	curnome			varchar(50)		not null,
	cursigla		varchar(25)		not null,
	curobservacoes	varchar(500)	null,
	perid			int				not null,
	primary key (curid),
	foreign key (perid) references tblperiodos (perid)
);

CREATE TABLE tbldisciplinas(
	discid			int				not null,
	discnome		varchar(50)		not null,
	discsigla		varchar(25)		not null,
	discobservacoes	varchar(500)	null,
	curid			int				not null,
	primary key (discid),
	foreign key (curid) references tblcursos (curid)
);

CREATE TABLE tbldisciplinascursos(
	discid		int		not null,
	curid		int		not null,
	primary key (discid, curid),
	foreign key (discid) references tbldisciplinas (discid),
	foreign key (curid) references tblcursos (curid)
);

------------------------------------------------------------
SELECT perid, pernome, persigla
	FROM tblperiodos order by pernome asc;


INSERT INTO tblperiodos(perid, pernome, persigla) 
	VALUES(1, 'MATUTINO', 'MTT');

UPDATE tblperiodos
		SET pernome = 'a',
			persigla = 'a'
	WHERE perid = 1;

DELETE FROM tblperiodos WHERE perid = 1;

select isnull((max(estid) + 1), 0)
  from tblperiodos;

---------------------------------------------------------

SELECT * 
	FROM tblcursos;

SELECT * 
	FROM tbldisciplinas;
