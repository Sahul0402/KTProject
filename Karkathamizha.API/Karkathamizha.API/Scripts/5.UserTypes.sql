create database ReactProj
use ReactProj

CREATE TABLE [dbo].[UserType](
	[UserTypeID]	[TINYINT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name]			[VARCHAR](15) NOT NULL,
	[NameInTamil]	[NVARCHAR](20) NOT NULL,	
	[ShortCode]		[CHAR](1) NOT NULL,
	[RecStatus]		[CHAR](1) default 'A',

)

GO

insert into dbo.UserType(Name,NameInTamil,ShortCode)values('Text Writer', N'உரையாசிரியர்','W')
insert into dbo.UserType(Name,NameInTamil,ShortCode)values('Author', N'எழுத்தாளர்','A')
insert into dbo.UserType(Name,NameInTamil,ShortCode)values('Collector', N'தொகுப்பாசிரியர்','C')
insert into dbo.UserType(Name,NameInTamil,ShortCode)values('Publisher', N'பதிப்பகத்தார்','P')
insert into dbo.UserType(Name,NameInTamil,ShortCode)values('Editor', N'பதிப்பாசிரியர்','E')
insert into dbo.UserType(Name,NameInTamil,ShortCode)values('User', N'பயனர்','U')
insert into dbo.UserType(Name,NameInTamil,ShortCode)values('Translator', N'மொழிபெயர்ப்பாளர்','T')

GO

