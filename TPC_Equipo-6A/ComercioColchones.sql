create database ComercioColchones
go
use ComercioColchones
go
create table Marcas (
	IdProducto bigint primary key not null identity (1,1),
	Nombre varchar (150) not null,
	Descripcion varchar (300) not null,
	Estado bit not null
)
go

create table Categorias (
	IdCategoria bigint primary key not null identity (1,1),
	Nombre varchar (150) not null,
	Descripcion varchar (300) not null,
	Estado bit not null
)
go

CREATE TABLE PRODUCTO (
	IdProducto INTEGER NOT NULL IDENTITY (1,1) PRIMARY KEY,
	Nombre VARCHAR(255) NOT NULL,
	Descripcion VARCHAR(255) NOT NULL,
	UrlImagen VARCHAR(255) NOT NULL,
	Precio DECIMAL NOT NULL,
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








insert into Categorias (Nombre,Descripcion,Estado)
Values 
('1 Plaza','La medida es 80 x 190',1),
('1 Plaza y Media','La medida es 100 x 190',1),
('2 Plazas','La medida es 140 x 190',1);



insert into Marcas (Nombre,Descripcion,Estado)
Values 
('Canon','Primera Marca',1),
('Piero','Casi primera Marca',1),
('Calm','Colchones instagram',1),
('Colchones Juli','Los mejores de Argentina',1);



select IdProducto, Nombre, Descripcion, Estado from Marcas

select IdCategoria, Nombre, Descripcion, Estado from Categorias