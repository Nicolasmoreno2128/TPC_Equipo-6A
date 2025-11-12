

----------------------
--CREACION DE TABLAS--
----------------------


CREATE DATABASE ComercioColchones
GO
USE ComercioColchones
GO
CREATE TABLE MARCAS (
	IdMarca INT PRIMARY KEY not null IDENTITY (1,1),
	NombreMarca VARCHAR (150) not null,
	DescripcionMarca VARCHAR (300) not null,
	Estado BIT not null DEFAULT 1
)
go

CREATE TABLE CATEGORIAS (
	IdCategoria INT PRIMARY KEY not null IDENTITY (1,1),
	NombreCategoria VARCHAR (150) not null,
	DescripcionCategoria VARCHAR (300) not null,
	Estado BIT not null DEFAULT 1
)
go

CREATE TABLE PRODUCTO (
	IdProducto INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	NombreProducto VARCHAR (150) NOT NULL,
	DescripcionProducto VARCHAR(300) NOT NULL,
	UrlImagen VARCHAR(255) NULL,
	PrecioProducto DECIMAL NOT NULL,
	IdMarca INT NOT NULL FOREIGN KEY REFERENCES MARCAS(IdMarca),
	IdCategoria INT NOT NULL FOREIGN KEY REFERENCES CATEGORIAS(IdCategoria),
	Stock INT NOT NULL,
	Estado BIT NOT NULL DEFAULT 1
	)

GO

select * from PRODUCTO

CREATE TABLE PROVEEDOR (
	IdProveedor INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	Nombre VARCHAR (150) NOT NULL,
	Descripcion VARCHAR (300) NOT NULL,
	Cuit VARCHAR (30) NOT NULL,
	Telefono VARCHAR (30) NOT NULL,
	Email VARCHAR (250),
	Estado BIT NOT NULL DEFAULT 1
	)
GO
CREATE TABLE CLIENTE (
	IdCliente INT PRIMARY KEY NOT NULL IDENTITY (1,1) ,
	Nombre VARCHAR(255),
	Cuit VARCHAR (30),
	Descripcion VARCHAR(300),
	Telefono VARCHAR (30),
	Email VARCHAR(250),
	Estado BIT NOT NULL DEFAULT 1
	)
GO
CREATE TABLE USUARIO (
	IdUsuario INT PRIMARY KEY not null IDENTITY (1,1),
	NombreUsuario VARCHAR(50) not null,
	Contrasena VARCHAR (50) not null,
	Nombre VARCHAR (50) not null,
	Apellido VARCHAR (50) not null,
	Rol INT not null,
	Email VARCHAR (250) not null,
	Telefono VARCHAR (30) not null,
	Estado BIT not null DEFAULT 1
)
GO


CREATE TABLE VENTA (
	IdVenta INT PRIMARY KEY not null IDENTITY (1,1),
	IdCliente INT not null FOREIGN KEY REFERENCES CLIENTE (IdCliente),
	FechaVenta DATETIME not null,
	TotalVenta DECIMAL not null,
	IdUsuario INT not null FOREIGN KEY REFERENCES USUARIO (IdUsuario),
	Estado BIT not null DEFAULT 1
)
GO
CREATE TABLE DETALLE_VENTA (
	IdDetalleVenta INT PRIMARY KEY not null IDENTITY (1,1),
	IdVenta INT not null FOREIGN KEY REFERENCES VENTA (IdVenta),
	IdProducto INT not null FOREIGN KEY REFERENCES PRODUCTO (IdProducto),
	Cantidad INT not null,
	PrecioUnitario DECIMAL not null
)
GO
CREATE TABLE COMPRA (
	IdCompra INT PRIMARY KEY not null IDENTITY (1,1),
	IdProveedor INT not null FOREIGN KEY REFERENCES PROVEEDOR (IdProveedor),
	FechaCompra DATETIME not null,
	FechaRecepcion DATETIME null,
	TotalCompra DECIMAL not null,
	Estado BIT not null DEFAULT 1
)
GO
CREATE TABLE DETALLE_COMPRA (
	IdDetalleCompra INT PRIMARY KEY not null IDENTITY (1,1),
	IdCompra INT not null FOREIGN KEY REFERENCES COMPRA (IdCompra),
	IdProducto INT not null FOREIGN KEY REFERENCES PRODUCTO (IdProducto),
	Cantidad INT not null,
	PrecioUnitario DECIMAL not null
)
GO
CREATE TABLE PAGO (
	IdPago INT PRIMARY KEY not null IDENTITY (1,1),
	IdVenta INT not null FOREIGN KEY REFERENCES VENTA (IdVenta),
	FechaPago DATETIME not null,
	Monto DECIMAL not null,
	MetodoPago VARCHAR (30),
	Estado BIT not null DEFAULT 1
)


------------------------
-- INSERCION DE DATOS --
------------------------

INSERT INTO USUARIO (NombreUsuario, Contrasena, Nombre, Apellido, Rol, Email, Telefono, Estado)
VALUES
('admin1', 'pasa123', 'Juan', 'Pérez', 0, 'juan.perez@cocos.com', 59891112222, 1),
('vendedor1', 'pasa123', 'Ana', 'López', 1, 'ana.lopez@cocos.com', 59892223333, 1),
('vendedor2', 'pasa123', 'Marcos', 'Fernández', 1, 'marcos.fernandez@cocos.com', 59893334444, 1),
('admin2', 'pasa123', 'Lucía', 'Martínez', 0, 'lucia.martinez@cocos.com', 59894445555, 1),
('vendedor3', 'pasa123', 'Diego', 'Gómez', 1, 'diego.gomez@cocos.com', 5491130323652, 1);


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
('Canon Exclusive','29 cm de altura','aaa',20000,1,1,100),
('Piero Foam','23 cm de altura','aaa',2400000,3,1,4),
('Gani Silver','25 cm de altura','aaa',304478,2,2,100);

insert into CLIENTE (Nombre,Cuit,Descripcion,Telefono,Email)
Values 
('Julian Parodi','22222222','aasdasdasaa','1111111111','asdasd@asdasd'),
('Guido Jaulin','4567867','aasdasdasaa','678567547','asdasd@asdasd'),
('Nicolas Moreno','757527856','aasdasdasaa','6785675788','asdasd@asdasd');


insert into PROVEEDOR(Nombre,Cuit,Descripcion,Telefono,Email)
Values 
('CANNON','22222222','aasdasdasaa','1111111111','asdasd@asdasd'),
('PIERO','4567867','aasdasdasaa','678567547','asdasd@asdasd'),
('SUAVEGOM','4567867','aasdasdasaa','678567547','asdasd@asdasd'),
('DESEO','4567867','aasdasdasaa','678567547','asdasd@asdasd'),
('SUAVESTAR','757527856','aasdasdasaa','6785675788','asdasd@asdasd');

--------------------------
-- CONSULTAS DE PRUEBAS --
--------------------------

select IdMarca, NombreMarca, DescripcionMarca, Estado from Marcas

select IdCategoria, NombreCategoria, DescripcionCategoria, Estado from Categorias

select P.IdProducto, P.NombreProducto, P.DescripcionProducto, P.UrlImagen, P.PrecioProducto, M.NombreMarca, C.NombreCategoria, P.Stock FROM PRODUCTO P, Categorias C, Marcas M where C.IdCategoria = P.IdCategoria and M.IdMarca = P.IdMarca and P.Estado = 1

select * from PRODUCTO

