USE [NewDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2024-02-13 19:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Name] [varchar](255) NOT NULL,
	[ManagerPersonalCode] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2024-02-13 19:55:47 ******/
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
/****** Object:  Table [dbo].[Project]    Script Date: 2024-02-13 19:55:47 ******/
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
GO
INSERT [dbo].[Department] ([Name], [ManagerPersonalCode]) VALUES (N'Testing', N'38804172782')
GO
INSERT [dbo].[Department] ([Name], [ManagerPersonalCode]) VALUES (N'C#', N'38904172782')
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38101122335', N'Petras', N'Petraitis', CAST(N'2009-10-30' AS Date), CAST(N'1981-01-11' AS Date), N'Tester', N'Testing', 1)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38010101234', N'Jonas', N'Jonaitis', CAST(N'2007-05-30' AS Date), CAST(N'1980-10-10' AS Date), N'Developer', N'Java', 2)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38103201435', N'Rimas', N'Plekaitis', CAST(N'2009-10-30' AS Date), CAST(N'1981-03-20' AS Date), N'Developer', N'Java', 3)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'48509141175', N'Zita', N'Lietuvaite', CAST(N'2012-06-15' AS Date), CAST(N'1985-09-14' AS Date), N'ProjectManager', N'Java', 2)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'48410121275', N'Jurga', N'Jurgaityte', CAST(N'2011-02-12' AS Date), CAST(N'1984-10-12' AS Date), N'Developer', N'C#', 1)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38807201234', N'Giedrius', N'Sabutis', CAST(N'2009-01-21' AS Date), CAST(N'1988-07-20' AS Date), N'Tester', N'Testing', 2)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38807291234', N'Regimantas', N'Sabonis', CAST(N'2013-01-21' AS Date), CAST(N'1988-07-29' AS Date), N'Tester', N'Testing', 3)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38609191234', N'Saulius', N'Sabonis', CAST(N'2013-01-21' AS Date), CAST(N'1986-09-19' AS Date), N'Tester', N'Testing', 3)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38109197598', N'Justas', N'Sabonis', CAST(N'2011-12-17' AS Date), CAST(N'1986-09-19' AS Date), N'Tester', N'Testing', 1)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38503142412', N'Jonas', N'Kalnas', CAST(N'2009-05-11' AS Date), CAST(N'1985-03-24' AS Date), N'Developer', N'Java', 1)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'39003142412', N'Stasys', N'Sakalas', CAST(N'2009-05-11' AS Date), CAST(N'1990-03-24' AS Date), N'Developer', N'Java', 3)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'37803142412', N'Povilas', N'Vakalas', CAST(N'2012-11-11' AS Date), CAST(N'1978-03-14' AS Date), N'Developer', N'C#', 2)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38804172782', N'Deivydas', N'Piliukas', CAST(N'2011-12-11' AS Date), CAST(N'1988-04-17' AS Date), N'ProjectManager', N'Testing', 2)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38904172782', N'Kestas', N'Liutas', CAST(N'2012-12-11' AS Date), CAST(N'1989-04-17' AS Date), N'ProjectManager', N'C#', 1)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'38901228523', N'temporary', N'actor', CAST(N'2009-01-22' AS Date), CAST(N'1989-01-22' AS Date), NULL, NULL, NULL)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'39705067782', N'Petras', N'Petrauskas', CAST(N'2024-01-01' AS Date), CAST(N'1997-05-06' AS Date), N'Developer', N'C#', 2)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'39711067852', N'Lukas', N'Antanaitis', CAST(N'2023-01-01' AS Date), CAST(N'1997-11-06' AS Date), N'Tester', N'C#', 1)
GO
INSERT [dbo].[Employee] ([PersonalCode], [FirstName], [LastName], [StartDate], [BirthDate], [Position], [DepartmentName], [ProjectID]) VALUES (N'39703307992', N'Sasha', N'Antanaitis', CAST(N'2024-01-01' AS Date), CAST(N'1997-05-06' AS Date), N'Tester', N'C#', 3)
GO
INSERT [dbo].[Project] ([ID], [Name]) VALUES (1, N'Izola')
GO
INSERT [dbo].[Project] ([ID], [Name]) VALUES (2, N'RegistryCenter')
GO
INSERT [dbo].[Project] ([ID], [Name]) VALUES (3, N'Kaunas')
GO
