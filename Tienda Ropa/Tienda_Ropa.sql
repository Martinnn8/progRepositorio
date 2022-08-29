create database TiendaRopa

use TiendaRopa

create table Marcas ( 
id_Marca int constraint pk_marca primary key (id_marca),
nombreMarca varchar (100)
)

create table Inventario (
codigo int constraint pk_codigo primary key (codigo),
precio int,
marca int,
tipo int,
fecha_ingreso datetime
)

insert into Marcas (id_Marca, nombreMarca)
values (1,'Nike')
insert into Marcas (id_Marca, nombreMarca)
values (2,'Adidas')
insert into Marcas (id_Marca, nombreMarca)
values (3,'Puma')
insert into Marcas (id_Marca, nombreMarca)
values (4,'Lacoste')

insert into Inventario (codigo, precio, marca, tipo, fecha_ingreso)
values (1,3000,2,1,'04/06/2020')

insert into Inventario (codigo, precio, marca, tipo, fecha_ingreso)
values (2,7000,4,2,'07/10/2021')