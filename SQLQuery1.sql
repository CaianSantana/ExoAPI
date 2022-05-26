CREATE DATABASE ExoAPI
GO
USE ExoAPI

GO

CREATE TABLE Projetos(
	IDProjeto INT PRIMARY KEY IDENTITY,
	Titulo  VARCHAR(50) NOT NULL UNIQUE,
	DataInicio DATE NOT NULL,
	Tecnologia VARCHAR(200) NOT NULL,
	Resquisitos VARCHAR(200),
	Area VARCHAR (50)
)
GO

CREATE TABLE Funcionarios (
    IDFuncionario INT PRIMARY KEY IDENTITY,
	IDProjeto INT FOREIGN KEY REFERENCES Projetos,
	Nome VARCHAR (50) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Senha VARCHAR(120) NOT NULL,
	Nivel CHAR(1) NOT NULL
)

INSERT INTO Funcionarios Values (2,'Junior','Juninho767@Gmail.com','76767',1)
INSERT INTO Funcionarios Values (1,'Cleber','Cleber@Outlook.com','CL3B3R',2)
INSERT INTO Funcionarios Values (1,'Maria','Maria@Gmail.com','Flor123',1)
INSERT INTO Projetos(Titulo, DataInicio, Tecnologia, Resquisitos, Area) Values ('Loja Veterinaria','20100613','SQL Server, C#','.Net, SSMS','Back-End')
INSERT INTO Projetos(Titulo, DataInicio, Tecnologia, Resquisitos, Area) Values ('RPG_Online','20151129','SQL Server, C#','.Net, SSMS, Visual Code Community','Back-End')
SELECT * FROM Projetos
SELECT * FROM Funcionarios

