create database ParcialRecetas

use ParcialRecetas

GO
/****** Object:  Table [dbo].[Recetas]    Script Date: 09/29/2022 09:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recetas](
	[id_receta] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[cheff] [varchar](100) NULL,
	[tipo_receta] [int] NOT NULL,
 CONSTRAINT [PK_Recetas] PRIMARY KEY CLUSTERED 
(
	[id_receta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Recetas] ON
INSERT [dbo].[Recetas] ([id_receta], [nombre], [cheff], [tipo_receta]) VALUES (2, N'TEST', N'Test Cheff', 2)
INSERT [dbo].[Recetas] ([id_receta], [nombre], [cheff], [tipo_receta]) VALUES (3, N'Receta de prueba', N'TEST', 3)
INSERT [dbo].[Recetas] ([id_receta], [nombre], [cheff], [tipo_receta]) VALUES (4, N'RECETA ACME', N'132', 2)
SET IDENTITY_INSERT [dbo].[Recetas] OFF
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 09/29/2022 09:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[id_ingrediente] [int] NOT NULL,
	[n_ingrediente] [varchar](50) NOT NULL,
	[unidad_medida] [varchar](50) NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[id_ingrediente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [unidad_medida]) VALUES (1, N'Sal', N'gramos')
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [unidad_medida]) VALUES (2, N'Pimienta', N'gramos')
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [unidad_medida]) VALUES (3, N'Agua', N'cm3')
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [unidad_medida]) VALUES (4, N'Aceite', N'cm3')
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [unidad_medida]) VALUES (5, N'carne', N'gramos')
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [unidad_medida]) VALUES (6, N'caldo', N'cm3')
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [unidad_medida]) VALUES (7, N'Azucar', N'gramos')
/****** Object:  Table [dbo].[Detalles_Receta]    Script Date: 09/29/2022 09:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Receta](
	[id_receta] [int] NOT NULL,
	[id_ingrediente] [int] NOT NULL,
	[cantidad] [numeric](5, 2) NOT NULL,
 CONSTRAINT [PK_Detalles_Receta] PRIMARY KEY CLUSTERED 
(
	[id_receta] ASC,
	[id_ingrediente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (2, 4, CAST(1.00 AS Numeric(5, 2)))
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (2, 5, CAST(5.00 AS Numeric(5, 2)))
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (2, 7, CAST(5.00 AS Numeric(5, 2)))
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (3, 2, CAST(1.00 AS Numeric(5, 2)))
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (3, 4, CAST(1.00 AS Numeric(5, 2)))
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (3, 6, CAST(1.00 AS Numeric(5, 2)))
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (4, 2, CAST(1.00 AS Numeric(5, 2)))
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (4, 4, CAST(1.00 AS Numeric(5, 2)))
INSERT [dbo].[Detalles_Receta] ([id_receta], [id_ingrediente], [cantidad]) VALUES (4, 5, CAST(1.00 AS Numeric(5, 2)))
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_INGREDIENTES]    Script Date: 09/29/2022 09:41:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_INGREDIENTES]
AS
BEGIN
	
	SELECT * from Ingredientes ORDER BY 2;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PROXIMO_ID]    Script Date: 09/29/2022 09:41:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PROXIMO_ID] 
	@next int output
AS
BEGIN
	SET @next = (SELECT MAX(id_receta)+1  FROM Recetas);

END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_RECETA]    Script Date: 09/29/2022 09:41:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_RECETA] 
	@tipo_receta int,
	@nombre varchar(50),
	@cheff varchar(100), 
	@id int output
AS
BEGIN
	INSERT INTO Recetas (nombre, cheff , tipo_receta)
    VALUES (@nombre, @cheff, @tipo_receta );
    
    SET @id = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLES]    Script Date: 09/29/2022 09:41:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLES] 
	@id_receta int,
	@id_ingrediente int, 
	@cantidad int
AS
BEGIN
	INSERT INTO DETALLES_RECETA(id_receta,id_ingrediente,cantidad)
    VALUES (@id_receta, @id_ingrediente, @cantidad);
  
END
GO
/****** Object:  ForeignKey [FK_Detalles_Receta_Ingredientes]    Script Date: 09/29/2022 09:41:49 ******/
ALTER TABLE [dbo].[Detalles_Receta]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Receta_Ingredientes] FOREIGN KEY([id_ingrediente])
REFERENCES [dbo].[Ingredientes] ([id_ingrediente])
GO
ALTER TABLE [dbo].[Detalles_Receta] CHECK CONSTRAINT [FK_Detalles_Receta_Ingredientes]
GO
/****** Object:  ForeignKey [FK_Ingredientes_Ingredientes]    Script Date: 09/29/2022 09:41:49 ******/
ALTER TABLE [dbo].[Ingredientes]  WITH CHECK ADD  CONSTRAINT [FK_Ingredientes_Ingredientes] FOREIGN KEY([id_ingrediente])
REFERENCES [dbo].[Ingredientes] ([id_ingrediente])
GO
ALTER TABLE [dbo].[Ingredientes] CHECK CONSTRAINT [FK_Ingredientes_Ingredientes]
GO
