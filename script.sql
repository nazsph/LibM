USE [LibraryDatabase]
GO
/****** Object:  Table [dbo].[BookTable]    Script Date: 7.01.2023 20:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookTable](
	[BookName] [varchar](50) NULL,
	[BookAuthor] [varchar](50) NULL,
	[BookGender] [varchar](50) NULL,
	[BookYear] [varchar](50) NULL,
	[BookCountry] [varchar](50) NULL,
	[BookLanguage] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibrariansTable]    Script Date: 7.01.2023 20:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibrariansTable](
	[LibrarianID] [varchar](50) NULL,
	[LibrarianName] [varchar](50) NULL,
	[LibrarianLastName] [varchar](50) NULL,
	[LibrarianGender] [varchar](50) NULL,
	[LibrarianDOB] [datetime] NULL,
	[LibrarianUsername] [varchar](50) NULL,
	[LibrarianPassword] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[BookTable] ([BookName], [BookAuthor], [BookGender], [BookYear], [BookCountry], [BookLanguage]) VALUES (N'Jenseits von Gut und Böse', N'Friedrich Nietzsche', N'Philosophy', N'1869', N'Deutsch', N'256')
INSERT [dbo].[BookTable] ([BookName], [BookAuthor], [BookGender], [BookYear], [BookCountry], [BookLanguage]) VALUES (N'A Thousand Splendid Suns', N'Khaled Hosseini', N'Literature', N'2007', N'America', N'430')
INSERT [dbo].[BookTable] ([BookName], [BookAuthor], [BookGender], [BookYear], [BookCountry], [BookLanguage]) VALUES (N'Pride and Prejudice', N'Jane Austen', N'Romance', N'1813', N'United Kingdom', N'424')
INSERT [dbo].[BookTable] ([BookName], [BookAuthor], [BookGender], [BookYear], [BookCountry], [BookLanguage]) VALUES (N'White Nights', N'Dostoyevski', N'Classic', N'1848', N'Russia', N'200')
INSERT [dbo].[BookTable] ([BookName], [BookAuthor], [BookGender], [BookYear], [BookCountry], [BookLanguage]) VALUES (N'Nutuk', N'Atatürk', N'Literature', N'1927', N'Turkey', N'543')
INSERT [dbo].[BookTable] ([BookName], [BookAuthor], [BookGender], [BookYear], [BookCountry], [BookLanguage]) VALUES (N'Les Miserables', N'Victor Hugo', N'Classic', N'1862', N'France', N'1724')
GO
INSERT [dbo].[LibrariansTable] ([LibrarianID], [LibrarianName], [LibrarianLastName], [LibrarianGender], [LibrarianDOB], [LibrarianUsername], [LibrarianPassword]) VALUES (N'12345678912', N'Ayşe', N'Yılmaz', N'Female', CAST(N'2000-01-01T21:27:49.000' AS DateTime), N'a', N'1')
INSERT [dbo].[LibrariansTable] ([LibrarianID], [LibrarianName], [LibrarianLastName], [LibrarianGender], [LibrarianDOB], [LibrarianUsername], [LibrarianPassword]) VALUES (N'98765432109', N'Ali', N'Aydın', N'Male', CAST(N'2001-10-12T21:28:33.000' AS DateTime), N'ali', N'12')
INSERT [dbo].[LibrariansTable] ([LibrarianID], [LibrarianName], [LibrarianLastName], [LibrarianGender], [LibrarianDOB], [LibrarianUsername], [LibrarianPassword]) VALUES (N'74185296312', N'Naz', N'Sipahi', N'Female', CAST(N'2002-06-06T21:29:32.000' AS DateTime), N'Naz', N'1234')
INSERT [dbo].[LibrariansTable] ([LibrarianID], [LibrarianName], [LibrarianLastName], [LibrarianGender], [LibrarianDOB], [LibrarianUsername], [LibrarianPassword]) VALUES (N'96385274185', N'Ahmet', N'Çoban', N'Male', CAST(N'1990-05-01T21:31:17.000' AS DateTime), N'çbn', N'1990')
INSERT [dbo].[LibrariansTable] ([LibrarianID], [LibrarianName], [LibrarianLastName], [LibrarianGender], [LibrarianDOB], [LibrarianUsername], [LibrarianPassword]) VALUES (N'75395245896', N'Mehmet', N'Karahanlı', N'Male', CAST(N'1960-06-01T16:44:55.000' AS DateTime), N'KurtlarVadisi', N'0')
INSERT [dbo].[LibrariansTable] ([LibrarianID], [LibrarianName], [LibrarianLastName], [LibrarianGender], [LibrarianDOB], [LibrarianUsername], [LibrarianPassword]) VALUES (N'85296374136', N'Zeynep', N'Kara', N'Female', CAST(N'2002-05-10T21:50:17.000' AS DateTime), N'kara', N'2002')
GO
