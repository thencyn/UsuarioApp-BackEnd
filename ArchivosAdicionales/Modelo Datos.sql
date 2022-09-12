/*
DROP TABLE RolPantalla;
DROP TABLE Usuario;
DROP TABLE Rol;
DROP TABLE Pantalla;
*/
CREATE TABLE Rol (
IdRol INT identity(1,1) NOT NULL,
Nombre VARCHAR(30)  NOT NULL,
RegistroVigente BIT  NOT NULL
);
ALTER TABLE Rol ADD CONSTRAINT PK_Rol PRIMARY KEY (IdRol);


CREATE TABLE Usuario (
IdUsuario INT identity(1,1) NOT NULL,
IdRol INT  NOT NULL,
Correo VARCHAR(30)  NOT NULL,
Nombre VARCHAR(30)  NOT NULL,
PasswordHash binary(64) NOT NULL,
PasswordSalt binary(128) NOT NULL,
FechaCreacion DATETIME  NOT NULL,
RegistroVigente BIT  NOT NULL
);
ALTER TABLE Usuario ADD CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario);
ALTER TABLE Usuario ADD CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Rol (IdRol);


CREATE TABLE Pantalla
(
  IdPantalla int NOT NULL,
  Descripcion VARCHAR(50) NOT NULL,
  PathUrl VARCHAR(200),
  Icono VARCHAR(30),
  IdPantallaPadre INT,
  Orden INT NOT NULL,
  RegistroVigente bit NOT NULL
);
ALTER TABLE Pantalla ADD CONSTRAINT PK_Pantalla PRIMARY KEY (IdPantalla);


CREATE TABLE RolPantalla
(
  IdRolPantalla INT identity(1,1),
  IdPantalla INT NOT NULL,
  IdRol INT NOT NULL
);
ALTER TABLE RolPantalla ADD CONSTRAINT PK_RolPantalla PRIMARY KEY (IdRolPantalla);
ALTER TABLE RolPantalla ADD CONSTRAINT FK_RolPantalla_Rol FOREIGN KEY (IdRol) REFERENCES Rol (IdRol);
ALTER TABLE RolPantalla ADD CONSTRAINT FK_RolPantalla_Pantalla FOREIGN KEY (IdPantalla) REFERENCES Pantalla (IdPantalla);


INSERT INTO Rol (Nombre, RegistroVigente) VALUES('Administrador', 1);
INSERT INTO Pantalla(IdPantalla, Descripcion, PathUrl, Icono, IdPantallaPadre, Orden, RegistroVigente) VALUES(1000, 'Mantenedores', '', 'fa fa-home', NULL, 1000, 1);
INSERT INTO Pantalla(IdPantalla, Descripcion, PathUrl, Icono, IdPantallaPadre, Orden, RegistroVigente) VALUES(1010, 'Usuarios', '/sistema/mantenedores/usuarios', 'fa fa-user', 1000, 1010, 1);
INSERT INTO Pantalla(IdPantalla, Descripcion, PathUrl, Icono, IdPantallaPadre, Orden, RegistroVigente) VALUES(1020, 'Roles', '/sistema/mantenedores/roles', 'fa fa-user', 1000, 1020, 1);
INSERT INTO Pantalla(IdPantalla, Descripcion, PathUrl, Icono, IdPantallaPadre, Orden, RegistroVigente) VALUES(1030, 'Clientes', '/sistema/mantenedores/clientes', 'fa fa-user', 1000, 1030, 1);

INSERT INTO RolPantalla(IdPantalla, IdRol) SELECT IdPantalla, 1 FROM Pantalla;