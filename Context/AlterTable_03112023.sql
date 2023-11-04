alter table marca add timestamp datetime not null default getdate();
alter table AutoProducto add timestamp datetime not null default getdate();
alter table Auto add timestamp datetime not null default getdate();
alter table Producto add timestamp datetime not null default getdate();
alter table Proveedor add timestamp datetime not null default getdate();
alter table TipoProducto add timestamp datetime not null default getdate();
drop table MarcaAuto;

alter table Auto alter column motor decimal(2,1);