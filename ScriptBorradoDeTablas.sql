USE [GD2C2018]
GO

DROP TABLE ESKHERE.Item_Factura
DROP TABLE ESKHERE.Factura
DROP TABLE ESKHERE.Compra
DROP TABLE ESKHERE.Ubicacion
DROP TABLE ESKHERE.Publicacion
DROP TABLE ESKHERE.Publicacion_Estado
DROP TABLE ESKHERE.Publicacion_Fechas
DROP TABLE ESKHERE.Publicacion_Grado
DROP TABLE ESKHERE.Empresa
DROP TABLE ESKHERE.Rol_X_Funcion
DROP TABLE ESKHERE.Rol_X_Usuario
DROP TABLE ESKHERE.Rol
DROP TABLE ESKHERE.Funcion
DROP TABLE ESKHERE.cliente_premio
DROP TABLE ESKHERE.Premios
DROP TABLE ESKHERE.Puntos
DROP TABLE ESKHERE.Cliente
DROP TABLE ESKHERE.Usuario

DROP PROCEDURE [ESKHERE].existe_usuario
DROP PROCEDURE [ESKHERE].insertar_usuario
DROP PROCEDURE [ESKHERE].crear_usuario_aleatorio
DROP VIEW [ESKHERE].funciones_usuario
DROP VIEW [ESKHERE].clientes_con_mayores_ptos_vencidos
DROP VIEW [ESKHERE].clientes_con_mayor_cantidad_de_compras
DROP VIEW [ESKHERE].empresas_con_mayor_cant_de_ubicaciones_sin_vender
DROP VIEW [ESKHERE].anios_que_se_publicaron_espectaculos
DROP VIEW [ESKHERE].anios_minimo_de_publicacion
DROP VIEW [ESKHERE].Historial_Compras
DROP VIEW [ESKHERE].funciones_usuarios
DROP VIEW [ESKHERE].Roles_usuario
DROP VIEW [ESKHERE].rubros
DROP VIEW [ESKHERE].Ubicaciones_por_publi_disponibles
DROP VIEW [ESKHERE].Publicaciones_disponibles_para_listar	