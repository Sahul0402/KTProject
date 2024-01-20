CREATE TABLE [dbo].[BookFormat]
(
	[BookFormatID] [tinyint] primary key IDENTITY(1,1) NOT NULL,
	[BookFormat] [nvarchar](15) NULL,
	[Name] [varchar](15) NULL,
	[RecStatus] [char](1) default 'A' 
)


Insert into dbo.BookFormat(BookFormat,Name)values(N'ஆடியோ','Audio')
Insert into dbo.BookFormat(BookFormat,Name)values(N'கதை சொல்லல்','Story Telling')
Insert into dbo.BookFormat(BookFormat,Name)values(N'கிண்டில்','Kindle')
Insert into dbo.BookFormat(BookFormat,Name)values(N'கெட்டி அட்டை','Hard Copy')
Insert into dbo.BookFormat(BookFormat,Name)values(N'தாள் அட்டை','Paper Copy')

select * from BookFormat
