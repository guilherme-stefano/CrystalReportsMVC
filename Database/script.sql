/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2014 (12.0.2000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [CustomerDB]    Script Date: 08/10/2018 17:20:11 ******/
CREATE DATABASE [CustomerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CustomerDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CustomerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CustomerDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CustomerDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerDB] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CustomerDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CustomerDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 08/10/2018 17:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] NOT NULL,
	[CustomerName] [varchar](50) NULL,
	[CustomerEmail] [varchar](50) NULL,
	[CustomerZipCode] [int] NULL,
	[CustomerCountry] [varchar](50) NULL,
	[CustomerCity] [varchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMenu]    Script Date: 08/10/2018 17:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMenu](
	[id] [int] NOT NULL,
	[idCustomer] [int] NULL,
	[idMenu] [int] NULL,
 CONSTRAINT [PK_CustomerMenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 08/10/2018 17:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dia] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuProduto]    Script Date: 08/10/2018 17:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuProduto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMenu] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[quantidade] [int] NULL,
 CONSTRAINT [PK_MenuProduto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 08/10/2018 17:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([id], [CustomerName], [CustomerEmail], [CustomerZipCode], [CustomerCountry], [CustomerCity]) VALUES (1, N'Teste', N'teste@teste', 12, N'Teste', N'Teste')
INSERT [dbo].[Customer] ([id], [CustomerName], [CustomerEmail], [CustomerZipCode], [CustomerCountry], [CustomerCity]) VALUES (2, N'Teste 2', N'teste3@teste3', 12, N'Teste', N'Teste')
INSERT [dbo].[CustomerMenu] ([id], [idCustomer], [idMenu]) VALUES (1, 1, 1)
INSERT [dbo].[CustomerMenu] ([id], [idCustomer], [idMenu]) VALUES (2, 1, 2)
INSERT [dbo].[CustomerMenu] ([id], [idCustomer], [idMenu]) VALUES (3, 1, 3)
INSERT [dbo].[CustomerMenu] ([id], [idCustomer], [idMenu]) VALUES (4, 2, 4)
INSERT [dbo].[CustomerMenu] ([id], [idCustomer], [idMenu]) VALUES (5, 1, 7)
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([id], [dia]) VALUES (1, 1)
INSERT [dbo].[Menu] ([id], [dia]) VALUES (2, 2)
INSERT [dbo].[Menu] ([id], [dia]) VALUES (3, 3)
INSERT [dbo].[Menu] ([id], [dia]) VALUES (4, 1)
INSERT [dbo].[Menu] ([id], [dia]) VALUES (5, 2)
INSERT [dbo].[Menu] ([id], [dia]) VALUES (6, 3)
INSERT [dbo].[Menu] ([id], [dia]) VALUES (7, 5)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MenuProduto] ON 

INSERT [dbo].[MenuProduto] ([Id], [IdMenu], [IdProduto], [quantidade]) VALUES (1, 1, 1, 2)
INSERT [dbo].[MenuProduto] ([Id], [IdMenu], [IdProduto], [quantidade]) VALUES (2, 2, 2, 3)
INSERT [dbo].[MenuProduto] ([Id], [IdMenu], [IdProduto], [quantidade]) VALUES (3, 4, 3, 1)
INSERT [dbo].[MenuProduto] ([Id], [IdMenu], [IdProduto], [quantidade]) VALUES (5, 4, 2, 1)
INSERT [dbo].[MenuProduto] ([Id], [IdMenu], [IdProduto], [quantidade]) VALUES (6, 3, 3, 1)
INSERT [dbo].[MenuProduto] ([Id], [IdMenu], [IdProduto], [quantidade]) VALUES (7, 7, 4, 1)
SET IDENTITY_INSERT [dbo].[MenuProduto] OFF
SET IDENTITY_INSERT [dbo].[Produto] ON 

INSERT [dbo].[Produto] ([id], [Nome]) VALUES (1, N'Pão')
INSERT [dbo].[Produto] ([id], [Nome]) VALUES (2, N'Queijo')
INSERT [dbo].[Produto] ([id], [Nome]) VALUES (3, N'Peito Peru')
INSERT [dbo].[Produto] ([id], [Nome]) VALUES (4, N'Leite')
SET IDENTITY_INSERT [dbo].[Produto] OFF
ALTER TABLE [dbo].[CustomerMenu]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMenu_Customer] FOREIGN KEY([idCustomer])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[CustomerMenu] CHECK CONSTRAINT [FK_CustomerMenu_Customer]
GO
ALTER TABLE [dbo].[CustomerMenu]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMenu_Menu] FOREIGN KEY([idMenu])
REFERENCES [dbo].[Menu] ([id])
GO
ALTER TABLE [dbo].[CustomerMenu] CHECK CONSTRAINT [FK_CustomerMenu_Menu]
GO
ALTER TABLE [dbo].[MenuProduto]  WITH CHECK ADD  CONSTRAINT [FK_MenuProduto_Menu] FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([id])
GO
ALTER TABLE [dbo].[MenuProduto] CHECK CONSTRAINT [FK_MenuProduto_Menu]
GO
ALTER TABLE [dbo].[MenuProduto]  WITH CHECK ADD  CONSTRAINT [FK_MenuProduto_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([id])
GO
ALTER TABLE [dbo].[MenuProduto] CHECK CONSTRAINT [FK_MenuProduto_Produto]
GO
USE [master]
GO
ALTER DATABASE [CustomerDB] SET  READ_WRITE 
GO
