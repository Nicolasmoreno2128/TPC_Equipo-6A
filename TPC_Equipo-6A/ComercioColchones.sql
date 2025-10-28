use master
go
create database ComercioColchones
go
create table Marca (
IdProducto bigint not null identity (1,1) primary key,
Nombre varchar (150) not null,
Descripcion varchar (300) null,
Estado bit not null
)

go

insert into Marca (Nombre,Descripcion,Estado)
Values 
('Canon','Primera Marca',1),
('Piero','Casi primera Marca',1),
('Calm','Colchones instagram',1),
('Colchones Juli','Los mejores de Argentina',1);



