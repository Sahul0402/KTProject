CREATE TABLE [dbo].[SpecialName](
	[SpecialNameID]	[tinyint] primary key IDENTITY(1,1) NOT NULL,
	[SpecialName]	[nvarchar](25) NOT NULL,
	[RecStatus]		[char](1) default 'A'
)

insert into SpecialName(SpecialName)values(N'ஆசிரியர்')
insert into SpecialName(SpecialName)values(N'ஆய்வறிஞர்')
insert into SpecialName(SpecialName)values(N'இலக்கியச் செல்வர்')
insert into SpecialName(SpecialName)values(N'உரைவேந்தர்')
insert into SpecialName(SpecialName)values(N'உவமைக் கவிஞர்')
insert into SpecialName(SpecialName)values(N'ஔவை')
insert into SpecialName(SpecialName)values(N'கலைஞர்')
insert into SpecialName(SpecialName)values(N'கவிச்சக்கரவர்த்தி')
insert into SpecialName(SpecialName)values(N'கவிஞர்')
insert into SpecialName(SpecialName)values(N'கவிஞாயிறு')
insert into SpecialName(SpecialName)values(N'கவிப்பேரரசு')
insert into SpecialName(SpecialName)values(N'கவிமணி')
insert into SpecialName(SpecialName)values(N'கவியரசர் ')
insert into SpecialName(SpecialName)values(N'கவியரசு')


GO

CREATE procedure [dbo].[USP_GetAllSpecialName]
AS              
BEGIN              
 SET NOCOUNT ON              
 select SpecialNameID,Name from dbo.SpecialName
END
GO
