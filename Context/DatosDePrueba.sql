-- Insertar registros en la tabla 'marcas'
use [RadiadoresDiaz];
INSERT INTO marcas (nombreMarca)
VALUES ('Toyota');

INSERT INTO marcas (nombreMarca)
VALUES ('Honda');

-- Insertar registros en la tabla 'autos'
INSERT INTO autos (idMarca, modelo, year, motor)
VALUES (1, 'Camry', 2022, '2.5L');

INSERT INTO autos (idMarca, modelo, year, motor)
VALUES (1, 'Corolla', 2023, '1.8L');

INSERT INTO autos (idMarca, modelo, year, motor)
VALUES (2, 'Civic', 2022, '2.0L');

-- Insertar registros en la tabla 'marca_auto'
INSERT INTO marca_auto (idAuto, idMarca)
VALUES (1, 1);

INSERT INTO marca_auto (idAuto, idMarca)
VALUES (2, 1);

INSERT INTO marca_auto (idAuto, idMarca)
VALUES (3, 2);

-- Insertar registros en la tabla 'proveedores'
INSERT INTO proveedores (nombreProveedor)
VALUES ('Proveedor A');

INSERT INTO proveedores (nombreProveedor)
VALUES ('Proveedor B');

-- Insertar registros en la tabla 'productos'
INSERT INTO productos (nombreProducto, precioNuevoSuelto, precioNuevoInstalado, precioReparadoSuelto, precioReparadoInstalado, costoProveedor, idTipoProducto, noParte, material, observaciones, idProveedor)
VALUES ('Filtro de aire', 15.00, 30.00, 10.00, 25.00, 12.00, 1, 'FA-123', 'Plástico', 'Filtro de aire para automóviles', 1);

INSERT INTO productos (nombreProducto, precioNuevoSuelto, precioNuevoInstalado, precioReparadoSuelto, precioReparadoInstalado, costoProveedor, idTipoProducto, noParte, material, observaciones, idProveedor)
VALUES ('Pastillas de freno', 20.00, 45.00, 15.00, 35.00, 18.00, 2, 'PF-456', 'Metal', 'Pastillas de freno de alta calidad', 2);

-- Insertar registros en la tabla 'autos_producto' (asociar productos a autos)
INSERT INTO autos_producto (idAuto, idProducto)
VALUES (1, 1);

INSERT INTO autos_producto (idAuto, idProducto)
VALUES (2, 2);

INSERT INTO [dbo].[tipoProducto]
           ([nombreTipoProducto])
     VALUES
           ('RADIADORES'),
		   ('TAPAS'),
		   ('VENTILADORES'),
		   ('ACCESORIOS')
GO
