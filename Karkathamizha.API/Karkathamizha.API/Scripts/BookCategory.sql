CREATE TABLE [dbo].[BookCategory]
(
	[BookID]		[INT] REFERENCES dbo.Books(BookID) NOT NULL,
	[CategoryID]	[SMALLINT] REFERENCES dbo.Category(CategoryID) NOT NULL,
	CONSTRAINT PK_BookCategory PRIMARY KEY CLUSTERED (BookID, CategoryID)
 )
