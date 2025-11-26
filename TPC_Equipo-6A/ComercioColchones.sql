

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

-- USUARIOS: Admins y Vendedores (más realistas)
INSERT INTO USUARIO (NombreUsuario, Contrasena, Nombre, Apellido, Rol, Email, Telefono, Estado)
VALUES
-- Administradores
('admin.jmoreno', 'Admin123!', 'Javier', 'Moreno', 0, 'j.moreno@colchonescocos.com', '1155998877', 1),
('admin.lmartinez', 'Admin123!', 'Lourdes', 'Martínez', 0, 'l.martinez@colchonescocos.com', '1155779911', 1),
-- Vendedores
('vendedor.nadia', 'Vende123!', 'Nadia', 'Rojas', 1, 'n.rojas@colchonescocos.com', '1162335577', 1),
('vendedor.federico', 'Vende123!', 'Federico', 'Sanchez', 1, 'f.sanchez@colchonescocos.com', '1144889922', 1),
('vendedor.martina', 'Vende123!', 'Martina', 'Gómez', 1, 'm.gomez@colchonescocos.com', '1144112255', 1),
('vendedor.julieta', 'Vende123!', 'Julieta', 'Fernández', 1, 'j.fernandez@colchonescocos.com', '1155227711', 1),
--TEST
('test', '1', 'test', 'test', 0, 'test@colchonescocos.com', '1155779911', 1);


insert into Categorias (NombreCategoria,DescripcionCategoria,Estado)
Values 
('1 Plaza','La medida es 80 x 190',1),
('1 Plaza y Media','La medida es 100 x 190',1),
('2 Plazas','La medida es 140 x 190',1),
('Sommiers', 'Bases para colchones de todas las medidas', 1),
('Almohadas', 'Almohadas viscoelásticas, de fibra y látex', 1),
('Blanquería', 'Sábanas, acolchados y protectores de colchón', 1);

insert into Marcas (NombreMarca,DescripcionMarca,Estado)
Values 
('Canon', 'Marca líder en descanso, colchones ortopédicos y premium.', 1),
('Piero', 'Fabricante nacional con líneas de espuma y resortes.', 1),
('Suavestar', 'Marca reconocida de colchones clásicos y ortopédicos.', 1),
('Rosen', 'Marca premium internacional especializada en sommiers.', 1),
('Inducol', 'Marca argentina con líneas ortopédicas y alta densidad.', 1),
('Calm', 'Marca moderna de colchones viscoelásticos.', 1),
('Simmons', 'Marca internacional premium de resortes y pillow-top.', 1),
('La Cardeuse', 'Marca argentina tradicional de colchones duraderos.', 1);

insert into PRODUCTO (NombreProducto,DescripcionProducto,UrlImagen,PrecioProducto,IdMarca,IdCategoria,Stock)
Values 
('Canon Exclusive','29 cm de altura','aaa',215000,1,1,100),
('Piero Foam','23 cm de altura','aaa',2400000,3,1,4),
('Gani Silver','25 cm de altura','aaa',304478,2,2,100),
('Canon Ortopédico 1 Plaza y Media','Colchón ortopédico de alta densidad, ideal para uso diario.','img/canon_ortopedico_1pym.jpg',150000, 1, 2, 20),
('Piero Spring 2 Plazas','Colchón con resortes bicónicos y euro top, nivel de firmeza medio.','img/piero_spring_2p.jpg', 185000, 2, 3, 15),
('Calm Soft 2 Plazas','Colchón de espuma soft con capa viscoelástica, muy confortable.','img/calm_soft_2p.jpg',210000, 3, 3, 10),
('Almohada Viscoelástica Relax','Almohada viscoelástica de 70 cm, funda desmontable.', 'img/almohada_visco_relax.jpg', 95000, 4, 5, 50),
('Sommier 2 Plazas Piero','Base sommier 2 plazas con patas de madera lustrada.','img/sommier_piero_2p.jpg',120000, 2, 4, 8),
('Protector de Colchón 2 Plazas','Protector impermeable respirable para colchón de 2 plazas.','img/protector_2p.jpg', 60000, 1, 6, 30),
('Juego de Sábanas 2 Plazas','Juego de sábanas de algodón 144 hilos, diseño liso.','img/sabanas_2p.jpg',75000, 3, 6, 25);

insert into CLIENTE (Nombre,Cuit,Descripcion,Telefono,Email)
Values 
('María García','20-33344455-9','Cliente frecuente de zona norte, compra colchones y sommiers.','1145897744','maria.garcia@mail.com'),
('Carlos López','20-32288899-1','Cliente que suele comprar combos colchón + sommier.','1145012233','carlos.lopez@mail.com'),
('Laura Fernández','27-30123456-7','Cliente empresa (hotel boutique), compra por mayor.','1145129987','laura.fernandez@hotelbosque.com'),
('Julián Pereyra', '20-28765432-7', 'Cliente minorista, suele comprar almohadas y protectores.','1133445566', 'julian.pereyra@mail.com'),
('Sofía Martínez', '27-25483920-5','Compra colchones de 2 plazas y blanquería para su familia.','1145672398', 'sofia.martinez@mail.com'),
('Federico Álvarez', '20-34219876-3','Cliente que renueva colchones cada 2 años, vive en Caballito.','1123459876', 'federico.alvarez@mail.com'),
('Hotel Boutique Palermo', '30-57834212-9','Cliente empresa; compra colchones y sommiers en volumen.','1135667788', 'compras@hotelpalermo.com'),
('Mariana Torres', '27-32987465-1','Cliente que suele comprar protectores y sábanas premium.','1149871122', 'mariana.torres@mail.com'),
('Luis Ocampo', '20-29123456-8','Cliente regular, compra tanto colchones como almohadas.','1124556677', 'luis.ocampo@mail.com'),
('Estudio Jurídico Robles', '30-64537219-1','Cliente empresa; compra sillones y colchones para departamentos temporarios.','1155337811', 'contacto@estudiorobles.com'),
('Valentina Herrera', '27-31987654-2','Compra sommier y accesorios para su departamento nuevo.','1144229933', 'valentina.herrera@mail.com'),
('Matías Sosa', '20-27654321-3','Cliente que suele comprar colchones de alta densidad.','1133224455', 'matias.sosa@mail.com'),
('Carolina Núñez', '27-29786543-0', 'Cliente frecuente de zona sur, compra blanquería premium.','1144117799', 'carolina.nunez@mail.com');


insert into PROVEEDOR(Nombre,Cuit,Descripcion,Telefono,Email)
Values 
('Julián Pereyra', '20-28765432-7','Cliente minorista, suele comprar almohadas y protectores.', '1133445566', 'julian.pereyra@mail.com'),
('Sofía Martínez', '27-25483920-5', 'Compra colchones de 2 plazas y blanquería para su familia.', '1145672398', 'sofia.martinez@mail.com'),
('Federico Álvarez', '20-34219876-3', 'Cliente que renueva colchones cada 2 años, vive en Caballito.','1123459876', 'federico.alvarez@mail.com'),
('Hotel Boutique Palermo', '30-57834212-9','Cliente empresa; compra colchones y sommiers en volumen.', '1135667788', 'compras@hotelpalermo.com'),
('Mariana Torres', '27-32987465-1', 'Cliente que suele comprar protectores y sábanas premium.', '1149871122', 'mariana.torres@mail.com'),
('Luis Ocampo', '20-29123456-8', 'Cliente regular, compra tanto colchones como almohadas.', '1124556677', 'luis.ocampo@mail.com'),
('Estudio Jurídico Robles', '30-64537219-1','Cliente empresa; compra sillones y colchones para departamentos temporarios.','1155337811', 'contacto@estudiorobles.com'),
('Valentina Herrera', '27-31987654-2','Compra sommier y accesorios para su departamento nuevo.', '1144229933', 'valentina.herrera@mail.com'),
('Matías Sosa', '20-27654321-3', 'Cliente que suele comprar colchones de alta densidad.', '1133224455', 'matias.sosa@mail.com'),
('Carolina Núñez', '27-29786543-0', 'Cliente frecuente de zona sur, compra blanquería premium.', '1144117799', 'carolina.nunez@mail.com');
INSERT INTO COMPRA (IdProveedor, FechaCompra, FechaRecepcion, TotalCompra, Estado)
VALUES
-- Compra 1: Cannon
(1, '2025-10-01 09:30', '2025-10-03 10:00', 1710000, 1),
-- Compra 2: Piero
(2, '2025-10-05 14:15', '2025-10-08 16:30', 4333434, 1),
-- Compra 3: Suavegom (deja pendiente la recepción)
(3, '2025-10-10 11:00', NULL, 1800000, 1),
(1, '2025-10-12 09:15', '2025-10-14 10:30', 1280000, 1),
(2, '2025-10-15 13:45', '2025-10-17 16:00', 2580000, 1),
(5, '2025-10-19 11:20', NULL, 1750000, 1),
(4, '2025-10-22 15:50', '2025-10-24 12:15', 980000, 1),
(3, '2025-10-25 10:05', NULL, 2250000, 1);

INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
VALUES
(1, 1, 10, 20000),    
(1, 4,  5, 150000),    
(1, 7,  8, 95000);     

INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
VALUES
(2, 2, 4, 240000),    
(2, 3, 3, 304478),    
(2, 6, 6, 210000),    
(2, 8,10, 120000);     

INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
VALUES
(3, 9, 15, 60000),     
(3,10, 12, 75000);

INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
VALUES
(4, 1, 20, 20000),      -- Canon Exclusive
(4, 7,  6, 95000);      -- Almohadas

INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
VALUES
(5, 2, 5, 240000),      -- Piero Foam
(5, 6, 8, 210000);      -- Calm Soft

INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
VALUES
(6, 9, 20, 60000),      -- Protector colchón
(6, 10, 5, 75000);      -- Sábanas

INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
VALUES
(7, 4, 4, 150000),      -- Canon Ortopédico
(7, 1, 8, 20000);       -- Canon Exclusive

INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
VALUES
(8, 6, 5, 210000),       -- Calm Soft 2 plazas
(8, 8, 10, 120000);      -- Sommier Piero
---------------------------------
----------VENTA------------------
---------------------------------
INSERT INTO VENTA (IdCliente, FechaVenta, TotalVenta, IdUsuario, Estado)
VALUES
(1, '2025-11-20 10:30', 340000, 2, 1),
(2, '2025-11-21 17:15', 544478, 3, 1),
(3, '2025-11-22 11:45', 215000, 2, 1),
(4, '2025-11-25 14:20', 340000, 3, 1),
(5, '2025-11-26 10:50', 585000, 4, 1),
(6, '2025-11-26 15:15', 135000, 5, 1),
(2, '2025-11-27 11:40', 310000, 6, 1),
(1, '2025-11-28 09:00', 304478, 3, 1),
(3, '2025-11-28 13:45', 475000, 4, 1),
(6, '2025-11-29 16:10', 680000, 5, 1);


---------------------------------
------Detalles Venta--------------
---------------------------------
INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(1, 4, 1, 150000), 
(1, 7, 2, 95000);   

INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(2, 2, 1, 240000), 
(2, 3, 1, 304478);  

INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(3, 9, 2, 60000),    
(3,10, 1, 75000),    
(3, 1, 1, 20000);    
INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(4, 4, 1, 150000),
(4, 7, 2, 95000);

INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(5, 2, 1, 240000),
(5, 6, 1, 210000),
(5, 9, 2, 60000);

INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(6, 9, 1, 60000),
(6,10, 1, 75000);

INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(7, 8, 1, 120000),
(7, 7, 2, 95000);

INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(8, 3, 1, 304478);

INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(9, 1, 1, 20000),
(9, 4, 1, 150000),
(9, 6, 1, 210000),
(9,10, 1, 75000);

INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario)
VALUES
(10, 6, 2, 210000),
(10, 9, 3, 60000);



--------------------------
-- CONSULTAS DE PRUEBAS --
--------------------------

select IdMarca, NombreMarca, DescripcionMarca, Estado from Marcas

select IdCategoria, NombreCategoria, DescripcionCategoria, Estado from Categorias

select P.IdProducto, P.NombreProducto, P.DescripcionProducto, P.UrlImagen, P.PrecioProducto, M.NombreMarca, C.NombreCategoria, P.Stock FROM PRODUCTO P, Categorias C, Marcas M where C.IdCategoria = P.IdCategoria and M.IdMarca = P.IdMarca and P.Estado = 1

select * from PRODUCTO

select * from DETALLE_COMPRA

select * from COMPRA

