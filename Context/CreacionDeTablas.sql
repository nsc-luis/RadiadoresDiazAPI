use RadiadoresDiaz;

create table productos (
	idProducto int not null identity(1,1),
	nombreProducto varchar(max) not null,
	precioNuevoSuelto decimal not null default 0.00,
	precioNuevoInstalado decimal not null default 0.00,
	precioReparadoSuelto decimal not null default 0.00,
	precioReparadoInstalado decimal not null default 0.00,
	costoProveedor decimal not null default 0.00,
	idTipoProducto int not null,
	noParte varchar(max) not null,
	material varchar(max),
	observaciones varchar(max),
	idProveedor int not null,
	existencia int not null default 0,
	registro datetime  not null default GETDATE()
)

create table tipoProducto (
	idTipoProducto int not null identity(1,1),
	nombreTipoProducto varchar(max) not null
)

create table marcas (
	idMarca int not null identity(1,1),
	nombreMarca varchar(max) not null,
	registro datetime  not null default GETDATE()
)

create table autos (
	idAuto int not null identity(1,1),
	idMarca int not null,
	modelo varchar(max) not null,
	year int not null,
	motor varchar(max),
	registro datetime  not null default GETDATE()
)

create table marca_auto(
	idMarcaAuto int not null identity(1,1),
	idAuto int not null,
	idMarca int not null
)

create table proveedores (
	idProveedor int not null identity(1,1),
	nombreProveedor varchar(max) not null
)
	
create table autos_producto(
	idAutoProducto int not null identity(1,1),
	idAuto int not null,
	idProducto int not null
)

