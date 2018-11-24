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
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] [nvarchar](50) NOT NULL UNIQUE,
	[Habilitado] [bit] NOT NULL
);	

CREATE TABLE ESKHERE.[Funcion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](255) NOT NULL
);

CREATE TABLE ESKHERE.[Rol_X_Funcion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Id_Rol] [int],
	[Id_Funcion] [int],
	CONSTRAINT FK_Rol FOREIGN KEY (Id_Rol) REFERENCES ESKHERE.[Rol](Id),
	CONSTRAINT FK_Funcion FOREIGN KEY (Id_Funcion) REFERENCES ESKHERE.[Funcion](Id)
);


CREATE TABLE ESKHERE.[Publicacion_Estado](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar](20) NOT NULL,
	[puedeModificarse] [int] NOT NULL
);

CREATE TABLE ESKHERE.[Publicacion_Grado](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar] (5),
	[Comision] int
	);

CREATE TABLE ESKHERE.[Usuario](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Usuario] [nvarchar](50) NOT NULL UNIQUE,
	[Contrasenia] [nvarchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
);


--Tenemos acá un acumulador de ptos y en compras tenemos los ptos individuales de c/u
--¿Dejams los 2 o solo 1?
CREATE TABLE ESKHERE.[Cliente](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Puntos] [Int],
	[Cli_Dni] [numeric](18, 0) NULL UNIQUE,
	[Cuil] [nvarchar](13) NULL UNIQUE,
	[Tipo_Doc] [nvarchar](15) NULL,
	[Cli_Apellido] [nvarchar](255) NULL,
	[Cli_Nombre] [nvarchar](255) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Mail] [nvarchar](255) NULL,
	Calle nvarchar(50) NULL,
	Numero numeric(18, 0) NULL,
	Piso numeric(18, 0) NULL,
	Depto nvarchar(50) NULL,
	Cod_Postal [nvarchar](50) NULL,
	localidad nvarchar(50),
	[fecha_creacion] [datetime] NULL,
	ID_Usuario INT	NOT NULL,
	CONSTRAINT FK_Usuario FOREIGN KEY (ID_Usuario) REFERENCES ESKHERE. Usuario(ID)
	--[tarjeta] tal vez otra tabla
);
--La factura es para las "empresas"
--Funcionalidad utilizada que registra facturas por el cobro de comisiones de ventas
--de publicaciones a la empresa de espectáculos.
--La comision la obtiene de: Compra -> Publicacion ->Grado Publicacion
CREATE TABLE ESKHERE.[Factura](
	[Factura_Nro] [numeric](18, 0) PRIMARY KEY,
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	[Forma_Pago_Desc] [nvarchar](255) NULL,
);


--Un cliente tiene muchas compras y un espectáculo tiene muchas compras
--La compra es para los clientes
CREATE TABLE [ESKHERE].[Compra](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Compra_Fecha] [datetime] NULL,
	descripcion nvarchar(255) null,
	[Total] [numeric](18, 0) NULL,
	ID_Cliente [numeric](18, 0) NOT NULL,
	Id_Factura [numeric](18, 0) NOT NULL,
	CONSTRAINT FK_Cliente   FOREIGN KEY(Id_Cliente) REFERENCES ESKHERE. Cliente([Cli_Dni]),	
	CONSTRAINT FK_Factura  FOREIGN KEY(Id_Factura) REFERENCES ESKHERE.[Factura]([Factura_Nro])	
);


CREATE TABLE ESKHERE.[Ubicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ubicacion_Fila] char(1),
	[ubicacion_Asiento] [INT],
	[tipo] nvarchar(40),
	[precio] [INT],
	[descripcion] nvarchar(255),
	puntos int,
);

CREATE TABLE ESKHERE.Publicacion_Fechas(
[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
FPublicacion DATETIME NOT NULL,
FFuncion DATETIME NOT NULL,
FVenc DATETIME NOT NULL,
);

CREATE TABLE ESKHERE.[Publicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Codigo] [numeric](18, 0) NULL,
	[Descripcion] [nvarchar](255) NULL, 
	[Publicacion_Rubro] [nvarchar](255) NULL, 
	[Stock] [int] NULL,
	[Id_Fecha] INT NOT NULL,
	[Id_grado] [int] NOT NULL,
	[Id_estado] [int] NOT NULL,
	Id_Ubicacion [int] NOT NULL,
	CONSTRAINT FK_Fecha FOREIGN KEY(Id_Fecha) REFERENCES ESKHERE.Publicacion_Fechas(Id),
	CONSTRAINT FK_grado FOREIGN KEY(Id_grado) REFERENCES ESKHERE.Publicacion_Grado(Id),
	CONSTRAINT FK_UbicacionPublicacion FOREIGN KEY(Id_Ubicacion) REFERENCES ESKHERE.[Ubicacion](Id),
	CONSTRAINT FK_estado FOREIGN KEY(Id_estado) REFERENCES ESKHERE.Publicacion_Estado(Id)
);


CREATE TABLE ESKHERE.[Rol_X_Usuario](
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  	ID_ROL int NOT NULL,
  	ID_Usuario int NOT NULL,
  	CONSTRAINT FK_Rol_X_Usuario FOREIGN KEY (ID_Rol) REFERENCES ESKHERE. Rol(Id),
	CONSTRAINT FK_Usuario_X_Rol FOREIGN KEY(ID_Usuario) REFERENCES ESKHERE. Usuario(Id)
);



CREATE TABLE ESKHERE.[Empresa](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Espec_Empresa_Razon_Social] [nvarchar](255) NULL UNIQUE,
	[Espec_Empresa_Cuit] [nvarchar](255) NULL UNIQUE,
	[Espec_Empresa_Fecha_Creacion] [datetime] NULL,
	[Espec_Empresa_Mail] [nvarchar](50) NULL,
	ID_Usuario INT NOT NULL,
	Calle nvarchar(50) NULL,
	Numero numeric(18, 0) NULL,
	Piso numeric(18, 0) NULL,
	Depto nvarchar(50) NULL,
	Cod_Postal [nvarchar](50) NULL,
	Habilitado BIT NOT NULL,
	CONSTRAINT FK_UsuarioEmpresa FOREIGN KEY (ID_Usuario) REFERENCES ESKHERE. Usuario(Id),
);

CREATE TABLE ESKHERE.[Ubicacion_Compra](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ID_ubicacion] [INT],
	[ID_Compra] [INT],
	CONSTRAINT FK_ubicacionCompra FOREIGN KEY (ID_ubicacion) REFERENCES ESKHERE.Ubicacion(Id),
	CONSTRAINT FK_CompraUbicacion FOREIGN KEY (ID_Compra) REFERENCES ESKHERE.Compra(Id)
);


---------------------------------------------------------------------------------------------------


CREATE TABLE ESKHERE.Premios(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Puntos] [numeric](18, 2) NULL,
	[Descripcion] [nvarchar](255) NULL,
);

CREATE TABLE ESKHERE.cliente_premio(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Id_premio] [int] NOT NULL,
	[Id_cliente] [int] NOT NULL,
	CONSTRAINT FK_ClientePremio   FOREIGN KEY(Id_Cliente) REFERENCES ESKHERE. Cliente(Id),	
	CONSTRAINT FK_premio  FOREIGN KEY(Id_premio) REFERENCES ESKHERE. Premios(Id)	
);

--------------------------------------------------------------------------- INSERTS DE VALORES GENERICOS ------------------------------------------------------------------------------------------------

INSERT INTO [ESKHERE].[Usuario]([Usuario],[Contrasenia],habilitado) 
VALUES ('1234','1234',1)


INSERT INTO [ESKHERE].[Premios] ([Puntos],[Descripcion]) 
VALUES (10, 'Encendedor'), (20, 'Juguete'), (100, 'Entrada'), (500, 'Peluche')


INSERT INTO [ESKHERE].[Rol] ([Nombre],[Habilitado])
VALUES ('Empresa',1),('Administrativo',1),('Cliente',1)


INSERT INTO [ESKHERE].[Publicacion_Grado]([Descripcion],[Comision])
VALUES ('ALTA', 0.10), ('MEDIA', 0.05), ('BAJA', 0.01)


INSERT INTO [ESKHERE].[Publicacion_Estado] ([Descripcion],[puedeModificarse])
VALUES ('Borrador',1),('Publicada',1),('Finalizada',1)
------------------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO [ESKHERE].[Ubicacion] 
           ([ubicacion_Fila],[Ubicacion_Asiento],[tipo],[precio], [descripcion])
SELECT  [ubicacion_Fila],[Ubicacion_Asiento],[Ubicacion_Tipo_Codigo],[Ubicacion_Precio], [Ubicacion_Tipo_Descripcion]
FROM gd_esquema.Maestra


INSERT INTO [ESKHERE].[Publicacion] --¿Como mierda les relaciono los id? Deberian salir xq todos tienen inserts genericos
           ([Codigo],[Descripcion],[Fecha_publicacion],[Fecha_funcion],[Fecha_venc],[Id_rubro] ,[Id_estado], Id_Ubicacion)
SELECT  [Espectaculo_Cod],[Espectaculo_Descripcion],[Espec_Empresa_Fecha_Creacion],[Espectaculo_Fecha],[Espectaculo_Fecha_Venc],
(SELECT Id FROM [ESKHERE].Rubro WHERE Descripcion = [Espectaculo_Rubro_Descripcion]),
(SELECT Id FROM [ESKHERE].[Publicacion_Estado]WHERE [Descripcion]=[Espectaculo_Estado]),--Grado parece que no tiene
(SELECT Id FROM  [ESKHERE].Ubicacion WHERE ubicacion_Fila = Maestra.ubicacion_Fila AND [Ubicacion_Asiento]=Maestra.[Ubicacion_Asiento] )
FROM gd_esquema.Maestra  Maestra
/* (SELECT Id FROM [ESKHERE].[Publicacion_Estado]WHERE [Descripcion]=[Espectaculo_Estado]) */


INSERT INTO [ESKHERE].[Factura]--ACA me marca que el nhay numero de factura que se repiten!!, sin embargo la fecha, el total y forma de pago es la misma asi que no hay drama
           ([Factura_Nro],[Factura_Fecha],[Factura_Total],[Forma_Pago_Desc])
SELECT Distinct([Factura_Nro]),[Factura_Fecha],[Factura_Total],[Forma_Pago_Desc]
 FROM gd_esquema.Maestra
WHERE [Factura_Nro] IS NOT NULL
 

 INSERT INTO [ESKHERE].[Rubro] ([Descripcion]) -- Query a checkear
 SELECT  [Espectaculo_Rubro_Descripcion]
 FROM gd_esquema.Maestra WHERE [Espectaculo_Rubro_Descripcion] is not null


 INSERT INTO [ESKHERE].[Cliente]
          ([Cli_Dni],[Cuil], [Cli_Apellido],[Cli_Nombre],[Cli_Fecha_Nac],[Cli_Mail],[Calle],[Numero]
           ,[Piso],[Depto],[Cod_Postal], [ID_Usuario])
select  distinct([Cli_Dni]),[Cli_Dni]+1,[Cli_Apeliido],[Cli_Nombre],[Cli_Fecha_Nac],[Cli_Mail],[Cli_Dom_Calle],[Cli_Nro_Calle]
      ,[Cli_Piso],[Cli_Depto],[Cli_Cod_Postal], 1
from gd_esquema.Maestra
where [Cli_Dni]  IS NOT NULL

INSERT INTO [ESKHERE].[Empresa] 
([Espec_Empresa_Razon_Social],[Espec_Empresa_Cuit],[Espec_Empresa_Fecha_Creacion],[Espec_Empresa_Mail],[ID_Usuario],[Calle],[Numero],[Piso],[Depto],[Cod_Postal],Habilitado)
SELECT DISTINCT([Espec_Empresa_Razon_Social]), [Espec_Empresa_Cuit],[Espec_Empresa_Fecha_Creacion],[Espec_Empresa_Mail],1,[Espec_Empresa_Dom_Calle],[Espec_Empresa_Nro_Calle]
      ,[Espec_Empresa_Piso],[Espec_Empresa_Depto],[Espec_Empresa_Cod_Postal],1
FROM gd_esquema.Maestra
WHERE [Espec_Empresa_Cuit]  IS NOT NULL

--¿Como resuelvo la logica de asignacion puntos respecto a una compra? se lo doy a las ubicaciones y abz

INSERT INTO [ESKHERE].[Compra]--El id_Cliente debería ser el dni para poder obtenerlo de la BD maestra
           ([Compra_Fecha], descripcion,[Total],[ID_Cliente], [Id_Factura])
SELECT [Compra_Fecha] ,[Item_Factura_Descripcion],[Item_Factura_Monto],[Cli_Dni],[Factura_Nro]
FROM gd_esquema.Maestra
WHERE [Cli_Dni] is not null AND [Factura_Nro] is not null


--Usuario: id, usser, pass, habilitado