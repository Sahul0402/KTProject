
use ReactProj

CREATE TABLE [dbo].[Country](
	[CountryID]				[TINYINT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Country]					[VARCHAR](40) NOT NULL,
	[TwoLetterISOCode]		[VARCHAR](2) NULL,
	[ThreeLetterISOCode]	[VARCHAR](3) NULL,
	[RecStatus]				[CHAR](1) DEFAULT 'A'
)

GO

insert into Country(Country,TwoLetterISOCode,ThreeLetterISOCode)values('India','IN','IND')
insert into Country(Country,TwoLetterISOCode,ThreeLetterISOCode)values('United States','US','USA')

GO

CREATE TABLE [dbo].[States](
	[StateID]		[TINYINT] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[State]			[VARCHAR](50) NOT NULL,
	[CountryID]		[TINYINT] NOT NULL,
	[RecStatus]		[CHAR](1) DEFAULT 'A'
)

GO

insert into States(State,CountryID)values('Andaman and Nicobar Islands',1)
insert into States(State,CountryID)values('Andra Pradesh',1)
insert into States(State,CountryID)values('Delhi',1)
insert into States(State,CountryID)values('Goa',1)
insert into States(State,CountryID)values('Karnataka',1)
insert into States(State,CountryID)values('Kerala',1)
insert into States(State,CountryID)values('Lakshadweep',1)
insert into States(State,CountryID)values('Madya Pradesh',1)
insert into States(State,CountryID)values('Maharashtra',1)
insert into States(State,CountryID)values('Manipur',1)
insert into States(State,CountryID)values('Meghalaya',1)
insert into States(State,CountryID)values('Mizoram',1)
insert into States(State,CountryID)values('Nagaland',1)
insert into States(State,CountryID)values('Orissa',1)
insert into States(State,CountryID)values('Puducherry',1)
insert into States(State,CountryID)values('Punjab',1)
insert into States(State,CountryID)values('Rajasthan',1)
insert into States(State,CountryID)values('Sikkim',1)
insert into States(State,CountryID)values('Tamil Nadu',1)
insert into States(State,CountryID)values('Telangana',1)
insert into States(State,CountryID)values('Tripura',1)
insert into States(State,CountryID)values('Uttar Pradesh',1)
insert into States(State,CountryID)values('Uttarakhand',1)
insert into States(State,CountryID)values('West Bengal',1)

GO

CREATE TABLE [dbo].[City](
	[CityID]		[SMALLINT] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[City]			[NVARCHAR](50) NULL,
	[Name]			[VARCHAR](25) NOT NULL,
	[StateID]		[TINYINT] REFERENCES dbo.States(StateID)NOT NULL,
	[CountryID]		[TINYINT] REFERENCES dbo.Country(CountryID)NOT NULL,
	[RecStatus]		[CHAR](1) DEFAULT 'A'	
)

GO


insert into City(City,Name,StateID,CountryID)values(N'அருப்புக்கோட்டை','Aruppukkottai',19,1)
insert into City(City,Name,StateID,CountryID)values(N'ஆம்பூர்','Ambur',19,1)
insert into City(City,Name,StateID,CountryID)values(N'ஆரணி','Arani',19,1)
insert into City(City,Name,StateID,CountryID)values(N'ஆற்காடு','Arcot',19,1)
insert into City(City,Name,StateID,CountryID)values(N'ஈரோடு','Erode',19,1)
insert into City(City,Name,StateID,CountryID)values(N'உதகமண்டலம்','Udhagamandalam',19,1)
insert into City(City,Name,StateID,CountryID)values(N'ஓசூர்','Hosur',19,1)
insert into City(City,Name,StateID,CountryID)values(N'கரூர்','Karur',19,1)
insert into City(City,Name,StateID,CountryID)values(N'கன்னியாகுமரி','Kanyakumari',19,1)
insert into City(City,Name,StateID,CountryID)values(N'காஞ்சிபுரம்','Kanchipuram',19,1)
insert into City(City,Name,StateID,CountryID)values(N'கும்பகோணம்','Kumbakonam',19,1)
insert into City(City,Name,StateID,CountryID)values(N'கொடைக்கானல்','Kodaikanal',19,1)
insert into City(City,Name,StateID,CountryID)values(N'கோவில்பட்டி','Kovilpatti',19,1)
insert into City(City,Name,StateID,CountryID)values(N'சங்கரன்கோவில்','Sankarankoil',19,1)
insert into City(City,Name,StateID,CountryID)values(N'சிதம்பரம்','Chidambaram',19,1)
insert into City(City,Name,StateID,CountryID)values(N'சிவகங்கை','Sivagangai',19,1)
insert into City(City,Name,StateID,CountryID)values(N'சிவகாசி','Sivakasi',19,1)
insert into City(City,Name,StateID,CountryID)values(N'சென்னை','Chennai',19,1)
insert into City(City,Name,StateID,CountryID)values(N'சேலம்','Salem',19,1)
insert into City(City,Name,StateID,CountryID)values(N'தஞ்சாவூர்','Thanjavur',19,1)
insert into City(City,Name,StateID,CountryID)values(N'தருமபுரி','Dharmapuri',19,1)
insert into City(City,Name,StateID,CountryID)values(N'திண்டிவனம்','Tindivanam',19,1)
insert into City(City,Name,StateID,CountryID)values(N'திண்டுக்கல்','Dindigul',19,1)
insert into City(City,Name,StateID,CountryID)values(N'திருச்சிராப்பள்ளி','Tiruchirappalli',19,1)
insert into City(City,Name,StateID,CountryID)values(N'திருநெல்வேலி','Tirunelvelli',19,1)
insert into City(City,Name,StateID,CountryID)values(N'திருவண்ணாமலை','Thiruvannamalai',19,1)
insert into City(City,Name,StateID,CountryID)values(N'தேனி','Theni',19,1)
insert into City(City,Name,StateID,CountryID)values(N'நாமக்கல்','Namakkal',19,1)
insert into City(City,Name,StateID,CountryID)values(N'பாளையங்கோட்டை','Palayamkottai',19,1)
insert into City(City,Name,StateID,CountryID)values(N'மதுரை','Madurai',19,1)
insert into City(City,Name,StateID,CountryID)values(N'விருதுநகர்','Virudhunagar',19,1)

Go

CREATE Procedure [dbo].[USP_GetAllCountries]
as
BEGIN
set nocount on
	select CountryID,Name from dbo.Country
END
GO


Create Procedure [dbo].[USP_GetStatesByCountryID] --1
(@countryID tinyint)
as
BEGIN
	set nocount on
	select StateID,Name from States where CountryID=@countryID
END
GO

CREATE Procedure [dbo].[USP_GetCityByStateID]  --19   
(@stateID smallint)            
as            
BEGIN   
 set nocount on            
 select CityID,Name +' - ' + NameInTamil as NameInTamil from City where StateID=@stateID  Order by NameInTamil    
      
END      
      
GO