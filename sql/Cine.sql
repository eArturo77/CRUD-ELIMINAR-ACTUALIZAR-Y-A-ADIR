CREATE DATABASE Cine

GO

USE Cine

GO

CREATE TABLE Peliculas (
idPeliculas int primary key identity(1,1),
nombrePeliculas varchar (50),
director varchar (50),
fechaLanzamiento datetime
);

GO

INSERT INTO Peliculas VALUES 
('Chicuarote','Jackspirt','2002-1-6'),
('Titanic','Juan','2019-11-1'),
('La bella y la Besita','Martin','2003-10-2'),
('Cenicienta','Pedro','2005-2-3'),
('El Expreso Polar','Julio','2008-3-4'),
('Rapuncel','Jackspirt','2002-6-5');

GO

CREATE PROCEDURE sp_InsertarPelicula
    @nombrePeliculas VARCHAR(50),
    @director VARCHAR(50),
    @fechaLanzamiento DATETIME
AS
BEGIN
    INSERT INTO Peliculas (nombrePeliculas, director, fechaLanzamiento)
    VALUES (@nombrePeliculas, @director, @fechaLanzamiento);
END;
GO


IF OBJECT_ID('AuditoriaPeliculas', 'U') IS NULL
BEGIN
    CREATE TABLE AuditoriaPeliculas (
        idAuditoria INT PRIMARY KEY IDENTITY(1,1),
        nombrePelicula VARCHAR(50),
        accion VARCHAR(20),
        fechaAccion DATETIME
    );
END;
GO

IF OBJECT_ID('trg_AuditoriaPeliculas', 'TR') IS NOT NULL
    DROP TRIGGER trg_AuditoriaPeliculas;
GO

CREATE TRIGGER trg_AuditoriaPeliculas
ON Peliculas
AFTER INSERT
AS
BEGIN
    INSERT INTO AuditoriaPeliculas (nombrePelicula, accion, fechaAccion)
    SELECT nombrePeliculas, 'INSERT', GETDATE()
    FROM inserted;
END;
GO

SELECT * FROM Peliculas
SELECT * FROM AuditoriaPeliculas;