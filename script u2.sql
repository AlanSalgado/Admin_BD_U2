create database AdmBD;
use AdmBD;

create table AREAS(
id			int 	auto_increment 	primary key,
Nombre		varchar(45),
Ubicacion	varchar(45),
activo		int
);

create table INVENTARIO(
id				int auto_increment primary key,
NombreCorto		varchar(45),
Descripcion		varchar(45),
Serie			varchar(45),
Color			varchar(45),
FechaAdquision	varchar(45),
TipoAdquision	varchar(45),
Observaciones	varchar(45),
activo int,
AREAS_ID		int				not null,
foreign key FK_AreasInvt (AREAS_ID) references AREAS(id) 
);

select * from areas;
select * from inventario;