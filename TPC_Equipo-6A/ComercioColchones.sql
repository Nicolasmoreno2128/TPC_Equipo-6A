create database ComercioColchones
go
use ComercioColchones
go
create table Marcas (
	IdMarca bigint primary key not null identity (1,1),
	NombreMarca varchar (150) not null,
	DescripcionMarca varchar (300) not null,
	Estado bit not null
)
go

create table Categorias (
	IdCategoria bigint primary key not null identity (1,1),
	NombreCategoria varchar (150) not null,
	DescripcionCategoria varchar (300) not null,
	Estado bit not null
)
go

CREATE TABLE PRODUCTO (
	IdProducto INTEGER NOT NULL IDENTITY (1,1) PRIMARY KEY,
	NombreProducto VARCHAR(255) NOT NULL,
	DescripcionProducto VARCHAR(255) NOT NULL,
	UrlImagen VARCHAR(255) NOT NULL,
	PrecioProducto DECIMAL NOT NULL,
	IdMarca INTEGER NOT NULL,
	IdCategoria SMALLINT NOT NULL,
	Stock INTEGER NOT NULL,
	Estado BIT NOT NULL DEFAULT 1,
	)

GO

CREATE TABLE PROVEEDOR (
	IdProveedor INTEGER NOT NULL IDENTITY (1,1) primary key,
	Nombre VARCHAR(255) NOT NULL,
	Descripcion VARCHAR(255) NOT NULL,
	Cuit INTEGER NOT NULL,
	Telefono INTEGER NOT NULL,
	Email VARCHAR(255),
	Estado BIT NOT NULL,
	)
GO

CREATE TABLE CLIENTE (
	IdCliente INTEGER NOT NULL IDENTITY (1,1) PRIMARY KEY,
	Nombre VARCHAR(255),
	Cuit INTEGER,
	Descripcion VARCHAR(255),
	Telefono INTEGER,
	Email VARCHAR(255),
	Estado BIT,
	)

CREATE TABLE USUARIO (
	IdUsuario bigint primary key not null identity (1,1),
	NombreUsuario varchar(50) not null,
	Contrasena varchar (50) not null,
	Nombre varchar (50),
	Apellido varchar (50),
	Rol integer not null,
	Email varchar (100),
	Telefono bigint,
	Estado bit not null default 1
)

INSERT INTO USUARIO (NombreUsuario, Contrasena, Nombre, Apellido, Rol, Email, Telefono, Estado)
VALUES
('admin1', 'pasa123', 'Juan', 'Pérez', 0, 'juan.perez@cocos.com', 59891112222, 1),
('vendedor1', 'pasa123', 'Ana', 'López', 1, 'ana.lopez@cocos.com', 59892223333, 1),
('vendedor2', 'pasa123', 'Marcos', 'Fernández', 1, 'marcos.fernandez@cocos.com', 59893334444, 1),
('admin2', 'pasa123', 'Lucía', 'Martínez', 0, 'lucia.martinez@cocos.com', 59894445555, 1),
('vendedor3', 'pasa123', 'Diego', 'Gómez', 1, 'diego.gomez@cocos.com', NULL, 1);



insert into Categorias (NombreCategoria,DescripcionCategoria,Estado)
Values 
('1 Plaza','La medida es 80 x 190',1),
('1 Plaza y Media','La medida es 100 x 190',1),
('2 Plazas','La medida es 140 x 190',1);



insert into Marcas (NombreMarca,DescripcionMarca,Estado)
Values 
('Canon','Primera Marca',1),
('Piero','Casi primera Marca',1),
('Calm','Colchones instagram',1),
('Colchones Juli','Los mejores de Argentina',1);

insert into PRODUCTO (NombreProducto,DescripcionProducto,UrlImagen,PrecioProducto,IdMarca,IdCategoria,Stock)
Values 
('Canon Exclusive','29 cm de altura','aaa',20000,1,1,100);




select IdMarca, NombreMarca, DescripcionMarca, Estado from Marcas

select IdCategoria, NombreCategoria, DescripcionCategoria, Estado from Categorias

select P.IdProducto, P.NombreProducto, P.DescripcionProducto, P.UrlImagen, P.PrecioProducto, M.NombreMarca, C.NombreCategoria, P.Stock FROM PRODUCTO P, Categorias C, Marcas M where C.IdCategoria = P.IdCategoria and M.IdMarca = P.IdMarca and P.Estado = 1


select * from PRODUCTO