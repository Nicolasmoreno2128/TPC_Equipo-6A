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

insert into Marcas (Nombre,Descripcion,Estado)
Values 
('Canon','Primera Marca',1),
('Piero','Casi primera Marca',1),
('Calm','Colchones instagram',1),
('Colchones Juli','Los mejores de Argentina',1);



select IdProducto, Nombre, Descripcion, Estado from Marcas