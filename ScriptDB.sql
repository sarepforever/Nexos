USE [master]
GO
/****** Object:  Database [Biblioteca]    Script Date: 13/03/2021 10:23:51 p. m. ******/
CREATE DATABASE [Biblioteca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Biblioteca', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Biblioteca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Biblioteca_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Biblioteca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Biblioteca] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Biblioteca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Biblioteca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Biblioteca] SET ARITHABORT OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Biblioteca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Biblioteca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Biblioteca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Biblioteca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Biblioteca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Biblioteca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Biblioteca] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Biblioteca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Biblioteca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Biblioteca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Biblioteca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Biblioteca] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Biblioteca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Biblioteca] SET RECOVERY FULL 
GO
ALTER DATABASE [Biblioteca] SET  MULTI_USER 
GO
ALTER DATABASE [Biblioteca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Biblioteca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Biblioteca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Biblioteca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Biblioteca] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Biblioteca', N'ON'
GO
ALTER DATABASE [Biblioteca] SET QUERY_STORE = OFF
GO
USE [Biblioteca]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/03/2021 10:23:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 13/03/2021 10:23:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[idAutor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[ciudad] [varchar](50) NOT NULL,
	[mail] [varchar](80) NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[idAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editoria]    Script Date: 13/03/2021 10:23:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editoria](
	[idEditorial] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](20) NOT NULL,
	[mail] [varchar](80) NOT NULL,
	[numLibros] [int] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_Editoria] PRIMARY KEY CLUSTERED 
(
	[idEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 13/03/2021 10:23:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[idLibro] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](80) NOT NULL,
	[ano] [int] NOT NULL,
	[genero] [varchar](50) NOT NULL,
	[numPag] [int] NOT NULL,
	[idEditorial] [int] NOT NULL,
	[idAutor] [int] NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[idLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Libro_idAutor]    Script Date: 13/03/2021 10:23:51 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Libro_idAutor] ON [dbo].[Libro]
(
	[idAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Libro_idEditorial]    Script Date: 13/03/2021 10:23:51 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Libro_idEditorial] ON [dbo].[Libro]
(
	[idEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Autor] ADD  DEFAULT (CONVERT([bit],(1))) FOR [activo]
GO
ALTER TABLE [dbo].[Editoria] ADD  DEFAULT ((-1)) FOR [numLibros]
GO
ALTER TABLE [dbo].[Editoria] ADD  DEFAULT (CONVERT([bit],(1))) FOR [activo]
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Autor_idAutor] FOREIGN KEY([idAutor])
REFERENCES [dbo].[Autor] ([idAutor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Autor_idAutor]
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Editoria_idEditorial] FOREIGN KEY([idEditorial])
REFERENCES [dbo].[Editoria] ([idEditorial])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Editoria_idEditorial]
GO
USE [master]
GO
ALTER DATABASE [Biblioteca] SET  READ_WRITE 
GO
