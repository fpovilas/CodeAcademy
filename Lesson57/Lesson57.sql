USE [master]
GO
/****** Object:  Database [NewDB]    Script Date: 2024-02-13 19:53:54 ******/
CREATE DATABASE [NewDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NewDB', FILENAME = N'D:\Users\Povka\NewDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NewDB_log', FILENAME = N'D:\Users\Povka\NewDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NewDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NewDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NewDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NewDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NewDB] SET  MULTI_USER 
GO
ALTER DATABASE [NewDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NewDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NewDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NewDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NewDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NewDB] SET QUERY_STORE = OFF
GO
USE [NewDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2024-02-13 19:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Name] [varchar](255) NOT NULL,
	[ManagerPersonalCode] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2024-02-13 19:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[PersonalCode] [char](11) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[StartDate] [date] NULL,
	[BirthDate] [date] NULL,
	[Position] [varchar](255) NULL,
	[DepartmentName] [varchar](255) NULL,
	[ProjectID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2024-02-13 19:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ID] [int] NOT NULL,
	[Name] [varchar](255) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([Name], [ManagerPersonalCode]) VALUES (N'Java', N'48509141175')
INSERT [dbo].[Department] ([Name], [ManagerPersonalCode]) VALUES (N'Testing', N'38804172782')
INSERT [dbo].[Department] ([Name], [ManagerPersonalCode]) VALUES (N'C#', N'38904172782')
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38101122335', N'Petras', N'Petraitis', CAST(N'2009-10-30' AS Date), CAST(N'1981-01-11' AS Date), N'Tester', N'Testing', 1)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38010101234', N'Jonas', N'Jonaitis', CAST(N'2007-05-30' AS Date), CAST(N'1980-10-10' AS Date), N'Developer', N'Java', 2)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38103201435', N'Rimas', N'Plekaitis', CAST(N'2009-10-30' AS Date), CAST(N'1981-03-20' AS Date), N'Developer', N'Java', 3)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'48509141175', N'Zita', N'Lietuvaite', CAST(N'2012-06-15' AS Date), CAST(N'1985-09-14' AS Date), N'ProjectManager', N'Java', 2)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'48410121275', N'Jurga', N'Jurgaityte', CAST(N'2011-02-12' AS Date), CAST(N'1984-10-12' AS Date), N'Developer', N'C#', 1)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38807201234', N'Giedrius', N'Sabutis', CAST(N'2009-01-21' AS Date), CAST(N'1988-07-20' AS Date), N'Tester', N'Testing', 2)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38807291234', N'Regimantas', N'Sabonis', CAST(N'2013-01-21' AS Date), CAST(N'1988-07-29' AS Date), N'Tester', N'Testing', 3)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38609191234', N'Saulius', N'Sabonis', CAST(N'2013-01-21' AS Date), CAST(N'1986-09-19' AS Date), N'Tester', N'Testing', 3)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38109197598', N'Justas', N'Sabonis', CAST(N'2011-12-17' AS Date), CAST(N'1986-09-19' AS Date), N'Tester', N'Testing', 1)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38503142412', N'Jonas', N'Kalnas', CAST(N'2009-05-11' AS Date), CAST(N'1985-03-24' AS Date), N'Developer', N'Java', 1)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'39003142412', N'Stasys', N'Sakalas', CAST(N'2009-05-11' AS Date), CAST(N'1990-03-24' AS Date), N'Developer', N'Java', 3)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'37803142412', N'Povilas', N'Vakalas', CAST(N'2012-11-11' AS Date), CAST(N'1978-03-14' AS Date), N'Developer', N'C#', 2)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38804172782', N'Deivydas', N'Piliukas', CAST(N'2011-12-11' AS Date), CAST(N'1988-04-17' AS Date), N'ProjectManager', N'Testing', 2)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38904172782', N'Kestas', N'Liutas', CAST(N'2012-12-11' AS Date), CAST(N'1989-04-17' AS Date), N'ProjectManager', N'C#', 1)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38901228523', N'temporary', N'actor', CAST(N'2009-01-22' AS Date), CAST(N'1989-01-22' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'39705067782', N'Petras', N'Petrauskas', CAST(N'2024-01-01' AS Date), CAST(N'1997-05-06' AS Date), N'Developer', N'C#', 2)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'39711067852', N'Lukas', N'Antanaitis', CAST(N'2023-01-01' AS Date), CAST(N'1997-11-06' AS Date), N'Tester', N'C#', 1)
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'39703307992', N'Sasha', N'Antanaitis', CAST(N'2024-01-01' AS Date), CAST(N'1997-05-06' AS Date), N'Tester', N'C#', 3)
GO
INSERT [dbo].[Project] ([ID], [Name]) VALUES (1, N'Izola')
INSERT [dbo].[Project] ([ID], [Name]) VALUES (2, N'RegistryCenter')
INSERT [dbo].[Project] ([ID], [Name]) VALUES (3, N'Kaunas')
GO
USE [master]
GO
ALTER DATABASE [NewDB] SET  READ_WRITE 
GO
