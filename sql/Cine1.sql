CREATE DATABASE Cine1

GO

USE Cine1

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

SELECT * FROM Peliculas