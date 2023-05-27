USE master;
GO

-- Crear la base de datos
CREATE DATABASE crazycola;
GO

USE Crazycola;
GO

-- Crear la tabla "País"
CREATE TABLE dbo.Pais (
    PaisId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    CodigoIso VARCHAR(3)
);
GO

-- Crear la tabla "Ciudad"
CREATE TABLE dbo.Ciudad (
    CiudadId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    PaisId INT FOREIGN KEY REFERENCES dbo.Pais(PaisId)
);
GO


-- Crear la tabla "almacen"
CREATE TABLE dbo.Almacen (
    AlmacenId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Direccion VARCHAR(200),
    CiudadId INT FOREIGN KEY REFERENCES dbo.Ciudad(CiudadId)
);
GO

-- Crear la tabla "usuario"
CREATE TABLE dbo.Usuario (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Email VARCHAR(100),
    Contrasenia VARCHAR(500),
    IsAdmin BIT,
    AlmacenId INT FOREIGN KEY REFERENCES dbo.Almacen(AlmacenId)
);
GO

-- Crear la tabla "producto"
CREATE TABLE dbo.Producto (
    ProductoId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion VARCHAR(200),
    Precio DECIMAL(10, 2)
);
GO

-- Crear la tabla "almacen_producto"
CREATE TABLE dbo.AlmacenProducto (
	AlmacenProductoId INT IDENTITY(1,1) PRIMARY KEY,
    AlmacenId INT,
    ProductoId INT,
    Stock INT,
    FOREIGN KEY (AlmacenId) REFERENCES dbo.Almacen(AlmacenId),
    FOREIGN KEY (ProductoId) REFERENCES dbo.Producto(ProductoId)
);
GO
