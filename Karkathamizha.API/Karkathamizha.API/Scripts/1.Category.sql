create database ReactProj
GO
use ReactProj
GO


CREATE TABLE [dbo].[Category](
	[CategoryID]	 [SMALLINT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Category]	 [NVARCHAR](60) NULL,
	[Name]			 [VARCHAR](40) NULL,
	[ParentID]		 [SMALLINT] NULL,	
	[IsShownInMenu]	 [BIT] DEFAULT 0 NULL,
	[RecStatus]		 [CHAR](1) DEFAULT 'A'
)

GO


insert into dbo.Category(Category,Name,ParentID)values(N'புதினம்(நாவல்)','Novel',NULL)
insert into dbo.Category(Category,Name,ParentID)values(N'மதம்','Religion',NULL)
insert into dbo.Category(Category,Name,ParentID)values(N'கட்டுரைகள்','Essays',NULL)
insert into dbo.Category(Category,Name,ParentID)values(N'கவிதைகள்','Poems',NULL)
insert into dbo.Category(Category,Name,ParentID)values(N'சுயசரிதைகள் மற்றும் உண்மை கதை','Biographies & True story',NULL)


GO

insert into dbo.Category(Category,Name,ParentID)values(N'அறிவியல் நாவல்','Science Fiction',1)
insert into dbo.Category(Category,Name,ParentID)values(N'இதிகாச / புராண நாவல்','Epic / Mythological Novel',1)
insert into dbo.Category(Category,Name,ParentID)values(N'கற்பனை நாவல்','Fantasy / Fictional Novel',1)
insert into dbo.Category(Category,Name,ParentID)values(N'குறுங்கதைகள்','Short Stories',1)
insert into dbo.Category(Category,Name,ParentID)values(N'குறுநாவல்','Short Story Novel',1)
insert into dbo.Category(Category,Name,ParentID)values(N'சமூக நாவல்','Social novel',1)
insert into dbo.Category(Category,Name,ParentID)values(N'சரித்திர / வரலாற்று நாவல்','Historical Novel',1)
insert into dbo.Category(Category,Name,ParentID)values(N'சிறுகதைகள்','Short Stories',1)
insert into dbo.Category(Category,Name,ParentID)values(N'திகில் நாவல்','Horror Novel',1)
insert into dbo.Category(Category,Name,ParentID)values(N'துப்பறியும் புதினம்','Detective Novel',1)
insert into dbo.Category(Category,Name,ParentID)values(N'நகைச்சுவை','Comedy',1)
insert into dbo.Category(Category,Name,ParentID)values(N'நாட்டுப்புறக் கதைகள்','NULL',1)
insert into dbo.Category(Category,Name,ParentID)values(N'நெடுங்கதைகள்','Long Stories',1)
insert into dbo.Category(Category,Name,ParentID)values(N'மொழிபெயர்ப்பு','Translation',1)
GO

insert into dbo.Category(Category,Name,ParentID)values(N'அனுபவம்','Experience',2)
insert into dbo.Category(Category,Name,ParentID)values(N'ஆன்மீகம் / பக்தி','Spritual',2)
insert into dbo.Category(Category,Name,ParentID)values(N'இந்து மதம்','',2)
insert into dbo.Category(Category,Name,ParentID)values(N'இஸ்லாமியம்','Islamiyam',2)
insert into dbo.Category(Category,Name,ParentID)values(N'கவிதைகள்','Literature',2)
insert into dbo.Category(Category,Name,ParentID)values(N'கிறித்துவம்','Christ',2)
insert into dbo.Category(Category,Name,ParentID)values(N'சமண மதம்','',2)
insert into dbo.Category(Category,Name,ParentID)values(N'சமயக் கற்கைகள்','',2)
insert into dbo.Category(Category,Name,ParentID)values(N'சீக்கியம்','Sikh',2)
insert into dbo.Category(Category,Name,ParentID)values(N'சோதிடம்','',2)
insert into dbo.Category(Category,Name,ParentID)values(N'நெறிமுறை','',2)
insert into dbo.Category(Category,Name,ParentID)values(N'பஞ்சாங்கம்','',2)
insert into dbo.Category(Category,Name,ParentID)values(N'புத்தம் / பௌத்தம் / பவுத்தம்','',2)
insert into dbo.Category(Category,Name,ParentID)values(N'மதம் / மதங்கள்','NULL',2)
insert into dbo.Category(Category,Name,ParentID)values(N'யூதம்','',2)
insert into dbo.Category(Category,Name,ParentID)values(N'மொழிபெயர்ப்பு','Translation',2)

GO

insert into dbo.Category(Category,Name,ParentID)values(N'ஆய்வு கட்டுரைகள்','Research Articles',3)
insert into dbo.Category(Category,Name,ParentID)values(N'ஆன்மிகம்','Spirituality',3)
insert into dbo.Category(Category,Name,ParentID)values(N'இந்துத்துவம்','Hinduism',3)
insert into dbo.Category(Category,Name,ParentID)values(N'இலக்கியம்','Literature',3)
insert into dbo.Category(Category,Name,ParentID)values(N'உடல்நலம்-மருத்துவம்','Health-Medicine',3)
insert into dbo.Category(Category,Name,ParentID)values(N'உளவியல்','Psychology',3)
insert into dbo.Category(Category,Name,ParentID)values(N'கட்டுரைகள்','Essays',3)
insert into dbo.Category(Category,Name,ParentID)values(N'கம்யூனிசம்','NULL',3)
insert into dbo.Category(Category,Name,ParentID)values(N'கலாச்சாரம், பண்பாடு','Culture',3)
insert into dbo.Category(Category,Name,ParentID)values(N'கள ஆய்வு','NULL',3)
insert into dbo.Category(Category,Name,ParentID)values(N'குடும்பம் / உறவு','NULL',3)
insert into dbo.Category(Category,Name,ParentID)values(N'குழந்தை வளர்ப்பு','Child Care',3)
insert into dbo.Category(Category,Name,ParentID)values(N'சமூக நீதி','Social justice',3)
insert into dbo.Category(Category,Name,ParentID)values(N'சமையல்-உணவு','Kitchen Food',3)
insert into dbo.Category(Category,Name,ParentID)values(N'சாதி','NULL',3)
insert into dbo.Category(Category,Name,ParentID)values(N'சாதி - தீண்டாமை','NULL',3)
insert into dbo.Category(Category,Name,ParentID)values(N'சாதி ஒழிப்பு','NULL',3)
insert into dbo.Category(Category,Name,ParentID)values(N'சிந்தனை','',3)
insert into dbo.Category(Category,Name,ParentID)values(N'தன்னம்பிக்கை ','Self-confidence',3)

GO

insert into dbo.Category(Category,Name,ParentID)values(N'கவிதைகள்','Poems',4)
insert into dbo.Category(Category,Name,ParentID)values(N'சங்க இலக்கியம்','Sanga Literature',4)
insert into dbo.Category(Category,Name,ParentID)values(N'பிள்ளைத் தமிழ்','',4)
insert into dbo.Category(Category,Name,ParentID)values(N'ஹைக்கூ','Haiku',4)
insert into dbo.Category(Category,Name,ParentID)values(N'மொழிபெயர்ப்பு','Translation',4)

GO

insert into dbo.Category(Category,Name,ParentID)values(N'அனுபவம்','',5)
insert into dbo.Category(Category,Name,ParentID)values(N'உண்மை கணக்குகள்','',5)
insert into dbo.Category(Category,Name,ParentID)values(N'கடிதங்கள் மற்றும் பதிவேடுகள்','',5)
insert into dbo.Category(Category,Name,ParentID)values(N'சுயசரிதைகள் / வாழ்க்கை வரலாறு மற்றும் தன் வரலாறு','',5)
insert into dbo.Category(Category,Name,ParentID)values(N'மொழிபெயர்ப்பு','Translation',5)

GO

select * from Category