﻿CREATE TABLE [dbo].[BooksDetails](
	[BookDetailsID]		[INT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[BookID]			[INT] REFERENCES dbo.Books(BookID)NOT NULL,
	[BookCode]			[VARCHAR](15) NULL,		
	[Price]				[DECIMAL](6, 2) NOT NULL,
	[Pages]				[SMALLINT] NULL,	
	[PublisherID]		[SMALLINT] references dbo.Publishers(PublisherID)not NULL,
	[NoofCopy]			[TINYINT] NOT NULL,
	[BookFormat]		[TINYINT] references dbo.BookFormat(BookFormatID)not NULL,
	[ImgBookSmallFS]	[VARCHAR](60) NULL,
	[ImgBookSmallBS]	[VARCHAR](60) NULL,
	[ImgBookLarge]		[VARCHAR](60) NULL,
	[ISBN13]			[VARCHAR](17) NULL,
	[FirstEdition]		[VARCHAR](10) NULL,
	[CurrentEdition]	[VARCHAR](10) NULL,
	[Dimensions]		[VARCHAR](14) NULL,
	[CoverDesign]		[NVARCHAR](30),	
	[CoverFormat]		[NVARCHAR](30),	
	[IsKarkaBook]		[BIT]	DEFAULT 'FALSE' NULL,
	[EnteredBy]			[TINYINT] references dbo.AdminUser(AdminUserID) NOT NULL,
	[CreatedDate]		[DATE] default getdate(),
	[ModifiedDate]		[DATE] NULL,
	[RecStatus]			[CHAR](1) default 'A'

)

GO
GO
SET IDENTITY_INSERT [dbo].[BooksDetails] ON 
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (1, 339, N'', CAST(400.00 AS Decimal(6, 2)), 655, 513, 1, 4, N'Romapurip-Paandiyan - FS.jpg', N'', N'Romapurip-Paandiyan-L.jpg', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (2, 391, N'', CAST(55.00 AS Decimal(6, 2)), 279, 513, 1, 5, N'Kalaignar-Sirukathaigal.jpg', N'', N'Kalaignar-Sirukathaigal.jpg', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (3, 333, N'', CAST(40.00 AS Decimal(6, 2)), 125, 513, 1, 5, N'oru-maram-pooththadhu-FS.png', N'', N'oru-maram-pooththadhu-B.png', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (4, 378, N'', CAST(300.00 AS Decimal(6, 2)), 447, 513, 1, 4, N'Kalaignarin-kavithaigal-FS.jpg', N'', N'Kalaignarin-Kavithaigal-B.jpg', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (5, 408, N'', CAST(20.00 AS Decimal(6, 2)), 64, 513, 1, 5, N'Nachu-Koppai-FS.png', N'', N'Nachu-Koppai-LI.png', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (6, 433, N'', CAST(50.00 AS Decimal(6, 2)), 105, 513, 1, 5, N'Manokara-S.jpg', N'', N'Manokara-L.jpg', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (7, 398, N'', CAST(36.00 AS Decimal(6, 2)), 192, 513, 1, 5, N'Iniyavai_Irubadhu.jpg', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (8, 400, N'', CAST(675.00 AS Decimal(6, 2)), 755, 413, 1, 4, N'Nenjukku-Neethi-Part-1.jpg', N'', N'', N'', N'Dec 1975', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (9, 363, N'', CAST(40.00 AS Decimal(6, 2)), 0, 513, 1, 5, N'Pesum_Kalai_Valarppom.jpg', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (10, 499, N'', CAST(40.00 AS Decimal(6, 2)), 48, 413, 1, 5, N'Mozhiporil_Oru_Kalam-SI.jpg', N'', N'Mozhiporil_Oru_Kalam-LI.jpg', N'', N'June 200', N'', N'', N'', N'', 0, 1, CAST(N'2023-01-02' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (11, 429, N'', CAST(45.00 AS Decimal(6, 2)), 80, 413, 1, 5, N'Ilaya Samudhayam Elugavea -FS.jpg', N'', N'', N'', N'Dec 1996', N'', N'', N'', N'', 0, 1, CAST(N'2023-01-02' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (12, 406, N'', CAST(210.00 AS Decimal(6, 2)), 365, 413, 1, 5, N'Kaiyil Alliya Kadal-FS.jpg', N'', N'Kaiyil Alliya Kadal_L.jpg', N'', N'Jun 1998', N'', N'', N'', N'', 0, 1, CAST(N'2023-01-02' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (13, 425, N'', CAST(200.00 AS Decimal(6, 2)), 224, 573, 1, 4, N'Sindhanaiyum-Seyalum.jpg', N'', N'Sindhanaiyum-Seyalum.jpg', N'', N'June 200', N'May 2017', N'', N'', N'', 0, 1, CAST(N'2023-01-10' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (14, 345, N'', CAST(600.00 AS Decimal(6, 2)), 484, 413, 1, 4, N'sangath tamizh-FS.jpg', N'', N'', N'', N'Oct 1987', N'Apr 2017', N'', N'', N'', 0, 1, CAST(N'2023-05-29' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (15, 343, N'', CAST(250.00 AS Decimal(6, 2)), 383, 573, 1, 4, N'Kalaingarin-Kavithai-Nadayil-Karkiyin-Thaai.jpg', N'', N'', N'', N'Jun 2004', N'June 2010', N'', N'', N'', 0, 1, CAST(N'2023-05-29' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (16, 510, N'', CAST(250.00 AS Decimal(6, 2)), 312, 714, 1, 5, N'Nilam-Poothu-Malarntha-Naal.jpeg', N'', N'', N'978-93-84598-23-5', N'May 2016', N'', N'', N'', N'', 1, 1, CAST(N'2023-06-02' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (17, 630, N'', CAST(70.00 AS Decimal(6, 2)), 104, 485, 1, 4, N'Maayakkannadi.jpg', N'', N'', N'', N'June 201', N'', N'', N'', N'', 1, 1, CAST(N'2023-06-05' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (18, 636, N'', CAST(140.00 AS Decimal(6, 2)), 160, 683, 1, 5, N'Poomiku-Adiyil-Oru-Marmam.jpg', N'', N'', N'', N'Feb 2021', N'', N'', N'', N'', 1, 1, CAST(N'2023-06-06' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (19, 644, N'', CAST(250.00 AS Decimal(6, 2)), 256, 197, 1, 5, N'Karuvagi.jpg', N'', N'', N'', N'', N'', N'', N'', N'', 0, 1, CAST(N'2023-06-09' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (20, 651, N'', CAST(100.00 AS Decimal(6, 2)), 168, 85, 1, 5, N'kadhavu.jpg', N'', N'', N'', N'', N'', N'', N'', N'', 0, 1, CAST(N'2023-06-09' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (21, 681, N'', CAST(90.00 AS Decimal(6, 2)), 103, 213, 1, 5, N'Vadi Vasal.jpg', N'', N'', N'', N'1959', N'', N'', N'', N'', 1, 1, CAST(N'2023-06-19' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (22, 689, N'', CAST(60.00 AS Decimal(6, 2)), 120, 85, 1, 5, N'Kanavukal-Karpanaikal-Kakithankal.jpg', N'', N'', N'', N'1971', N'Sep 2016', N'', N'', N'', 1, 1, CAST(N'2023-06-19' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (23, 702, N'895', CAST(180.00 AS Decimal(6, 2)), 160, 213, 1, 5, N'Tho-Paramasivan-Nerakaanalgal.jpg', N'', N'', N'', N'Jan 2019', N'', N'', N'', N'', 0, 1, CAST(N'2023-06-22' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (24, 726, N'', CAST(150.00 AS Decimal(6, 2)), 180, 19, 1, 5, N'Tamizhagathil-Muslimgal.png', N'', N'', N'978-81-7720-245-8', N'Dec 1990', N'', N'', N'', N'', 1, 1, CAST(N'2023-06-22' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (25, 739, N'997', CAST(250.00 AS Decimal(6, 2)), 320, 573, 1, 4, N'Kanjik-Kathiravan.jpg', N'', N'', N'', N'Mar 2012', N'', N'', N'', N'', 1, 1, CAST(N'2023-06-22' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (26, 780, N'', CAST(130.00 AS Decimal(6, 2)), 216, 455, 1, 5, N'Piragu.jpg', N'', N'', N'', N'2014', N'', N'', N'', N'', 1, 1, CAST(N'2023-06-23' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (27, 797, N'', CAST(110.00 AS Decimal(6, 2)), 112, 143, 1, 5, N'Meenkarath-Theru.jpg', N'', N'', N'', N'', N'', N'', N'', N'', 0, 1, CAST(N'2023-06-23' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (28, 806, N'', CAST(180.00 AS Decimal(6, 2)), 200, 751, 1, 5, N'Enbilathanai-Veyil-Kayum.jpg', N'', N'', N'9788184464467', N'2022', N'', N'', N'', N'', 0, 1, CAST(N'2023-07-02' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (29, 1001, N'', CAST(400.00 AS Decimal(6, 2)), 360, 139, 1, 4, N'idakkai_FI_1001.jpg', N'', N'', N'978-93-85104-43-5', N'Apirl 20', N'', N'', N'', N'', 1, 1, CAST(N'2023-07-09' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (30, 1114, N'', CAST(45.00 AS Decimal(6, 2)), 88, 665, 1, 5, N'Oru-Magudam-Oru-Vaal-Iru-Vizhigal_1114.jpg', N'', N'', N'', N'', N'', N'', N'', N'', 0, 1, CAST(N'2023-07-09' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (31, 748, N'1109', CAST(208.00 AS Decimal(6, 2)), 165, 573, 1, 4, N'Thogai-Mayil-748.jpg', N'', N'', N'', N'', N'', N'', N'', N'', 0, 1, CAST(N'2023-07-10' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (32, 1151, N'', CAST(60.00 AS Decimal(6, 2)), 72, 352, 1, 5, N'Thamizhar-Vazhkkaiyum-Thiraippadangalum-1151.png', N'', N'', N'978-93-84301-95-8', N'Sep 2016', N'', N'', N'', N'', 1, 1, CAST(N'2023-07-12' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (33, 1181, N'', CAST(150.00 AS Decimal(6, 2)), 112, 816, 1, 5, N'Punaivu-Veli-1.jpg', N'', N'', N'', N'2017', N'', N'', N'', N'', 0, 1, CAST(N'2023-07-17' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (34, 1100, N'', CAST(115.00 AS Decimal(6, 2)), 184, 665, 1, 5, N'Paranthagan-Magal.jpg', N'', N'', N'', N'2018', N'', N'', N'', N'', 0, 1, CAST(N'2023-07-17' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (35, 1207, N'815', CAST(225.00 AS Decimal(6, 2)), 192, 213, 1, 5, N'Peruvali.jpg', N'', N'', N'978-93-86820-35-8', N'Dec 2017', N'', N'', N'', N'', 1, 1, CAST(N'2023-07-18' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (36, 1126, N'', CAST(160.00 AS Decimal(6, 2)), 200, 665, 1, 5, N'madurai-magudam.jpg', N'', N'', N'', N'', N'', N'', N'', N'', 0, 1, CAST(N'2023-07-22' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (37, 1292, N'', CAST(125.00 AS Decimal(6, 2)), 176, 792, 1, 5, N'Ponnipunal-Poompavai.jpg', N'', N'', N'', N'', N'', N'', N'', N'', 0, 1, CAST(N'2023-07-23' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (38, 1077, N'', CAST(50.00 AS Decimal(6, 2)), 54, 578, 1, 5, N'Hiroshimaavil-Mani-Olikkirathu-1077.jpeg', N'', N'Hiroshimaavil-Mani-Olikkirathu-1077L.jpeg', N'', N'Dec 2014', N'', N'', N'', N'', 1, 1, CAST(N'2023-07-24' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (39, 1078, N'', CAST(55.00 AS Decimal(6, 2)), 72, 139, 1, 5, N'Aayirathoru-Arabiya-Iravukal.jpg', N'', N'', N'', N'', N'', N'', N'', N'', 0, 1, CAST(N'2023-07-25' AS Date), NULL, N'A')
GO
INSERT [dbo].[BooksDetails] ([BookDetailsID], [BookID], [BookCode], [Price], [Pages], [PublisherID], [NoofCopy], [BookFormat], [ImgBookSmallFS], [ImgBookSmallBS], [ImgBookLarge], [ISBN13], [FirstEdition], [CurrentEdition], [Dimensions], [CoverDesign], [CoverFormat], [IsKarkaBook], [EnteredBy], [CreatedDate], [ModifiedDate], [RecStatus]) VALUES (40, 3597, N'', CAST(150.00 AS Decimal(6, 2)), 136, 228, 1, 5, N'Indiap-Payanam.jpg', N'', N'', N'978-81-8493-681-0', N'Dec 2016', N'', N'', N'', N'', 0, 1, CAST(N'2023-11-22' AS Date), NULL, N'A')
GO
SET IDENTITY_INSERT [dbo].[BooksDetails] OFF
GO