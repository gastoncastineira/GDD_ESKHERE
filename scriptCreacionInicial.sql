USE [GD2C2018]
GO

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'ESKHERE')
BEGIN
EXEC ('CREATE SCHEMA [ESKHERE] AUTHORIZATION [gdEspectaculos2018]')
END


--------------------------------------ABM ROL------------------------------------------------------

CREATE TABLE ESKHERE.[Rol](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] [nvarchar](50) NOT NULL UNIQUE,
	[Habilitado] [bit] NOT NULL
);	

CREATE TABLE ESKHERE.[Funcion](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](255) NOT NULL
);

CREATE TABLE ESKHERE.[Rol_X_Funcion](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ID_Rol] [int],
	[ID_Funcion] [int],
	CONSTRAINT FK_Rol FOREIGN KEY (ID_Rol) REFERENCES ESKHERE.[Rol](ID),
	CONSTRAINT FK_Funcion FOREIGN KEY (ID_Funcion) REFERENCES ESKHERE.[Funcion](ID)
);


CREATE TABLE ESKHERE.[Publicacion_Estado](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar](255) NULL,
	[puedeModificarse] [int] NOT NULL
);

CREATE TABLE ESKHERE.[Publicacion_Grado](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar](255) NULL,
	[Comision] int
	);

CREATE TABLE ESKHERE.[Usuario](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Usuario] [nvarchar](50) NOT NULL UNIQUE,
	[Contrasenia] [nvarchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
);


--Tenemos acá un acumulador de ptos y en compras tenemos los ptos indivIDuales de c/u
--¿Dejams los 2 o solo 1?
CREATE TABLE ESKHERE.[Cliente](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Puntos] [Int],
	[Cli_Dni] [numeric](18, 0) NULL UNIQUE,
	[Cuil] [nvarchar](13) NULL UNIQUE,
	[Tipo_Doc] [nvarchar](15) NULL,
	[Cli_ApellIDo] [nvarchar](255) NULL,
	[Cli_Nombre] [nvarchar](255) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Mail] [nvarchar](255) NULL,
	Calle [nvarchar](255) NULL,
	Numero numeric(18, 0) NULL,
	Piso numeric(18, 0) NULL,
	Depto [nvarchar](255) NULL,
	Cod_Postal [nvarchar](50) NULL,
	localidad [nvarchar](255) NULL,
	[fecha_creacion] [datetime] NULL,
	ID_Usuario INT	NOT NULL,
	CONSTRAINT FK_Usuario FOREIGN KEY (ID_Usuario) REFERENCES ESKHERE. Usuario(ID)
);

CREATE TABLE ESKHERE.[Puntos](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	Cant INT,
	Habilitados BIT,
	FechaObtenIDos DATETIME
);


CREATE TABLE ESKHERE.[Empresa](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Espec_Empresa_Razon_Social] [nvarchar](255) NULL UNIQUE,
	[Espec_Empresa_Cuit] [nvarchar](255) NULL UNIQUE,
	[Espec_Empresa_Fecha_Creacion] [datetime] NULL,
	[Espec_Empresa_Mail] [nvarchar](50) NULL,
	Calle nvarchar(50) NULL,
	Numero numeric(18, 0) NULL,
	Piso numeric(18, 0) NULL,
	Depto nvarchar(50) NULL,
	Cod_Postal [nvarchar](50) NULL,
	Habilitado BIT NOT NULL,
	ID_Usuario INT NOT NULL,
	CONSTRAINT FK_UsuarioEmpresa FOREIGN KEY (ID_Usuario) REFERENCES ESKHERE. Usuario(ID)
);


CREATE TABLE ESKHERE.Publicacion_Fechas(
[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
FPublicacion DATETIME NOT NULL,
FFuncion DATETIME NOT NULL,
FVenc DATETIME NOT NULL,
);

CREATE TABLE ESKHERE.[Publicacion](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Codigo] [numeric](18, 0) NULL,
	[Descripcion] [nvarchar](255) NULL, 
	[Publicacion_Rubro] [nvarchar](255) NULL, 
	[Stock] [int] NULL ,
	[ID_Empresa_publicante] INT NOT NULL,
	[ID_Fecha] INT NOT NULL,
	[ID_grado] [int] NOT NULL DEFAULT 3,
	[ID_estado] [int] NOT NULL,
	CONSTRAINT FK_Empresa_Publicante FOREIGN KEY([ID_Empresa_publicante]) REFERENCES ESKHERE.Empresa(ID),
	CONSTRAINT FK_Fecha FOREIGN KEY(ID_Fecha) REFERENCES ESKHERE.Publicacion_Fechas(ID),
	CONSTRAINT FK_grado FOREIGN KEY(ID_grado) REFERENCES ESKHERE.Publicacion_Grado(ID),
	CONSTRAINT FK_estado FOREIGN KEY(ID_estado) REFERENCES ESKHERE.Publicacion_Estado(ID)
);


--Un cliente tiene muchas compras y un espectáculo tiene muchas compras
--La compra es para los clientes

CREATE TABLE ESKHERE.[Ubicacion](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ubicacion_Fila] [varchar](3) NULL,
	[ubicacion_Asiento] [numeric](18, 0) NULL,
	[tipo] [numeric](18, 0) NULL,
	[precio] [numeric](18, 0) NULL,
	[Ubicacion_Sin_numerar] [bit] NULL,
	[Ubicacion_Tipo_Descripcion] [nvarchar](255) NULL,
	puntos int,
	ID_Publicacion int,
	CONSTRAINT FK_Ubicacion_Publicacion FOREIGN KEY (ID_Publicacion) REFERENCES ESKHERE.PUBLICACION(ID)
);
CREATE TABLE [ESKHERE].Compra(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Fecha] [datetime] NULL,
	[Compra_Cantidad] [numeric](18, 0) NULL,
	[Forma_Pago_Desc] [nvarchar](255) NULL,
	ID_Cliente INT NOT NULL,
	ID_Ubicacion INT NOT NULL,
	CONSTRAINT FK_Compra_Cliente FOREIGN KEY (ID_Cliente) REFERENCES ESKHERE.Cliente(ID),
	CONSTRAINT FK_Compra_Ubicacion FOREIGN KEY (ID_Ubicacion) REFERENCES ESKHERE.Ubicacion(ID)
);

--La factura es para las "empresas"
--FuncionalIDad utilizada que registra facturas por el cobro de comisiones de ventas
--de publicaciones a la empresa de espectáculos.
--La comision la obtiene de: Compra -> Publicacion ->Grado Publicacion
CREATE TABLE ESKHERE.[Factura](
	[Factura_Nro] [numeric](18, 0) PRIMARY KEY,
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	Total_Comisiones [numeric](18, 2) NULL,
	Cantidad_Item_Factura INT,
	ID_Empresa [nvarchar](255) NULL,
	CONSTRAINT FK_Factura_Empresa  FOREIGN KEY(ID_Empresa) REFERENCES ESKHERE.Empresa([Espec_Empresa_Cuit])	
);

CREATE TABLE [ESKHERE].[Item_Factura](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Item_Factura_Monto] [numeric](18, 2) NULL,
	[Item_Factura_Cantidad] [numeric](18, 0) NULL,
	[Item_Factura_Descripcion] [nvarchar](60) NULL,
	ID_Factura [numeric](18, 0) NOT NULL,
	ID_Compra INT NOT NULL,
	CONSTRAINT FK_Factura  FOREIGN KEY(ID_Factura) REFERENCES ESKHERE.[Factura]([Factura_Nro]),
	CONSTRAINT FK_ITF_Compra  FOREIGN KEY(ID_Compra) REFERENCES ESKHERE.Compra(ID)	
);


CREATE TABLE ESKHERE.[Rol_X_Usuario](
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  	ID_ROL int NOT NULL,
  	ID_Usuario int NOT NULL,
  	CONSTRAINT FK_Rol_X_Usuario FOREIGN KEY (ID_Rol) REFERENCES ESKHERE. Rol(ID),
	CONSTRAINT FK_Usuario_X_Rol FOREIGN KEY(ID_Usuario) REFERENCES ESKHERE. Usuario(ID)
);


CREATE TABLE ESKHERE.Premios(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Puntos] [numeric](18, 2) NULL,
	[Descripcion] [nvarchar](255) NULL,
);

CREATE TABLE ESKHERE.cliente_premio(
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ID_premio] [int] NOT NULL,
	[ID_cliente] [int] NOT NULL,
	CONSTRAINT FK_ClientePremio   FOREIGN KEY(ID_Cliente) REFERENCES ESKHERE. Cliente(ID),	
	CONSTRAINT FK_premio  FOREIGN KEY(ID_premio) REFERENCES ESKHERE. Premios(ID)	
);

--------------------------------------------------------------------------- INSERTS DE VALORES GENERICOS ------------------------------------------------------------------------------------------------

INSERT INTO [ESKHERE].[Usuario]([Usuario],[Contrasenia],habilitado) 
VALUES ('1234',HASHBYTES('SHA2_256','1234'),1)


INSERT INTO [ESKHERE].[Publicacion_Estado] ([Descripcion],[puedeModificarse])
VALUES ('Borrador',1),('Publicada',1),('Finalizada',1)

INSERT INTO [ESKHERE].[Premios] ([Puntos],[Descripcion]) 
VALUES (10, 'Encendedor'), (20, 'Juguete'), (100, 'Entrada'), (500, 'Peluche')

INSERT INTO [ESKHERE].[Publicacion_Grado]([Descripcion],[Comision])
VALUES ('ALTA', 0.10), ('MEDIA', 0.05), ('BAJA', 0.01)


INSERT INTO [ESKHERE].[Rol] ([Nombre],[Habilitado])
VALUES ('Empresa',1),('Administrativo',1),('Cliente',1)

INSERT INTO [ESKHERE].Funcion([Nombre],descripcion)
VALUES ('ContabilIDad','dificil'),('Limpieza','medio'),('Mantenimiento','facil'),('Ventas','facil')


INSERT INTO [ESKHERE].[Rol_X_Funcion]   ([ID_ROL],ID_Funcion)
VALUES (1,2),(2,3),(2,2),(2,1)

INSERT INTO [ESKHERE].[Rol_X_Usuario] ([ID_ROL],[ID_Usuario])
VALUES (1,1),(2,1),(3,1)

------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO [ESKHERE].[Publicacion_Fechas] --Revisar, en realIDad deberia insertarse SOLO 1 vez una fila con esos valores, despues no debería repetirse
           ([FPublicacion],[FFuncion],[FVenc])
SELECT  DISTINCT [Espec_Empresa_Fecha_Creacion],[Espectaculo_Fecha],[Espectaculo_Fecha_Venc]
FROM gd_esquema.Maestra


 INSERT INTO [ESKHERE].[Cliente]
          ([Cli_Dni],[Cuil], [Cli_ApellIDo],[Cli_Nombre],[Cli_Fecha_Nac],[Cli_Mail],[Calle],[Numero]
           ,[Piso],[Depto],[Cod_Postal], [ID_Usuario])
select  distinct([Cli_Dni]),[Cli_Dni]+1,[Cli_ApeliIDo],[Cli_Nombre],[Cli_Fecha_Nac],[Cli_Mail],[Cli_Dom_Calle],[Cli_Nro_Calle]
      ,[Cli_Piso],[Cli_Depto],[Cli_Cod_Postal], 1
from gd_esquema.Maestra
where [Cli_Dni]  IS NOT NULL


INSERT INTO [ESKHERE].[Empresa] 
([Espec_Empresa_Razon_Social],[Espec_Empresa_Cuit],[Espec_Empresa_Fecha_Creacion],[Espec_Empresa_Mail],[ID_Usuario],[Calle],[Numero],[Piso],[Depto],[Cod_Postal],Habilitado)
SELECT DISTINCT([Espec_Empresa_Razon_Social]), [Espec_Empresa_Cuit],[Espec_Empresa_Fecha_Creacion],[Espec_Empresa_Mail],1,[Espec_Empresa_Dom_Calle],[Espec_Empresa_Nro_Calle]
      ,[Espec_Empresa_Piso],[Espec_Empresa_Depto],[Espec_Empresa_Cod_Postal],1
FROM gd_esquema.Maestra
WHERE [Espec_Empresa_Cuit]  IS NOT NULL 

INSERT INTO [ESKHERE].[Publicacion]
 --NO tiene sentido que este ID_Grado xq no esta en el script original para migrar
           ([Codigo],[Descripcion],[Publicacion_Rubro],[ID_Empresa_publicante],[ID_Fecha],[ID_estado])
SELECT DISTINCT [Espectaculo_Cod],[Espectaculo_Descripcion],[Espectaculo_Rubro_Descripcion],
(SELECT TOP 1 ID FROM [ESKHERE].Empresa Emp WHERE emp.Espec_Empresa_Razon_Social = [Espec_Empresa_Razon_Social] AND emp.Espec_Empresa_Cuit = [Espec_Empresa_Cuit]),--Me quedo tranqui xq la razon social y cuit son unicos
(SELECT TOP 1 ID FROM [ESKHERE].Publicacion_Fechas  PF WHERE PF.FPublicacion = [Espec_Empresa_Fecha_Creacion] AND PF.FFuncion =[Espectaculo_Fecha] AND PF.FVenc =[Espectaculo_Fecha_Venc] ),
(SELECT ID FROM [ESKHERE].[Publicacion_Estado]WHERE [Descripcion]=[Espectaculo_Estado])
FROM gd_esquema.Maestra  Maestra

INSERT INTO [ESKHERE].[Ubicacion]
           ([ubicacion_Fila],[ubicacion_Asiento],[tipo],[precio],[Ubicacion_Sin_numerar],[Ubicacion_Tipo_Descripcion],[puntos],[ID_Publicacion])
SELECT  DISTINCT [ubicacion_Fila],[Ubicacion_Asiento],[Ubicacion_Tipo_Codigo],[Ubicacion_Precio],[Ubicacion_Sin_numerar], [Ubicacion_Tipo_Descripcion], FLOOR([Ubicacion_Precio]/10),
(SELECT TOP 1 ID FROM ESKHERE.Publicacion P WHERE
												 P.Codigo = M.Espectaculo_Cod AND 
												 P.Descripcion = M.Espectaculo_Descripcion AND
												  P.Publicacion_Rubro = M.Espectaculo_Rubro_Descripcion AND
												  P.[ID_Empresa_publicante] = (SELECT TOP 1 ID FROM [ESKHERE].Empresa Emp WHERE emp.Espec_Empresa_Razon_Social = [Espec_Empresa_Razon_Social] AND emp.Espec_Empresa_Cuit = [Espec_Empresa_Cuit]) AND
												  P.[ID_Fecha] = (SELECT TOP 1 ID FROM [ESKHERE].Publicacion_Fechas  PF WHERE PF.FPublicacion = [Espec_Empresa_Fecha_Creacion] AND PF.FFuncion =[Espectaculo_Fecha] AND PF.FVenc =[Espectaculo_Fecha_Venc] ) AND
												  p.[ID_estado] = (SELECT ID FROM [ESKHERE].[Publicacion_Estado]WHERE [Descripcion]=[Espectaculo_Estado])
												)

FROM gd_esquema.Maestra M

INSERT INTO [ESKHERE].[Compra]  ([Fecha],[Compra_Cantidad],[Forma_Pago_Desc],[ID_Ubicacion],[ID_Cliente])
select distinct [Compra_Fecha],[Compra_Cantidad],[Forma_Pago_Desc], 
--Tiene quilombo para encontrar el ID_Ubicacion
(SELECT ID FROM ESKHERE.Ubicacion Ubi WHERE ubi.[ubicacion_Fila] =M.[ubicacion_Fila]	   AND
									 ubi.[Ubicacion_Asiento] = M.[Ubicacion_Asiento]  AND
									 ubi.[tipo]	       =M.[Ubicacion_Tipo_Codigo] AND
									  ubi.[precio]		       =M.[Ubicacion_Precio] AND
									 ubi.[Ubicacion_Sin_numerar] = M.[Ubicacion_Sin_numerar] AND 
									 ubi.[Ubicacion_Tipo_Descripcion] =M.[Ubicacion_Tipo_Descripcion]AND 
									ubi.ID_Publicacion = (SELECT TOP 1 ID FROM ESKHERE.Publicacion P WHERE
												 P.Codigo = M.Espectaculo_Cod AND 
												 P.Descripcion = M.Espectaculo_Descripcion AND
												  P.Publicacion_Rubro = M.Espectaculo_Rubro_Descripcion AND
												  P.[ID_Empresa_publicante] = (SELECT TOP 1 ID FROM [ESKHERE].Empresa Emp WHERE emp.Espec_Empresa_Razon_Social = [Espec_Empresa_Razon_Social] AND emp.Espec_Empresa_Cuit = [Espec_Empresa_Cuit]) AND
												  P.[ID_Fecha] = (SELECT TOP 1 ID FROM [ESKHERE].Publicacion_Fechas  PF WHERE PF.FPublicacion = [Espec_Empresa_Fecha_Creacion] AND PF.FFuncion =[Espectaculo_Fecha] AND PF.FVenc =[Espectaculo_Fecha_Venc] ) AND
												  p.[ID_estado] = (SELECT ID FROM [ESKHERE].[Publicacion_Estado]WHERE [Descripcion]=[Espectaculo_Estado])	
										)--Cierre SELECT de ID_Publicacion
),
(SELECT TOP 1 ID FROM ESKHERE.Cliente Cli WHERE
	  M.[Cli_Dni]=      Cli.[Cli_Dni] AND
	  M.[Cli_Apeliido]=    Cli.[Cli_ApellIDo] AND
      M.[Cli_Nombre]= Cli.[Cli_Nombre] AND
      M.[Cli_Fecha_Nac]= Cli.[Cli_Fecha_Nac] AND
      M.[Cli_Mail]= Cli.[Cli_Mail] AND
      M.[Cli_Dom_Calle]= Cli.[Calle] AND
      M.[Cli_Nro_Calle]= Cli.[Numero] AND
      M.[Cli_Piso]= Cli.[Piso] AND
      M.[Cli_Depto]= Cli.[Depto] AND
      M.[Cli_Cod_Postal]= Cli.[Cod_Postal])--Aca termina el select del ID_Cliente
FROM gd_esquema.Maestra M
WHERE [Compra_Cantidad] is not null AND [Compra_Fecha] is not null AND [Forma_Pago_Desc] is not null
/*
JOIN [ESKHERE].Cliente Cli ON  (
	  Maestra.[Cli_Dni]=      Cli.[Cli_Dni] AND
	  Maestra.[Cli_Apeliido]=    Cli.[Cli_ApellIDo] AND
      Maestra.[Cli_Nombre]= Cli.[Cli_Nombre] AND
      Maestra.[Cli_Fecha_Nac]= Cli.[Cli_Fecha_Nac] AND
      Maestra.[Cli_Mail]= Cli.[Cli_Mail] AND
      Maestra.[Cli_Dom_Calle]= Cli.[Calle] AND
      Maestra.[Cli_Nro_Calle]= Cli.[Numero] AND
      Maestra.[Cli_Piso]= Cli.[Piso] AND
      Maestra.[Cli_Depto]= Cli.[Depto] AND
      Maestra.[Cli_Cod_Postal]= Cli.[Cod_Postal] )--De aca me aseguro el cliente

	  */




/* UNA POSIBLE FORMA DE HACERLO
INSERT INTO [ESKHERE].[Compra]  ([Fecha],[Compra_Cantidad],[Forma_Pago_Desc],[ID_Ubicacion],[ID_Cliente])
select distinct [Compra_Fecha],[Compra_Cantidad],[Forma_Pago_Desc], ubi.ID, Cli.ID
FROM [ESKHERE].[Ubicacion] ubi 
JOIN gd_esquema.Maestra Maestra ON ( Maestra.[ubicacion_Fila] = ubi.[ubicacion_Fila]	   AND
									 Maestra.[Ubicacion_Asiento] = ubi.[Ubicacion_Asiento] AND
									 Maestra.[Ubicacion_Tipo_Codigo]= ubi.[tipo]	       AND
									 Maestra.[Ubicacion_Precio] = ubi.[precio]		       AND
									 Maestra.[Ubicacion_Tipo_Descripcion] = ubi.[Ubicacion_Tipo_Descripcion])
JOIN [ESKHERE].Cliente Cli ON  (
	  Maestra.[Cli_Dni]=      Cli.[Cli_Dni] AND
	  Maestra.[Cli_Apeliido]=    Cli.[Cli_ApellIDo] AND
      Maestra.[Cli_Nombre]= Cli.[Cli_Nombre] AND
      Maestra.[Cli_Fecha_Nac]= Cli.[Cli_Fecha_Nac] AND
      Maestra.[Cli_Mail]= Cli.[Cli_Mail] AND
      Maestra.[Cli_Dom_Calle]= Cli.[Calle] AND
      Maestra.[Cli_Nro_Calle]= Cli.[Numero] AND
      Maestra.[Cli_Piso]= Cli.[Piso] AND
      Maestra.[Cli_Depto]= Cli.[Depto] AND
      Maestra.[Cli_Cod_Postal]= Cli.[Cod_Postal] )--De aca me aseguro el cliente

*/

INSERT INTO [ESKHERE].[Factura]
           ([Factura_Nro],[Factura_Fecha],[Factura_Total],Total_Comisiones,	[Cantidad_Item_Factura], ID_Empresa)
SELECT Distinct([Factura_Nro]),[Factura_Fecha],[Factura_Total], 
(SELECT SUM([Item_Factura_Monto])FROM ESKHERE.Item_Factura ITF JOIN gd_esquema.Maestra  M ON (ITF.ID_Factura = M.Factura_Nro),
(SELECT COUNT(*) FROM ESKHERE.Item_Factura ITF JOIN gd_esquema.Maestra  M ON (ITF.ID_Factura = M.Factura_Nro),--Cuento la CANT de item_Facturas relacionadas con este factura_nro
(SELECT TOP 1 ID FROM [ESKHERE].Empresa Emp WHERE emp.Espec_Empresa_Razon_Social = [Espec_Empresa_Razon_Social] AND emp.Espec_Empresa_Cuit = [Espec_Empresa_Cuit])
 FROM gd_esquema.Maestra 
WHERE [Factura_Nro] IS NOT NULL
 

--¿Como resuelvo la logica de asignacion puntos respecto a una compra? se lo doy a las ubicaciones y abz

INSERT INTO [ESKHERE].[Item_Factura]
           ([Item_Factura_Monto],[Item_Factura_Cantidad],[Item_Factura_Descripcion],[ID_Factura],[ID_Compra])
SELECT [Item_Factura_Monto],[Item_Factura_Cantidad], [Item_Factura_Descripcion],
(SELECT ID FROM gd_esquema.Maestra ),--¿Como resuelvo el ID_Factura?
( SELECT TOP 1 ID FROM eskhere.Compra C JOIN gd_esquema.Maestra M ON ( ( C.[Fecha] = M.Compra_Fecha) AND
																 ( C.Compra_Cantidad = M.Compra_Cantidad) AND
																 ( C.Forma_Pago_Desc = M.Forma_Pago_Desc) AND

from gd_esquema.Maestra
where [Item_Factura_Monto]  IS NOT NULL


-----------------------------------------------------------   INSERTS PARA TABLAS INTERMEDIAS  ------------------------------------------------------------------------------------------------
-- 1)Las tablas que merecen migracion son las del scema maestra

-- 2)MUCHO MUY IMPORTANTE, PARA EL INSERT DE LAS INTERMEDIAS HAY QUE PONER TODOS LOS CAMPOS DE LAS TABLAS PPALES LO QUE VA A PERMITIR DIFERENCIAR UN REGISTRO DE OTRO.
--   +DE NO PONER TODOS SE PUEDEN DAR REGRISTROS QUE SE REPITAN!!!!


select count(*) from 	[ESKHERE]. Ubicacion							 
select count(*) from 	[ESKHERE].Item_Factura


	

 