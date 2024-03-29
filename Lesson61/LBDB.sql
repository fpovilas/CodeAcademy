USE [LithuanianBankDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2024-02-20 00:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[PK_ID] [int] NOT NULL,
	[Number] [nvarchar](18) NOT NULL,
	[PersonID] [nchar](11) NOT NULL,
	[BankID] [int] NOT NULL,
	[AmountOfMoney] [money] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 2024-02-20 00:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[ID_PK] [int] NOT NULL,
	[Bank] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[ID_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 2024-02-20 00:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PK_ID] [nchar](11) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](11) NULL,
	[AccountID] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (1, N'LT3700001255231111', N'35409115555', 1, 100.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (2, N'LT3700125384561234', N'35409115555', 4, 1000.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (3, N'LT9541853698745231', N'39604309685', 5, 963.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (4, N'LT1241254198523231', N'49211214578', 3, 9600.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (5, N'LT1593853641255231', N'49211214578', 1, 93.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (6, N'LT9635538523549874', N'48209264563', 2, 63.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (7, N'LT9636859631748523', N'48209264563', 4, 1000.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (8, N'LT3506857412455231', N'37512123695', 3, 2500.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (9, N'LT3700858528984331', N'37512123695', 3, 452.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (10, N'LT2541173598764931', N'35409115555', 4, 1953.0000)
INSERT [dbo].[Account] ([PK_ID], [Number], [PersonID], [BankID], [AmountOfMoney]) VALUES (11, N'LT1400538536789310', N'35409115555', 5, 1236.0000)
GO
INSERT [dbo].[Bank] ([ID_PK], [Bank]) VALUES (1, N'Swed      ')
INSERT [dbo].[Bank] ([ID_PK], [Bank]) VALUES (2, N'SB        ')
INSERT [dbo].[Bank] ([ID_PK], [Bank]) VALUES (3, N'Citadele  ')
INSERT [dbo].[Bank] ([ID_PK], [Bank]) VALUES (4, N'Revolut   ')
INSERT [dbo].[Bank] ([ID_PK], [Bank]) VALUES (5, N'Danske    ')
GO
INSERT [dbo].[Person] ([PK_ID], [FirstName], [LastName], [PhoneNumber], [AccountID]) VALUES (N'35409115555', N'Petras', N'Petraitis', N'37066611221', 1)
INSERT [dbo].[Person] ([PK_ID], [FirstName], [LastName], [PhoneNumber], [AccountID]) VALUES (N'37512123695', N'Antanas', N'Antanaitis', N'37062341963', 5)
INSERT [dbo].[Person] ([PK_ID], [FirstName], [LastName], [PhoneNumber], [AccountID]) VALUES (N'39604309685', N'Jonas', N'Jonaitis', N'37065231452', 2)
INSERT [dbo].[Person] ([PK_ID], [FirstName], [LastName], [PhoneNumber], [AccountID]) VALUES (N'48209264563', N'Luka', N'Lukaite', N'37060025789', 4)
INSERT [dbo].[Person] ([PK_ID], [FirstName], [LastName], [PhoneNumber], [AccountID]) VALUES (N'49211214578', N'Zita', N'Zitaite', N'37069574103', 3)
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Bank] FOREIGN KEY([BankID])
REFERENCES [dbo].[Bank] ([ID_PK])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Bank]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PK_ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Person]
GO
