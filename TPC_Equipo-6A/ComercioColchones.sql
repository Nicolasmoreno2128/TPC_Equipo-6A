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