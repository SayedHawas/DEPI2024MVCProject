Create Database [WebApiCoreDb]
GO
USE [WebApiCoreDb]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/12/2024 8:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Job] [nvarchar](max) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Job], [Salary]) VALUES (1, N'Mariam ', N'Mariam@yahoo.com', N'Eng', CAST(20000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Job], [Salary]) VALUES (2, N'Retaj', N'retaj@yahoo.com', N'DR', CAST(25000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Job], [Salary]) VALUES (5, N'Zayed', N'user@example.com', N'Developer', CAST(19000.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Job], [Salary]) VALUES (6, N'string', N'user@example.com', N'string', CAST(999999.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Job], [Salary]) VALUES (7, N'Tamer', N'tamer@hotmail.com', N'Eng', CAST(25000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Job], [Salary]) VALUES (9, N'Ali', N'user@example.com', N'Eng', CAST(26000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Job], [Salary]) VALUES (11, N'Ahmed', N'Ahmed@hotmail.com', N'Eng', CAST(10000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
