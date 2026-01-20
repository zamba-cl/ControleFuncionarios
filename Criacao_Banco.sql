CREATE TABLE Cargo(
idCargo INT PRIMARY KEY IDENTITY(1,1),
nomeCargo VARCHAR (25),
salario DECIMAL(18,2)
)

CREATE TABLE Funcionario(
idFuncionario INT PRIMARY KEY IDENTITY(1,1),
nomeFuncionario VARCHAR (255) NOT NULL,
dtAdmissao DATE NOT NULL,
statusFuncionario BIT NOT NULL DEFAULT 1,
idCargo INT NOT NULL,
FOREIGN KEY (idCargo) REFERENCES Cargo(idCargo)
)

CREATE TABLE Ferias(
idFerias INT PRIMARY KEY IDENTITY(1,1),
dtInicio DATE NOT NULL,
dtTermino DATE NOT NULL,
statusFerias VARCHAR(10) NOT NULL,
idFuncionario INT NOT NULL,
FOREIGN KEY (idFuncionario) REFERENCES Funcionario(idFuncionario)
)

CREATE TABLE Alteracao(
idAlteracao INT PRIMARY KEY IDENTITY(1,1),
dtHrAlteracao DATETIME2 NOT NULL,
campoAlterado VARCHAR(255) NOT NULL,
valorAntigo VARCHAR(255) NOT NULL,
valorNovo VARCHAR(255) NOT NULL,
idFuncionario INT NOT NULL,
FOREIGN KEY (idFuncionario) REFERENCES Funcionario(idFuncionario)
)
