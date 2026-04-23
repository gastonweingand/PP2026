USE [Practicas2026]
GO
/****** Object:  User [practicas2026]    Script Date: 23/4/2026 20:02:03 ******/
CREATE USER [practicas2026] FOR LOGIN [practicas2026] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [practicas2026]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 23/4/2026 20:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](100) NULL,
	[CUIT] [varchar](11) NULL,
	[FechaNacimiento] [date] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [CUIT], [FechaNacimiento]) VALUES (N'aba2c341-0a3d-f111-acce-909c4ad14885', N'Gaston', N'2031232312', CAST(N'1984-08-13' AS Date))
GO
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [CUIT], [FechaNacimiento]) VALUES (N'8064dd58-0a3d-f111-acce-909c4ad14885', N'Matias', N'2034232312', CAST(N'2000-08-13' AS Date))
GO
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [CUIT], [FechaNacimiento]) VALUES (N'90fbc7b2-663f-f111-acd0-909c4ad14885', N'Jorgito', N'20123456789', CAST(N'2006-04-23' AS Date))
GO
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [CUIT], [FechaNacimiento]) VALUES (N'926f81f5-663f-f111-acd0-909c4ad14885', N'Testing', N'201234522', CAST(N'2000-04-23' AS Date))
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_IdCliente]  DEFAULT (newsequentialid()) FOR [IdCliente]
GO
USE [master]
GO
ALTER DATABASE [Practicas2026] SET  READ_WRITE 
GO
