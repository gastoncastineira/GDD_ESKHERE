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
	[Id_Rol] [int],
	[Id_Funcion] [int],
	PRIMARY KEY(Id_Rol, Id_Funcion),
	CONSTRAINT FK_Rol FOREIGN KEY (Id_Rol) REFERENCES ESKHERE. [Rol](Id),
	CONSTRAINT FK_Funcion FOREIGN KEY (Id_Funcion) REFERENCES ESKHERE. [Funcion](Id)
);


CREATE TABLE ESKHERE.[Estado_publicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar](20) NOT NULL,
	[puedeModificarse] [int] NOT NULL
);

CREATE TABLE ESKHERE.[Grado_publicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar] (5),
	[Comision] int
	);

CREATE TABLE ESKHERE.[Usuario](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Usuario] [nvarchar](50) NOT NULL UNIQUE,
	[Contrasenia] [nvarchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
);--Datos puede referenciar a Empresa o Cliente segun el tipo de usuario que sea

CREATE TABLE ESKHERE.[Rubro](
	[Id] [int] NOT NULL PRIMARY KEY  IDENTITY(1,1),
	[Descripcion] [nvarchar](255) NULL
);

CREATE TABLE ESKHERE.[Espectaculo](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Espectaculo_Cod] [numeric](18, 0) NULL,
	[Espectaculo_Descripcion] [nvarchar](255) NULL,
	[Id_Rubro] [int] NULL,
	[Espectaculo_Estado] [nvarchar](255) NULL,
	CONSTRAINT FK_Rubro FOREIGN KEY (Id_Rubro) REFERENCES ESKHERE. Rubro(Id)
);
CREATE TABLE ESKHERE.[Publicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar](255) NULL, 
	[Stock] [int] NULL,
	[Fecha_publicacion] [datetime] NULL,
	[Fecha_funcion] [datetime] NULL,
	[Precio] [numeric](9,5),
	[Id_Espectaculo] [int] NOT NULL,
	[Direccion] [nvarchar](30) NULL,
	[Id_grado] [int] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Id_estado] [int] NOT NULL,
	CONSTRAINT FK_UsuarioPublicacion FOREIGN KEY (Id_usuario) REFERENCES ESKHERE. Usuario(Id),
	CONSTRAINT FK_grado FOREIGN KEY(Id_grado) REFERENCES ESKHERE. Grado_publicacion(Id),
	CONSTRAINT FK_Espectaculo FOREIGN KEY(Id_Espectaculo) REFERENCES ESKHERE. Espectaculo(Id),
	CONSTRAINT FK_estado FOREIGN KEY(Id_estado) REFERENCES ESKHERE. Estado_Publicacion(Id)
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



CREATE TABLE ESKHERE.[Hora_espectaculo](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Fecha] [datetime] NULL,
	[Fecha_Venc] [datetime] NULL,
	[Id_espectaculo] [int] NOT NULL,
	CONSTRAINT FK_EspectaculoHora FOREIGN KEY(Id_espectaculo) REFERENCES ESKHERE. Espectaculo(Id)
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
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Factura_Nro] [numeric](18, 0),
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	[Forma_Pago_Desc] [nvarchar](255) NULL,

);
--Un cliente tiene muchas compras y un espectáculo tiene muchas compras
--La compra es para los clientes
CREATE TABLE ESKHERE.[Compra](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Compra_Fecha] [datetime] NULL,
	[Total] [numeric](18, 0) NULL,
	puntos int NOT NULL,
	ID_Cliente INT NOT NULL,
	ID_Espectaculo INT NOT NULL,
	Id_Publicacion INT NOT NULL,
	Id_Factura INT NULL,
	CONSTRAINT FK_EspectaculoCompra FOREIGN KEY (Id_Publicacion) REFERENCES ESKHERE. Publicacion(Id),
	CONSTRAINT FK_Cliente   FOREIGN KEY(Id_Cliente) REFERENCES ESKHERE. Cliente(Id),	
	CONSTRAINT FK_Factura  FOREIGN KEY(Id_Factura) REFERENCES ESKHERE. Factura(Id)	
);


CREATE TABLE ESKHERE.[Ubicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ubicacion_Fila] char(1),
	[ubicacion_Asiento] [INT],
	[tipo] nvarchar(40),
	[precio] [INT],
	[descripcion] nvarchar(255),
	[ID_Espectaculo] [INT],
	[ID_Compra] [INT],
	CONSTRAINT FK_EspectaculoUbicacion FOREIGN KEY (ID_Espectaculo) REFERENCES ESKHERE. Espectaculo(Id),
	CONSTRAINT FK_Compra FOREIGN KEY (ID_Compra) REFERENCES ESKHERE. Compra(ID)
);

CREATE TABLE ESKHERE.[Ubicacion_Compra](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ID_ubicacion] [INT],
	[ID_Compra] [INT],
	CONSTRAINT FK_ubicacionCompra FOREIGN KEY (ID_ubicacion) REFERENCES ESKHERE. Espectaculo(ID),
	CONSTRAINT FK_CompraUbicacion FOREIGN KEY (ID_Compra) REFERENCES ESKHERE. Compra(ID)
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
	CONSTRAINT FK_premio  FOREIGN KEY(Id_premio) REFERENCES ESKHERE. Premios(Id),	
);

INSERT INTO [ESKHERE].[Usuario]
           ([Usuario],[Contrasenia],habilitado) VALUES ('1234','1234',1)


INSERT INTO [ESKHERE].[Premios] ([Puntos],[Descripcion]) 
VALUES (10, 'Encendedor'), (20, 'Juguete'), (100, 'Entrada'), (500, 'Peluche')


INSERT INTO [ESKHERE].[Rol] ([Nombre],[Habilitado])
VALUES ('Empresa',1),('Administrativo',1),('Cliente',1)


INSERT INTO [ESKHERE].[Ubicacion] -- Solo falta relacionarle ID_Espectaculo y ID_Compra 
           ([ubicacion_Fila],[Ubicacion_Asiento],[tipo],[precio], [descripcion])
SELECT  [ubicacion_Fila],[Ubicacion_Asiento],[Ubicacion_Tipo_Codigo],[Ubicacion_Precio], [Ubicacion_Tipo_Descripcion]
FROM gd_esquema.Maestra


 INSERT INTO [ESKHERE].[Espectaculo]
           ([Espectaculo_Cod],[Espectaculo_Descripcion],[Espectaculo_Estado])
SELECT [Espectaculo_Cod],[Espectaculo_Descripcion],[Espectaculo_Estado]
FROM gd_esquema.Maestra
WHERE [Espectaculo_Cod] IS NOT NULL

INSERT INTO [ESKHERE].[Factura]
           ([Factura_Nro],[Factura_Fecha],[Factura_Total],[Forma_Pago_Desc])
SELECT [Factura_Nro],[Factura_Fecha],[Factura_Total],[Forma_Pago_Desc]
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

--¿Como resuelvo la logica de asignacion puntos respecto a una compra?
Diferencia entre cant comprada
Diferencia entre item_factura_cant
INSERT INTO [ESKHERE].[Compra]
           ([Compra_Fecha],[Total],[puntos],[ID_Cliente],[ID_Espectaculo],[Id_Publicacion],[Id_Factura])
SELECT [Compra_Fecha] ,[Item_Factura_Monto],[Item_Factura_Cantidad],[Item_Factura_Descripcion]
FROM gd_esquema.Maestra

--Usuario: id, usser, pass, habilitado