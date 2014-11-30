/*GENERAR TABLAS Y SCHEMA*/

USE [GD2C2014]
GO
/****** Object:  Schema [GAME_OF_QUERYS]    Script Date: 11/30/2014 15:48:43 ******/
CREATE SCHEMA [GAME_OF_QUERYS] AUTHORIZATION [gd]
GO
/****** Object:  Table [GAME_OF_QUERYS].[tipo_identidad]    Script Date: 11/30/2014 15:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[tipo_identidad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_tipo_docs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[pais]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[pais](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_pais] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[cliente]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_identidad_id] [int] NULL,
	[nro_identidad] [bigint] NULL,
	[apellido] [varchar](255) NULL,
	[nombre] [varchar](255) NULL,
	[fecha_nac] [date] NULL,
	[mail] [varchar](255) NULL,
	[tel] [bigint] NULL,
	[calle] [varchar](255) NULL,
	[nro_calle] [int] NULL,
	[piso] [int] NULL,
	[depto] [varchar](50) NULL,
	[ciudad] [varchar](255) NULL,
	[nacionalidad] [varchar](255) NULL,
	[localidad] [varchar](255) NULL,
	[permitido_ingreso] [bit] NULL,
	[pais_origen_id] [int] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[estado_reserva]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[estado_reserva](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NULL,
 CONSTRAINT [PK_estado_reserva] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[regimen]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[regimen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[precio_base] [numeric](18, 2) NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_regimen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[hotel]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[hotel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[calle] [varchar](255) NULL,
	[nro_calle] [int] NULL,
	[ciudad] [varchar](255) NULL,
	[cantidad_estrella] [int] NULL,
	[recarga_estrella] [int] NULL,
	[pais_id] [int] NULL,
	[tel] [bigint] NULL,
	[mail] [varchar](255) NULL,
	[fecha_creacion] [date] NULL,
	[nombre] [varchar](255) NULL,
 CONSTRAINT [PK_hotel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[reserva]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[reserva](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente_id] [int] NULL,
	[regimen_id] [int] NULL,
	[estado_id] [int] NULL,
	[fecha_realizacion] [date] NULL,
	[fecha_inicio] [date] NULL,
	[fecha_fin] [date] NULL,
	[usuario_ultima_modif_id] [int] NULL,
	[hotel_id] [int] NULL,
 CONSTRAINT [PK_reserva] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[cancelacion_reserva]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[cancelacion_reserva](
	[cancel_fecha] [date] NULL,
	[cancel_motivo] [varchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[reserva_id] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[estadia]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[estadia](
	[check_in] [date] NULL,
	[check_out] [date] NULL,
	[reserva_id] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_check_in_id] [int] NULL,
	[user_check_out_id] [int] NULL,
 CONSTRAINT [PK_estadia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[medio_de_pago]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[medio_de_pago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_medio_de_pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[factura]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[medio_de_pago_id] [int] NULL,
	[tarjeta] [bigint] NULL,
	[estadia_id] [int] NULL,
	[total] [numeric](18, 2) NULL,
 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[item]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[item](
	[factura_id] [int] NULL,
	[cant] [int] NULL,
	[descripcion] [varchar](255) NULL,
	[precio] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[mantenimiento]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[mantenimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hotel_id] [int] NULL,
	[fecha_inicio] [date] NULL,
	[fecha_fin] [date] NULL,
	[descripcion] [varchar](255) NULL,
 CONSTRAINT [PK_mantenimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[tipo_habitacion]    Script Date: 11/30/2014 15:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[tipo_habitacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[porcentual] [numeric](18, 2) NULL,
 CONSTRAINT [PK_tipo_habitacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[habitacion]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[habitacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hotel_id] [int] NULL,
	[nro] [int] NULL,
	[piso] [int] NULL,
	[ubicacion] [varchar](255) NULL,
	[tipo_hab_id] [int] NULL,
	[descripcion] [varchar](255) NULL,
	[estado_habitacion] [bit] NOT NULL,
 CONSTRAINT [PK_habitacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[reserva_habitacion]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[reserva_habitacion](
	[reserva_id] [int] NULL,
	[habitacion_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[funcionalidad]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[funcionalidad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NULL,
 CONSTRAINT [PK_funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[consumible]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[consumible](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[precio] [numeric](18, 2) NULL,
 CONSTRAINT [PK_consumible] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[consumible_estadia]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[consumible_estadia](
	[consumible_id] [int] NULL,
	[estadia_id] [int] NULL,
	[cantidad] [int] NULL,
	[habitacion_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[hotel_reg]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[hotel_reg](
	[hotel_id] [int] NOT NULL,
	[reg_id] [int] NOT NULL,
 CONSTRAINT [PK_hotel_reg] UNIQUE NONCLUSTERED 
(
	[hotel_id] ASC,
	[reg_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[rol]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[usuario]    Script Date: 11/30/2014 15:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GAME_OF_QUERYS].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[nombre] [varchar](255) NULL,
	[apellido] [varchar](255) NULL,
	[mail] [varchar](255) NULL,
	[tel] [bigint] NULL,
	[direccion] [varchar](255) NULL,
	[fecha_nac] [date] NULL,
	[estado] [bit] NULL,
	[nro_identidad] [bigint] NULL,
	[tipo_identidad_id] [int] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ__usuario__F3DBC5727E02B4CC] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GAME_OF_QUERYS].[hotel_usuario_rol]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[hotel_usuario_rol](
	[hotel_id] [int] NULL,
	[usuario_id] [int] NULL,
	[rol_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[rol_funcionalidad]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[rol_funcionalidad](
	[rol_id] [int] NULL,
	[funcionalidad_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[cliente_estadia]    Script Date: 11/30/2014 15:48:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[cliente_estadia](
	[cliente_id] [int] NULL,
	[estadia_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_cancelacion_reserva_reserva]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[cancelacion_reserva]  WITH CHECK ADD  CONSTRAINT [FK_cancelacion_reserva_reserva] FOREIGN KEY([reserva_id])
REFERENCES [GAME_OF_QUERYS].[reserva] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cancelacion_reserva] CHECK CONSTRAINT [FK_cancelacion_reserva_reserva]
GO
/****** Object:  ForeignKey [FK_cliente_pais]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_pais] FOREIGN KEY([pais_origen_id])
REFERENCES [GAME_OF_QUERYS].[pais] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cliente] CHECK CONSTRAINT [FK_cliente_pais]
GO
/****** Object:  ForeignKey [FK_cliente_tipo_identidad]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_tipo_identidad] FOREIGN KEY([tipo_identidad_id])
REFERENCES [GAME_OF_QUERYS].[tipo_identidad] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cliente] CHECK CONSTRAINT [FK_cliente_tipo_identidad]
GO
/****** Object:  ForeignKey [FK_cliente_estadia_cliente]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[cliente_estadia]  WITH CHECK ADD  CONSTRAINT [FK_cliente_estadia_cliente] FOREIGN KEY([cliente_id])
REFERENCES [GAME_OF_QUERYS].[cliente] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cliente_estadia] CHECK CONSTRAINT [FK_cliente_estadia_cliente]
GO
/****** Object:  ForeignKey [FK_cliente_estadia_estadia]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[cliente_estadia]  WITH CHECK ADD  CONSTRAINT [FK_cliente_estadia_estadia] FOREIGN KEY([estadia_id])
REFERENCES [GAME_OF_QUERYS].[estadia] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cliente_estadia] CHECK CONSTRAINT [FK_cliente_estadia_estadia]
GO
/****** Object:  ForeignKey [FK_consumible_estadia_consumible]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[consumible_estadia]  WITH CHECK ADD  CONSTRAINT [FK_consumible_estadia_consumible] FOREIGN KEY([consumible_id])
REFERENCES [GAME_OF_QUERYS].[consumible] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[consumible_estadia] CHECK CONSTRAINT [FK_consumible_estadia_consumible]
GO
/****** Object:  ForeignKey [FK_consumible_estadia_estadia]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[consumible_estadia]  WITH CHECK ADD  CONSTRAINT [FK_consumible_estadia_estadia] FOREIGN KEY([estadia_id])
REFERENCES [GAME_OF_QUERYS].[estadia] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[consumible_estadia] CHECK CONSTRAINT [FK_consumible_estadia_estadia]
GO
/****** Object:  ForeignKey [FK_estadia_reserva]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[estadia]  WITH CHECK ADD  CONSTRAINT [FK_estadia_reserva] FOREIGN KEY([reserva_id])
REFERENCES [GAME_OF_QUERYS].[reserva] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[estadia] CHECK CONSTRAINT [FK_estadia_reserva]
GO
/****** Object:  ForeignKey [FK_factura_estadia]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_estadia] FOREIGN KEY([estadia_id])
REFERENCES [GAME_OF_QUERYS].[estadia] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[factura] CHECK CONSTRAINT [FK_factura_estadia]
GO
/****** Object:  ForeignKey [FK_factura_medio_de_pago]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_medio_de_pago] FOREIGN KEY([medio_de_pago_id])
REFERENCES [GAME_OF_QUERYS].[medio_de_pago] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[factura] CHECK CONSTRAINT [FK_factura_medio_de_pago]
GO
/****** Object:  ForeignKey [FK_habitacion_hotel]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[habitacion]  WITH CHECK ADD  CONSTRAINT [FK_habitacion_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[habitacion] CHECK CONSTRAINT [FK_habitacion_hotel]
GO
/****** Object:  ForeignKey [FK_habitacion_tipo_habitacion]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[habitacion]  WITH CHECK ADD  CONSTRAINT [FK_habitacion_tipo_habitacion] FOREIGN KEY([tipo_hab_id])
REFERENCES [GAME_OF_QUERYS].[tipo_habitacion] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[habitacion] CHECK CONSTRAINT [FK_habitacion_tipo_habitacion]
GO
/****** Object:  ForeignKey [FK_hotel_reg_hotel]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_reg]  WITH CHECK ADD  CONSTRAINT [FK_hotel_reg_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_reg] CHECK CONSTRAINT [FK_hotel_reg_hotel]
GO
/****** Object:  ForeignKey [FK_hotel_reg_regimen]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_reg]  WITH CHECK ADD  CONSTRAINT [FK_hotel_reg_regimen] FOREIGN KEY([reg_id])
REFERENCES [GAME_OF_QUERYS].[regimen] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_reg] CHECK CONSTRAINT [FK_hotel_reg_regimen]
GO
/****** Object:  ForeignKey [FK_hotel_usuario_rol_hotel]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol]  WITH CHECK ADD  CONSTRAINT [FK_hotel_usuario_rol_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol] CHECK CONSTRAINT [FK_hotel_usuario_rol_hotel]
GO
/****** Object:  ForeignKey [FK_hotel_usuario_rol_rol]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol]  WITH CHECK ADD  CONSTRAINT [FK_hotel_usuario_rol_rol] FOREIGN KEY([rol_id])
REFERENCES [GAME_OF_QUERYS].[rol] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol] CHECK CONSTRAINT [FK_hotel_usuario_rol_rol]
GO
/****** Object:  ForeignKey [FK_hotel_usuario_rol_usuario]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol]  WITH CHECK ADD  CONSTRAINT [FK_hotel_usuario_rol_usuario] FOREIGN KEY([usuario_id])
REFERENCES [GAME_OF_QUERYS].[usuario] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol] CHECK CONSTRAINT [FK_hotel_usuario_rol_usuario]
GO
/****** Object:  ForeignKey [FK_item_factura]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_factura] FOREIGN KEY([factura_id])
REFERENCES [GAME_OF_QUERYS].[factura] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[item] CHECK CONSTRAINT [FK_item_factura]
GO
/****** Object:  ForeignKey [FK_mantenimiento_hotel]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[mantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_mantenimiento_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[mantenimiento] CHECK CONSTRAINT [FK_mantenimiento_hotel]
GO
/****** Object:  ForeignKey [FK_reserva_cliente]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_cliente] FOREIGN KEY([cliente_id])
REFERENCES [GAME_OF_QUERYS].[cliente] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva] CHECK CONSTRAINT [FK_reserva_cliente]
GO
/****** Object:  ForeignKey [FK_reserva_estado_reserva]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_estado_reserva] FOREIGN KEY([estado_id])
REFERENCES [GAME_OF_QUERYS].[estado_reserva] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva] CHECK CONSTRAINT [FK_reserva_estado_reserva]
GO
/****** Object:  ForeignKey [FK_reserva_hotel]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva] CHECK CONSTRAINT [FK_reserva_hotel]
GO
/****** Object:  ForeignKey [FK_reserva_regimen]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_regimen] FOREIGN KEY([regimen_id])
REFERENCES [GAME_OF_QUERYS].[regimen] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva] CHECK CONSTRAINT [FK_reserva_regimen]
GO
/****** Object:  ForeignKey [FK_reserva_habitacion_habitacion]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva_habitacion]  WITH CHECK ADD  CONSTRAINT [FK_reserva_habitacion_habitacion] FOREIGN KEY([habitacion_id])
REFERENCES [GAME_OF_QUERYS].[habitacion] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva_habitacion] CHECK CONSTRAINT [FK_reserva_habitacion_habitacion]
GO
/****** Object:  ForeignKey [FK_reserva_habitacion_reserva]    Script Date: 11/30/2014 15:48:44 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva_habitacion]  WITH CHECK ADD  CONSTRAINT [FK_reserva_habitacion_reserva] FOREIGN KEY([reserva_id])
REFERENCES [GAME_OF_QUERYS].[reserva] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva_habitacion] CHECK CONSTRAINT [FK_reserva_habitacion_reserva]
GO
/****** Object:  ForeignKey [FK_rol_funcionalidad_funcionalidad]    Script Date: 11/30/2014 15:48:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_rol_funcionalidad_funcionalidad] FOREIGN KEY([funcionalidad_id])
REFERENCES [GAME_OF_QUERYS].[funcionalidad] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[rol_funcionalidad] CHECK CONSTRAINT [FK_rol_funcionalidad_funcionalidad]
GO
/****** Object:  ForeignKey [FK_rol_funcionalidad_rol]    Script Date: 11/30/2014 15:48:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_rol_funcionalidad_rol] FOREIGN KEY([rol_id])
REFERENCES [GAME_OF_QUERYS].[rol] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[rol_funcionalidad] CHECK CONSTRAINT [FK_rol_funcionalidad_rol]
GO
/****** Object:  ForeignKey [FK_usuario_tipo_identidad]    Script Date: 11/30/2014 15:48:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_tipo_identidad] FOREIGN KEY([tipo_identidad_id])
REFERENCES [GAME_OF_QUERYS].[tipo_identidad] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[usuario] CHECK CONSTRAINT [FK_usuario_tipo_identidad]
GO



---------------------------------------------------------------------------------------------------------------------------------------------------------------

 /*MIGRACION*/
/*cargar argentina en pais, hotel (16) y regimen (4) */
insert into GAME_OF_QUERYS.pais (nombre) values ('Argentina')
insert into GAME_OF_QUERYS.pais(nombre) values ('Uruguay')
insert into GAME_OF_QUERYS.pais(nombre) values ('Chile')
insert into GAME_OF_QUERYS.pais(nombre) values ('Brasil')
insert into GAME_OF_QUERYS.pais(nombre) values ('Estados Unidos')


insert into GAME_OF_QUERYS.hotel (ciudad, calle, nro_calle, cantidad_estrella, recarga_estrella,
								 pais_id, nombre)
select distinct ltrim(rtrim(Hotel_Ciudad)), Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella,Hotel_Recarga_Estrella,
				(select id from GAME_OF_QUERYS.pais where nombre='Argentina'),
				( ltrim(rtrim(Hotel_Ciudad)) + ' ' + ltrim(rtrim(Hotel_Calle)) )
from gd_esquema.Maestra 

insert into GAME_OF_QUERYS.regimen(descripcion, precio_base,estado)
select distinct Regimen_Descripcion, Regimen_Precio,'1'
from gd_esquema.Maestra

/*cargar reg_hotel (4x16, todos los hoteles tienen los 4 regimenes)*/

insert into GAME_OF_QUERYS.hotel_reg( hotel_id, reg_id)
select distinct h.id, r.id
from GAME_OF_QUERYS.hotel h, GAME_OF_QUERYS.regimen r

/*cargar tipo_ident dni y pasaporte y los clientes (100740)*/

insert into GAME_OF_QUERYS.tipo_identidad (nombre) values ('DNI')
insert into GAME_OF_QUERYS.tipo_identidad (nombre) values ('Pasaporte')

insert into GAME_OF_QUERYS.cliente (tipo_identidad_id, nro_identidad, apellido,nombre,
					fecha_nac, mail, calle, nro_calle, piso,
					depto,nacionalidad,permitido_ingreso, pais_origen_id)
select distinct (select id from GAME_OF_QUERYS.tipo_identidad where nombre='Pasaporte'),Cliente_Pasaporte_Nro, Cliente_Apellido,
				Cliente_Nombre,cast(Cliente_Fecha_Nac as Date), Cliente_Mail,
				Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso,
				Cliente_Depto,Cliente_Nacionalidad,'1','1'
from gd_esquema.Maestra

/*cargar tipo_habitacion (5)*/
set identity_insert GD2C2014.GAME_OF_QUERYS.tipo_habitacion on
insert into GAME_OF_QUERYS.tipo_habitacion (id, descripcion, porcentual)
select distinct Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion ,
				 Habitacion_Tipo_Porcentual
from gd_esquema.Maestra
set identity_insert GD2C2014.GAME_OF_QUERYS.tipo_habitacion off

/*cargar habitacion (345)*/

insert into GAME_OF_QUERYS.habitacion (hotel_id,nro,piso,ubicacion,tipo_hab_id,
										estado_habitacion)
select distinct h.id, m.Habitacion_Numero, m.Habitacion_Piso,
		 m.Habitacion_Frente, m.Habitacion_Tipo_Codigo, '1'
from gd_esquema.Maestra m 
			join GAME_OF_QUERYS.hotel h on h.ciudad=m.Hotel_Ciudad and h.calle=m.Hotel_Calle
							and h.nro_calle=m.Hotel_Nro_Calle
							
/* cargar estado_reserva (6)*/
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('correcta')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('modificada')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por recepcion')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por cliente')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por No-Show')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('con ingreso')

/*cargar reserva (100740)*/

set identity_insert GD2C2014.GAME_OF_QUERYS.reserva on
insert into GAME_OF_QUERYS.reserva(id,cliente_id,regimen_id, fecha_inicio, fecha_fin,hotel_id)
select distinct m.Reserva_Codigo, c.id, r.id, cast(m.Reserva_Fecha_Inicio as Date), DATEADD (day ,m.Reserva_Cant_Noches , cast(m.Reserva_Fecha_Inicio as Date) ),h.id
from gd_esquema.Maestra m
						join GAME_OF_QUERYS.cliente c on m.cliente_pasaporte_nro=c.nro_identidad and
														m.Cliente_Mail=c.mail
						join GAME_OF_QUERYS.regimen r on r.descripcion = m.regimen_descripcion
						
						join GAME_OF_QUERYS.hotel h on h.ciudad=m.Hotel_Ciudad and h.calle=m.Hotel_Calle
							and h.nro_calle=m.Hotel_Nro_Calle
						
set identity_insert GD2C2014.GAME_OF_QUERYS.reserva off	

/*cargar reserva_habitacion (100740)*/

insert into GAME_OF_QUERYS.reserva_habitacion ( reserva_id, habitacion_id)
select distinct m.reserva_codigo, h.id
from gd_esquema.Maestra m
						join GAME_OF_QUERYS.hotel ho on m.Hotel_Calle = ho.calle and
														m.Hotel_Nro_Calle=ho.nro_calle
													and m.Hotel_Ciudad=ho.ciudad
						join GAME_OF_QUERYS.habitacion h on m.Habitacion_Piso=h.piso and
													m.Habitacion_Numero=h.nro
where ho.id = h.hotel_id
																					
/*cargar consumible (4) */

set identity_insert GD2C2014.GAME_OF_QUERYS.consumible on
insert into GAME_OF_QUERYS.consumible (id,descripcion,precio)
select distinct Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
from gd_esquema.Maestra
where Consumible_Codigo is not null
set identity_insert GD2C2014.GAME_OF_QUERYS.consumible off	

/*cargar estadia (89603)*/

insert into GAME_OF_QUERYS.estadia (check_in, check_out, reserva_id)
select distinct cast(Estadia_Fecha_Inicio as date),
			 DATEADD (day ,estadia_Cant_Noches , cast(estadia_Fecha_Inicio as Date) ),Reserva_Codigo
from gd_esquema.Maestra
where Estadia_Fecha_Inicio is not null

/*cargar consumible_estadia (207341)*/

insert into GAME_OF_QUERYS.consumible_estadia (consumible_id,estadia_id,cantidad,habitacion_id)
select distinct c.id, e.id, COUNT(m.Consumible_Descripcion), r.habitacion_id
from gd_esquema.Maestra m join GAME_OF_QUERYS.consumible c on m.Consumible_Codigo= c.id
							join GAME_OF_QUERYS.estadia e on m.Reserva_Codigo=e.reserva_id
							join GAME_OF_QUERYS.reserva_habitacion r on r.reserva_id = m.Reserva_Codigo
group by c.id,e.id,r.habitacion_id


/* cargar cliente_estadia (89603) */

insert into GAME_OF_QUERYS.cliente_estadia (cliente_id,estadia_id)
select distinct c.id, e.id
from gd_esquema.Maestra m join GAME_OF_QUERYS.cliente c 
							on m.cliente_pasaporte_nro=c.nro_identidad and
														m.Cliente_Mail=c.mail
						join GAME_OF_QUERYS.estadia e on m.Reserva_Codigo=e.reserva_id

/*cargar medios de pago*/
insert into GAME_OF_QUERYS.medio_de_pago(nombre) values ('Efectivo')
insert into GAME_OF_QUERYS.medio_de_pago(nombre) values ('Tarjeta de credito')

/*cargar factura (89603)*/
set identity_insert GD2C2014.GAME_OF_QUERYS.factura on
insert into GAME_OF_QUERYS.factura (id,fecha,estadia_id,medio_de_pago_id)
select distinct m.Factura_Nro,CAST(m.Factura_Fecha as DATE), e.id,(select id from GAME_OF_QUERYS.medio_de_pago where nombre='Efectivo')
from gd_esquema.Maestra m join GAME_OF_QUERYS.estadia e on m.Reserva_Codigo=e.reserva_id
where m.Factura_Fecha is not null
set identity_insert GD2C2014.GAME_OF_QUERYS.factura off	


/* Inserto en tabla items todas las estadias */
INSERT INTO GAME_OF_QUERYS.item(factura_id, cant, descripcion, precio)
(SELECT factura.id,  DATEDIFF(DAY, check_in, check_out), 'Habitación '+tipo_habitacion.descripcion, (precio_base*porcentual + cantidad_estrella*recarga_estrella) 
FROM GAME_OF_QUERYS.factura
JOIN GAME_OF_QUERYS.estadia ON (factura.estadia_id = estadia.id)
JOIN GAME_OF_QUERYS.reserva ON (estadia.reserva_id = reserva.id)
JOIN GAME_OF_QUERYS.reserva_habitacion ON (reserva.id = reserva_habitacion.reserva_id)
JOIN GAME_OF_QUERYS.habitacion ON (reserva_habitacion.habitacion_id = habitacion.id)
JOIN GAME_OF_QUERYS.tipo_habitacion ON (tipo_habitacion.id = habitacion.tipo_hab_id)
JOIN GAME_OF_QUERYS.regimen ON (regimen.id = reserva.regimen_id)
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = reserva.hotel_id)
WHERE check_in is not null AND check_out is not null)


/* Inserto todos los items de consumibles */
INSERT INTO GAME_OF_QUERYS.item(factura_id, cant, descripcion, precio)
(SELECT factura.id, consumible_estadia.cantidad, consumible.descripcion, consumible.precio
FROM GAME_OF_QUERYS.factura
JOIN GAME_OF_QUERYS.consumible_estadia ON (consumible_estadia.estadia_id = factura.estadia_id)
JOIN GAME_OF_QUERYS.consumible ON (consumible.id = consumible_estadia.consumible_id))


/* Inserto los descuentos por regimen all inclusive */
INSERT INTO GAME_OF_QUERYS.item(factura_id, cant, descripcion, precio)
SELECT factura.id, 1, 'Descuento por régimen All Inclusive', 0- SUM(consumible.precio * consumible_estadia.cantidad)
FROM GAME_OF_QUERYS.factura
JOIN GAME_OF_QUERYS.estadia ON (factura.estadia_id = estadia.id)
JOIN GAME_OF_QUERYS.consumible_estadia ON (consumible_estadia.estadia_id = factura.estadia_id)
JOIN GAME_OF_QUERYS.consumible ON (consumible.id = consumible_estadia.consumible_id)
JOIN GAME_OF_QUERYS.reserva ON (reserva.id = estadia.reserva_id)
where reserva.regimen_id = 3
GROUP BY factura.id


/* Inserto el total de las facturas */
UPDATE GAME_OF_QUERYS.factura SET total =(SELECT SUM(cant*precio) FROM GAME_OF_QUERYS.item WHERE item.factura_id = factura.id)



/*cargar rol (4)*/
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Administrador',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Recepcionista',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Guest',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('admin',1)

/*cargar funcionalidad (11)*/
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmRol')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('ambUsuario')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmCliente')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmHabitacion')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmRegimen')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('Reservas')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('registrarEstadia y Facturacion')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('estadistico')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmHotel')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('consumibles')

/*cargar usuario (2)*/

insert into GAME_OF_QUERYS.usuario (username,estado) values ('guest', 1 )
insert into GAME_OF_QUERYS.usuario (username,password, nombre,estado) values ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 'Administrador General','1')

/* Para que ande el login el usuario tiene que tener un registro en la tabla hotel_usuario_rol */
insert into GAME_OF_QUERYS.hotel_usuario_rol (hotel_id, usuario_id, rol_id) 
(select hotel.id,2,4 from GAME_OF_QUERYS.hotel )


/* Inserto las funcionalidades del rol admin (todas) */
insert into GAME_OF_QUERYS.rol_funcionalidad(rol_id, funcionalidad_id)
(select r.id, f.id from GAME_OF_QUERYS.rol r, GAME_OF_QUERYS.funcionalidad f WHERE r.descripcion = 'admin')

/****** Object:  Table [GAME_OF_QUERYS].[rol_funcionalidad]    Script Date: 11/11/2014 10:26:42 ******/
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 2)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 3)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 4)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 5)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 6)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 7)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 8)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 9)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 10)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (2, 3)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (2, 6)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (2, 7)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (2, 10)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (3, 6)


/*Trigger para controlar funcionalidades de cada rol
ABM de Rol: Exclusivo del administrador general
ABM de Hotel y ABM de Usuario: exclusivos del administrador o administrador general
*/
GO
CREATE TRIGGER GAME_OF_QUERYS.TrigInsRolFuncionalidad
ON GAME_OF_QUERYS.rol_funcionalidad
INSTEAD OF INSERT AS

BEGIN
DECLARE @idRol int, @idFuncionalidad int
SELECT @idFuncionalidad = funcionalidad_id, @idRol = rol_id FROM inserted

IF((@idFuncionalidad IN (2,9) AND @idRol NOT IN (1, 4)) OR (@idFuncionalidad = 1 AND @idRol != 4))
BEGIN
RAISERROR('No se puede asignar funcionalidad a rol', 10, 1)
RETURN
END

INSERT INTO GAME_OF_QUERYS.rol_funcionalidad(rol_id, funcionalidad_id) VALUES(@idRol, @idFuncionalidad)
END
GO


/*Trigger para que cada vez que se crea un hotel se le asigne como administrador general el usuario 'admin' al hotel*/
CREATE TRIGGER GAME_OF_QUERYS.TrigAsignarAdmin
ON GAME_OF_QUERYS.Hotel
AFTER INSERT AS
BEGIN
INSERT INTO GAME_OF_QUERYS.hotel_usuario_rol(hotel_id, usuario_id, rol_id)
SELECT id, 2, 4
FROM inserted
END
GO


/* cargar estado_id en reserva se tiene en cuenta que la maxima fecha de check out en la tabla maestra es 31-12-2016, por lo que tomamos como 'dia de hoy' a 01-01-2017 */
--reservas que tienen estadia --> estado: 6 - con ingreso
update GAME_OF_QUERYS.reserva set estado_id = (select id from GAME_OF_QUERYS.estado_reserva where descripcion='con ingreso')
where fecha_inicio <= (select MAX(check_out) from GAME_OF_QUERYS.estadia)
and id in (select reserva_id from GAME_OF_QUERYS.estadia)


--reservas viejas que no aparecen en la tabla de estadia --> estado: 5 - cancelada por no-show
update GAME_OF_QUERYS.reserva set estado_id = (select id from GAME_OF_QUERYS.estado_reserva where descripcion='cancelada por No-Show')
where fecha_inicio <= (select MAX(check_out) from GAME_OF_QUERYS.estadia)	--max(check_out) es la maxima fecha que aparece
and id not in (select reserva_id from GAME_OF_QUERYS.estadia)

--reservas proximas --> estado: 1 - correcta (por ahora no hay ninguna)
update GAME_OF_QUERYS.reserva set estado_id = (select id from GAME_OF_QUERYS.estado_reserva where descripcion='correcta')
where fecha_inicio > (select MAX(check_out) from GAME_OF_QUERYS.estadia)
and id in (select reserva_id from GAME_OF_QUERYS.estadia where check_in is null)



/* Inserto los registros en cancelacion_reserva, asumimos que es por No-Show y se registra la cancelacion al dia siguiente del inicio de la reserva*/
insert into GAME_OF_QUERYS.cancelacion_reserva(cancel_fecha, cancel_motivo, reserva_id)
select DATEADD(dd, 1, fecha_inicio) fecha, 'No se presentó', id from GAME_OF_QUERYS.reserva where estado_id = 5



/*Stored Procedures para listados*/
GO
-- Hoteles con mayor cantidad de reservas canceladas
CREATE PROCEDURE GAME_OF_QUERYS.mayoresCancelaciones @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 hotel_id, nombre AS 'nombre del hotel', COUNT(*) AS cantidad FROM GAME_OF_QUERYS.reserva
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = reserva.hotel_id)
WHERE estado_id IN (3, 4, 5) AND (MONTH(fecha_inicio) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(fecha_inicio) = @year
GROUP BY hotel_id, nombre
ORDER BY cantidad DESC
GO


-- Hoteles con mayor cantidad de consumibles facturados
CREATE PROCEDURE GAME_OF_QUERYS.mayoresConsumibles @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 hotel_id, nombre AS 'nombre del hotel', COUNT(consumible_id) AS cantidad FROM GAME_OF_QUERYS.consumible_estadia
JOIN GAME_OF_QUERYS.estadia ON (consumible_estadia.estadia_id = estadia.id)
JOIN GAME_OF_QUERYS.reserva ON (estadia.reserva_id = reserva.id)
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = reserva.hotel_id)
WHERE check_in IS NOT NULL AND check_out IS NOT NULL AND(MONTH(check_in) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(check_in) = @year
GROUP BY hotel_id, nombre
ORDER BY cantidad DESC
GO


-- Hoteles con mayor cantidad de días fuera de servicio
CREATE PROCEDURE GAME_OF_QUERYS.mayoresMantenimiento @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 hotel_id, nombre AS 'nombre del hotel', SUM(DATEDIFF(DAY, fecha_inicio, fecha_fin)) AS cantidad FROM GAME_OF_QUERYS.mantenimiento
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = mantenimiento.hotel_id)
WHERE (MONTH(fecha_inicio) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(fecha_inicio) = @year
GROUP BY hotel_id, nombre
ORDER BY cantidad DESC
GO


-- Habitaciones con mayor cantidad de días y veces que fueron ocupadas
CREATE PROCEDURE GAME_OF_QUERYS.habitacionesOcupadas @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 nombre AS 'nombre de hotel', reserva.hotel_id, nro AS 'nro de habitacion', SUM(DATEDIFF(DAY, fecha_inicio, fecha_fin)) AS 'cantidad de dias', COUNT(estadia.reserva_id) as 'cantidad de veces'
FROM GAME_OF_QUERYS.estadia
JOIN GAME_OF_QUERYS.reserva ON (estadia.reserva_id = reserva.id)
JOIN GAME_OF_QUERYS.reserva_habitacion ON (reserva.id = reserva_habitacion.reserva_id)
JOIN GAME_OF_QUERYS.habitacion ON (reserva_habitacion.habitacion_id = habitacion.id)
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = reserva.hotel_id)
WHERE check_in IS NOT NULL AND check_out IS NOT NULL AND (MONTH(check_in) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(check_in) = @year
GROUP BY reserva.hotel_id, nombre, nro
ORDER BY 4 DESC, 5 DESC
GO


-- Puntos de los clientes: 1 por cada $10 de estadia y 1 por cada $5 de consumibles

--Primero creamos dos vistas para simplificar un poco el stored procedure
create view GAME_OF_QUERYS.vEstadiasCliente
as
select cliente_id, check_in, check_out, SUM(precio_base*porcentual + cantidad_estrella*recarga_estrella) * DATEDIFF(DAY, fecha_inicio, fecha_fin) as costoEstadia
from GAME_OF_QUERYS.reserva
join GAME_OF_QUERYS.estadia on (estadia.reserva_id = reserva.id)
JOIN GAME_OF_QUERYS.reserva_habitacion ON (reserva.id = reserva_habitacion.reserva_id)
JOIN GAME_OF_QUERYS.regimen ON (reserva.regimen_id = regimen.id)
JOIN GAME_OF_QUERYS.hotel ON (reserva.hotel_id = hotel.id)
JOIN GAME_OF_QUERYS.habitacion ON (reserva_habitacion.habitacion_id = habitacion.id)
JOIN GAME_OF_QUERYS.tipo_habitacion ON (tipo_habitacion.id = habitacion.tipo_hab_id)
where estado_id=6 and check_out is not null
GROUP BY cliente_id, estadia.id, check_in, check_out, fecha_inicio, fecha_fin
go

create view GAME_OF_QUERYS.vConsumiblesCliente
as
select cliente_id, check_in, check_out, SUM(consumible_estadia.cantidad*consumible.precio) costoConsumible from GAME_OF_QUERYS.consumible_estadia
join GAME_OF_QUERYS.consumible on (consumible.id = consumible_estadia.consumible_id)
join GAME_OF_QUERYS.estadia on (consumible_estadia.estadia_id=estadia.id)
join GAME_OF_QUERYS.reserva on (reserva.id=estadia.reserva_id)
where estado_id=6 and check_in is not null and check_out is not null
GROUP BY cliente_id, estadia.id, check_in, check_out
go

--ahora el listado
CREATE PROCEDURE GAME_OF_QUERYS.puntosCliente @year int, @trimestreInicio int, @trimestreFin int
AS
select TOP 5 e.cliente_id, cliente.nombre + ' ' + cliente.apellido AS 'nombre y apellido', ROUND(CAST((SUM(distinct costoEstadia)/10 + SUM(distinct costoConsumible)/5) AS FLOAT), 0, 1) AS puntos
from GAME_OF_QUERYS.vEstadiasCliente e 
left join GAME_OF_QUERYS.vConsumiblesCliente c on (e.cliente_id = c.cliente_id)
join GAME_OF_QUERYS.cliente on (cliente.id = e.cliente_id)
where (MONTH(e.check_in) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(e.check_in) = @year
and (MONTH(c.check_in) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(c.check_in) = @year
group by e.cliente_id, cliente.nombre, cliente.apellido
order by puntos desc
GO

