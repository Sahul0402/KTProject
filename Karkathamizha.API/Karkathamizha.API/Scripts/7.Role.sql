use ReactProj

CREATE TABLE [dbo].[Role](
	[RoleId]		[TINYINT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name]			[NVARCHAR](20) NOT NULL,
	[RoleName]		[VARCHAR](15) NOT NULL,
	[ShortCode]		[CHAR](1) NOT NULL,
	[RecStatus]		[CHAR](1) default 'A'
)


insert into dbo.Role(Name,RoleName,ShortCode)values(N'ஆசிரியர்','Author','A')
insert into dbo.Role(Name,RoleName,ShortCode)values(N'சிறப்பு நிர்வாகி','Super Admin','S')
insert into dbo.Role(Name,RoleName,ShortCode)values(N'நிர்வாகி','Admin','N')
insert into dbo.Role(Name,RoleName,ShortCode)values(N'பணியாளர்','Employee','E') 
insert into dbo.Role(Name,RoleName,ShortCode)values(N'பதிப்பகத்தார்','Publisher','P')	
insert into dbo.Role(Name,RoleName,ShortCode)values(N'பயனர்','User','U')
insert into dbo.Role(Name,RoleName,ShortCode)values(N'மேலாளர்','Manager','M')


select * from Role

create table UserRoles
(  
   UserRoleId int primary key identity(1,1),  
   UserId int References Users(UserId)  ,  
   RoleId Tinyint references Role(RoleId)  
) 