USE [GD2C2014]
GO
/****** Object:  Schema [GAME_OF_QUERYS]    Script Date: 11/27/2014 19:26:44 ******/
CREATE SCHEMA [GAME_OF_QUERYS] AUTHORIZATION [gd]
GO
/****** Object:  Table [GAME_OF_QUERYS].[tipo_identidad]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[pais]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[cliente]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[estado_reserva]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[regimen]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[hotel]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[reserva]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[cancelacion_reserva]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[estadia]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[medio_de_pago]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[factura]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[item]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[mantenimiento]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[tipo_habitacion]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[habitacion]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[reserva_habitacion]    Script Date: 11/27/2014 19:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[reserva_habitacion](
	[reserva_id] [int] NULL,
	[habitacion_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[funcionalidad]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[consumible]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[consumible_estadia]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[hotel_reg]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[rol]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[usuario]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[hotel_usuario_rol]    Script Date: 11/27/2014 19:26:45 ******/
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
/****** Object:  Table [GAME_OF_QUERYS].[rol_funcionalidad]    Script Date: 11/27/2014 19:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[rol_funcionalidad](
	[rol_id] [int] NULL,
	[funcionalidad_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [GAME_OF_QUERYS].[cliente_estadia]    Script Date: 11/27/2014 19:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GAME_OF_QUERYS].[cliente_estadia](
	[cliente_id] [int] NULL,
	[estadia_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_cancelacion_reserva_reserva]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[cancelacion_reserva]  WITH CHECK ADD  CONSTRAINT [FK_cancelacion_reserva_reserva] FOREIGN KEY([reserva_id])
REFERENCES [GAME_OF_QUERYS].[reserva] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cancelacion_reserva] CHECK CONSTRAINT [FK_cancelacion_reserva_reserva]
GO
/****** Object:  ForeignKey [FK_cliente_pais]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_pais] FOREIGN KEY([pais_origen_id])
REFERENCES [GAME_OF_QUERYS].[pais] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cliente] CHECK CONSTRAINT [FK_cliente_pais]
GO
/****** Object:  ForeignKey [FK_cliente_tipo_identidad]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_tipo_identidad] FOREIGN KEY([tipo_identidad_id])
REFERENCES [GAME_OF_QUERYS].[tipo_identidad] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cliente] CHECK CONSTRAINT [FK_cliente_tipo_identidad]
GO
/****** Object:  ForeignKey [FK_cliente_estadia_cliente]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[cliente_estadia]  WITH CHECK ADD  CONSTRAINT [FK_cliente_estadia_cliente] FOREIGN KEY([cliente_id])
REFERENCES [GAME_OF_QUERYS].[cliente] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cliente_estadia] CHECK CONSTRAINT [FK_cliente_estadia_cliente]
GO
/****** Object:  ForeignKey [FK_cliente_estadia_estadia]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[cliente_estadia]  WITH CHECK ADD  CONSTRAINT [FK_cliente_estadia_estadia] FOREIGN KEY([estadia_id])
REFERENCES [GAME_OF_QUERYS].[estadia] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[cliente_estadia] CHECK CONSTRAINT [FK_cliente_estadia_estadia]
GO
/****** Object:  ForeignKey [FK_consumible_estadia_consumible]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[consumible_estadia]  WITH CHECK ADD  CONSTRAINT [FK_consumible_estadia_consumible] FOREIGN KEY([consumible_id])
REFERENCES [GAME_OF_QUERYS].[consumible] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[consumible_estadia] CHECK CONSTRAINT [FK_consumible_estadia_consumible]
GO
/****** Object:  ForeignKey [FK_consumible_estadia_estadia]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[consumible_estadia]  WITH CHECK ADD  CONSTRAINT [FK_consumible_estadia_estadia] FOREIGN KEY([estadia_id])
REFERENCES [GAME_OF_QUERYS].[estadia] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[consumible_estadia] CHECK CONSTRAINT [FK_consumible_estadia_estadia]
GO
/****** Object:  ForeignKey [FK_estadia_reserva]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[estadia]  WITH CHECK ADD  CONSTRAINT [FK_estadia_reserva] FOREIGN KEY([reserva_id])
REFERENCES [GAME_OF_QUERYS].[reserva] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[estadia] CHECK CONSTRAINT [FK_estadia_reserva]
GO
/****** Object:  ForeignKey [FK_factura_estadia]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_estadia] FOREIGN KEY([estadia_id])
REFERENCES [GAME_OF_QUERYS].[estadia] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[factura] CHECK CONSTRAINT [FK_factura_estadia]
GO
/****** Object:  ForeignKey [FK_factura_medio_de_pago]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_medio_de_pago] FOREIGN KEY([medio_de_pago_id])
REFERENCES [GAME_OF_QUERYS].[medio_de_pago] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[factura] CHECK CONSTRAINT [FK_factura_medio_de_pago]
GO
/****** Object:  ForeignKey [FK_habitacion_hotel]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[habitacion]  WITH CHECK ADD  CONSTRAINT [FK_habitacion_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[habitacion] CHECK CONSTRAINT [FK_habitacion_hotel]
GO
/****** Object:  ForeignKey [FK_habitacion_tipo_habitacion]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[habitacion]  WITH CHECK ADD  CONSTRAINT [FK_habitacion_tipo_habitacion] FOREIGN KEY([tipo_hab_id])
REFERENCES [GAME_OF_QUERYS].[tipo_habitacion] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[habitacion] CHECK CONSTRAINT [FK_habitacion_tipo_habitacion]
GO
/****** Object:  ForeignKey [FK_hotel_reg_hotel]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_reg]  WITH CHECK ADD  CONSTRAINT [FK_hotel_reg_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_reg] CHECK CONSTRAINT [FK_hotel_reg_hotel]
GO
/****** Object:  ForeignKey [FK_hotel_reg_regimen]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_reg]  WITH CHECK ADD  CONSTRAINT [FK_hotel_reg_regimen] FOREIGN KEY([reg_id])
REFERENCES [GAME_OF_QUERYS].[regimen] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_reg] CHECK CONSTRAINT [FK_hotel_reg_regimen]
GO
/****** Object:  ForeignKey [FK_hotel_usuario_rol_hotel]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol]  WITH CHECK ADD  CONSTRAINT [FK_hotel_usuario_rol_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol] CHECK CONSTRAINT [FK_hotel_usuario_rol_hotel]
GO
/****** Object:  ForeignKey [FK_hotel_usuario_rol_rol]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol]  WITH CHECK ADD  CONSTRAINT [FK_hotel_usuario_rol_rol] FOREIGN KEY([rol_id])
REFERENCES [GAME_OF_QUERYS].[rol] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol] CHECK CONSTRAINT [FK_hotel_usuario_rol_rol]
GO
/****** Object:  ForeignKey [FK_hotel_usuario_rol_usuario]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol]  WITH CHECK ADD  CONSTRAINT [FK_hotel_usuario_rol_usuario] FOREIGN KEY([usuario_id])
REFERENCES [GAME_OF_QUERYS].[usuario] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[hotel_usuario_rol] CHECK CONSTRAINT [FK_hotel_usuario_rol_usuario]
GO
/****** Object:  ForeignKey [FK_item_factura]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_factura] FOREIGN KEY([factura_id])
REFERENCES [GAME_OF_QUERYS].[factura] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[item] CHECK CONSTRAINT [FK_item_factura]
GO
/****** Object:  ForeignKey [FK_mantenimiento_hotel]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[mantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_mantenimiento_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[mantenimiento] CHECK CONSTRAINT [FK_mantenimiento_hotel]
GO
/****** Object:  ForeignKey [FK_reserva_cliente]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_cliente] FOREIGN KEY([cliente_id])
REFERENCES [GAME_OF_QUERYS].[cliente] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva] CHECK CONSTRAINT [FK_reserva_cliente]
GO
/****** Object:  ForeignKey [FK_reserva_estado_reserva]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_estado_reserva] FOREIGN KEY([estado_id])
REFERENCES [GAME_OF_QUERYS].[estado_reserva] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva] CHECK CONSTRAINT [FK_reserva_estado_reserva]
GO
/****** Object:  ForeignKey [FK_reserva_hotel]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_hotel] FOREIGN KEY([hotel_id])
REFERENCES [GAME_OF_QUERYS].[hotel] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva] CHECK CONSTRAINT [FK_reserva_hotel]
GO
/****** Object:  ForeignKey [FK_reserva_regimen]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_regimen] FOREIGN KEY([regimen_id])
REFERENCES [GAME_OF_QUERYS].[regimen] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva] CHECK CONSTRAINT [FK_reserva_regimen]
GO
/****** Object:  ForeignKey [FK_reserva_habitacion_habitacion]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva_habitacion]  WITH CHECK ADD  CONSTRAINT [FK_reserva_habitacion_habitacion] FOREIGN KEY([habitacion_id])
REFERENCES [GAME_OF_QUERYS].[habitacion] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva_habitacion] CHECK CONSTRAINT [FK_reserva_habitacion_habitacion]
GO
/****** Object:  ForeignKey [FK_reserva_habitacion_reserva]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[reserva_habitacion]  WITH CHECK ADD  CONSTRAINT [FK_reserva_habitacion_reserva] FOREIGN KEY([reserva_id])
REFERENCES [GAME_OF_QUERYS].[reserva] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[reserva_habitacion] CHECK CONSTRAINT [FK_reserva_habitacion_reserva]
GO
/****** Object:  ForeignKey [FK_rol_funcionalidad_funcionalidad]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_rol_funcionalidad_funcionalidad] FOREIGN KEY([funcionalidad_id])
REFERENCES [GAME_OF_QUERYS].[funcionalidad] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[rol_funcionalidad] CHECK CONSTRAINT [FK_rol_funcionalidad_funcionalidad]
GO
/****** Object:  ForeignKey [FK_rol_funcionalidad_rol]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_rol_funcionalidad_rol] FOREIGN KEY([rol_id])
REFERENCES [GAME_OF_QUERYS].[rol] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[rol_funcionalidad] CHECK CONSTRAINT [FK_rol_funcionalidad_rol]
GO
/****** Object:  ForeignKey [FK_usuario_tipo_identidad]    Script Date: 11/27/2014 19:26:45 ******/
ALTER TABLE [GAME_OF_QUERYS].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_tipo_identidad] FOREIGN KEY([tipo_identidad_id])
REFERENCES [GAME_OF_QUERYS].[tipo_identidad] ([id])
GO
ALTER TABLE [GAME_OF_QUERYS].[usuario] CHECK CONSTRAINT [FK_usuario_tipo_identidad]
GO
