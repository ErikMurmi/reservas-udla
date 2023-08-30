USE master ;
DROP DATABASE IF EXISTS ReservasCanchasUDLA
GO
CREATE DATABASE ReservasCanchasUDLA
GO
USE ReservasCanchasUDLA
GO

DROP TABLE IF EXISTS Usuario 
GO
CREATE TABLE Usuario (
    ID INT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL, -- Reduced email length
    Password VARCHAR(255) NOT NULL,
    Nombre VARCHAR(255) NOT NULL,
    ID_Banner INT UNIQUE NOT NULL,
    Carrera VARCHAR(50) NOT NULL -- Reduced Carrera length
);

DROP TABLE IF EXISTS Cancha 
GO
CREATE TABLE Cancha (
    ID INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Campus VARCHAR(20) NOT NULL,
    Hora_inicio TIME NOT NULL,
    Hora_fin TIME NOT NULL,
    Deporte VARCHAR(255) NOT NULL,
    Habilitada BIT NOT NULL
);

DROP TABLE IF EXISTS Solicitud 
GO
CREATE TABLE Solicitud (
    ID INT PRIMARY KEY,
    UsuarioID INT NOT NULL,
    Fecha DATE NOT NULL,
    Motivo TEXT NOT NULL,
    Estado VARCHAR(10)  NOT NULL,
    CONSTRAINT usuarioFK FOREIGN KEY (UsuarioID) REFERENCES Usuario(ID),
	CONSTRAINT estadosSolcitud CHECK (Estado IN ('Pendiente', 'Aceptada', 'Denegada'))
);

DROP TABLE IF EXISTS Reserva 
GO
CREATE TABLE Reserva (
    ID INT PRIMARY KEY,
    SolicitudID INT NOT NULL,
    CanchaID INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora_inicio TIME NOT NULL,
    Hora_fin TIME NOT NULL,
    Estado VARCHAR(10) NOT NULL,
    CONSTRAINT solicitudFK FOREIGN KEY (SolicitudID) REFERENCES Solicitud(ID),
	CONSTRAINT canchaFK FOREIGN KEY (CanchaID) REFERENCES Cancha(ID),
	CONSTRAINT estadosReserva CHECK (Estado IN ( 'Aceptada', 'Cancelada'))
);

