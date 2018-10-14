USE [GD2C2018]
GO
/****** Object:  Schema [gd_esquema]    Script Date: 01:58:54 ******/
CREATE SCHEMA [gd_esquema] AUTHORIZATION [gdEspectaculos2018]
GO

--------------------------------------ABM ROL------------------------------------------------------

CREATE TABLE [gd_esquema].[Rol](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] [nvarchar](50) NOT NULL UNIQUE,
	[Habilitado] [bit] NOT NULL
);	

CREATE TABLE [gd_esquema].[Funcion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](255) NOT NULL
);

CREATE TABLE [gd_esquema].[Rol_X_Funcion](
	[Id_Rol] [int],
	[Id_Funcion] [int],
	PRIMARY KEY(Id_Rol, Id_Funcion),
	CONSTRAINT FK_Rol FOREIGN KEY (Id_Rol) REFERENCES Rol(Id),
	CONSTRAINT FK_Funcion FOREIGN KEY (Id_Funcion) REFERENCES Funcion(Id)
);

---------------------------------------------------------------------------------------------------

CREATE TABLE [gd_esquema].[Estado_publicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar](20) NOT NULL
);

CREATE TABLE [gd_esquema].[Grado_publicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar](5),
	[Comision] [numeric](0,2) NULL
);

CREATE TABLE [gd_esquema].[Publicacion](
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
	CONSTRAINT FK_Usuario FOREIGN KEY (Id_usuario) REFERENCES Usuario(Id),
	CONSTRAINT FK_grado FOREIGN KEY(Id_grado) REFERENCES Grado_publicacion(Id),
	CONSTRAINT FK_Espectaculo FOREIGN KEY(Id_Espectaculo) REFERENCES Espectaculo(Id),
	CONSTRAINT FK_estado FOREIGN KEY(Id_estado) REFERENCES Estado(Id)
);


CREATE TABLE [gd_esquema].[Rol_X_Usuario](
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  	ID_ROL VARCHAR(50) NOT NULL,
  	ID_Usuario VARCHAR(50) NOT NULL,
  	CONSTRAINT FK_Rol FOREIGN KEY (ID_Rol) REFERENCES Rol(ID),
	CONSTRAINT FK_Usuario FOREIGN KEY(ID_Usuario) REFERENCES Usuario(ID)
);

CREATE TABLE [gd_esquema].[Usuario](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Usuario] [nvarchar](50) NOT NULL UNIQUE,
	[Contrasenia] [nvarchar](50) NOT NULL,
	[Id_Rol] [int] NOT NULL,
	[Datos] [int] NOT NULL,
	[inhabilitado] [bit] NOT NULL,
	CONSTRAINT FK_Rol FOREIGN KEY (Id_Rol) REFERENCES Rol(Id),
	CONSTRAINT FK_Datos_Cliente FOREIGN KEY(Datos) REFERENCES Cliente(Id),
	CONSTRAINT FK_Datos_Empresa FOREIGN KEY(Id_Rol) REFERENCES Rol(Id) --ver
);--Datos puede referenciar a Empresa o Cliente segun el tipo de usuario que sea


CREATE TABLE [gd_esquema].[Domicilio](
	ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Calle nvarchar(50) NULL,
	Numero numeric(18, 0) NULL,
	Piso numeric(18, 0) NULL,
	Depto nvarchar(50) NULL,
	Cod_Postal [nvarchar](50) NULL,
	localidad nvarchar(50)
);


CREATE TABLE [gd_esquema].[Empresa](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Espec_Empresa_Razon_Social] [nvarchar](255) NULL UNIQUE,
	[Espec_Empresa_Cuit] [nvarchar](255) NULL UNIQUE,
	[Espec_Empresa_Fecha_Creacion] [datetime] NULL,
	[Espec_Empresa_Mail] [nvarchar](50) NULL,
	ID_Usuario INT NOT NULL,
	ID_Domicilio INT NOT NULL,
	CONSTRAINT FK_Usuario FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID),
	CONSTRAINT FK_Domicilio FOREIGN KEY (ID_Domicilio) REFERENCES Domicilio(ID)
);

CREATE TABLE [gd_esquema].[Rubro](
	[Id] [int] NOT NULL PRIMARY KEY,
	[Descripcion] [nvarchar](255) NULL
);

CREATE TABLE [gd_esquema].[Espectaculo](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Espectaculo_Cod] [numeric](18, 0) NULL,
	[Espectaculo_Descripcion] [nvarchar](255) NULL,
	[Id_Rubro] [int] NULL,
	[Id_Sala] [int] NULL,,
	[Espectaculo_Estado] [nvarchar](255) NULL,
	CONSTRAINT FK_Rubro FOREIGN KEY (Id_Rubro) REFERENCES Rubro(Id).
	CONSTRAINT FK_Sala FOREIGN KEY (Id_Sala) REFERENCES Sala(Id)
);

CREATE TABLE [gd_esquema].[Hora_espectaculo](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Fecha] [datetime] NULL,
	[Fecha_Venc] [datetime] NULL,
	[Id_espectaculo] [int] NOT NULL,
	CONSTRAINT FK_Espectaculo FOREIGN KEY(Id_espectaculo) REFERENCES Espectaculo(Id)
);

CREATE TABLE [gd_esquema].[Ubicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Ubicacion_Fila] [varchar](3) NULL,
	[Ubicacion_Asiento] [numeric](18, 0) NULL,
	[Ubicacion_Sin_numerar] [bit] NULL,
	[Ubicacion_Precio] [numeric](18, 0) NULL,
	[Ubicacion_Tipo_Codigo] [numeric](18, 0) NULL,
	[Ubicacion_Tipo_Descripcion] [nvarchar](255) NULL
);

--Tenemos acá un acumulador de ptos y en compras tenemos los ptos individuales de c/u
--¿Dejams los 2 o solo 1?
CREATE TABLE [gd_esquema].[Cliente](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Puntos] [Int],
	[Cli_Dni] [numeric](18, 0) NULL UNIQUE,
	[Cuil] [nvarchar](13) NULL UNIQUE,
	[Tipo_Doc] [nvarchar](15) NULL,
	[Cli_Apellido] [nvarchar](255) NULL,
	[Cli_Nombre] [nvarchar](255) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Mail] [nvarchar](255) NULL,
	[Cli_Dom_Calle] [nvarchar](255) NULL,
	[Cli_Nro_Calle] [numeric](18, 0) NULL,
	[Cli_Piso] [numeric](18, 0) NULL,
	[Cli_Depto] [nvarchar](255) NULL,
	[Cli_Cod_Postal] [nvarchar](255) NULL
	[localidad] [nvarchar](30) NULL,
	[fecha_creacion] [datetime] NULL,
	ID_Usuario INT NOT NULL,
	ID_Domicilio INT NOT NULL,
	CONSTRAINT FK_Usuario FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID),
	CONSTRAINT FK_Domicilio FOREIGN KEY (ID_Domicilio) REFERENCES Domicilio(ID)
	--[tarjeta] tal vez otra tabla
);

CREATE TABLE [gd_esquema].[Ubicacion](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ubicacion] [INT],
	[tipo] [VARCHAR(40)],
	[precio] [INT],
	[ID_Sala] [INT],
	[ID_Compra] [INT],
	CONSTRAINT FK_Sala FOREIGN KEY (ID_Sala) REFERENCES Sala(ID),
	CONSTRAINT FK_Compra FOREIGN KEY (ID_Compra) REFERENCES Compra(ID)
);


-- RELACIONA PUBLICACIONES Y UBICACIONES
CREATE TABLE [gd_esquema].[Sala](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ID_Espectaculo] [int],
	[ID_Datos] [int],
	CONSTRAINT FK_Espectaculo FOREIGN KEY (ID_Espectaculo) REFERENCES Espectaculo(ID),	
);

---------------------------------------------------------------------------------------------------


CREATE TABLE [gd_esquema].[MetodoDePago](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ID_Compra] [int],
	CONSTRAINT FK_Compra FOREIGN KEY (ID_Compra) REFERENCES Publicacion(ID)		
	
);

--Un cliente tiene muchas compras y un espectáculo tiene muchas compras
--La compra es para los clientes
CREATE TABLE [gd_esquema].[Compra](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Compra_Fecha] [datetime] NULL,
	[Compra_Cantidad] [numeric](18, 0) NULL,
	puntos int NOT NULL,
	ID_Cliente INT NOT NULL,
	ID_Espectaculo INT NOT NULL,
	CONSTRAINT FK_Espectaculo FOREIGN KEY (Id_Publicacion) REFERENCES Publicacion(Id),
	CONSTRAINT FK_Cliente   FOREIGN KEY(Id_Datos) REFERENCES Ubicacion(Id)	
);

	--VER!!!!
--Esto me relaciona las compras y las pone en una factura
--Item vendría a reprenstar a las comrpas
	[Item_Factura_Monto] [numeric](18, 2) NULL,
	[Item_Factura_Cantidad] [numeric](18, 0) NULL,
	[Item_Factura_Descripcion] [nvarchar](60) NULL,

--La factura es para las "empresas"
--Funcionalidad utilizada que registra facturas por el cobro de comisiones de ventas
--de publicaciones a la empresa de espectáculos.
--La comision la obtiene de: Compra -> Publicacion ->Grado Publicacion
CREATE TABLE [gd_esquema].[Factura](
	[Factura_Nro] [numeric](18, 0) NULL,
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	[Forma_Pago_Desc] [nvarchar](255) NULL,

);
