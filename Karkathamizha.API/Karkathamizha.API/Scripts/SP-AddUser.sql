/****** Object:  StoredProcedure [dbo].[USP_AddUser]    Script Date: 07-11-2023 12.33.19 PM ******/                  
Create Procedure [dbo].[USP_AddUser](
@UserID			int,                    
@Initial		nvarchar(20)=null,                    
@User			nvarchar(100),         
@Name			varchar(35),                    
@Email			varchar(35),                    
@Password		nvarchar(60)=null,                    
@Mobile			varchar(10),                    
@ProfessionID	tinyint = null,              
@UserTypeID		tinyint = null,         
@SpecialNameID	tinyint = null,                    
@Result			INT Output                    
)                    
as                    
Begin                    
Declare @FullName nvarchar(120)             
Set @FullName = @Initial + @User            
            
if (@UserID=0)                    
BEGIN                    
IF NOT EXISTS(SELECT (Initial + UserName)AS userName FROM Users WHERE (Initial + UserName) = @FullName)                    
BEGIN                    
INSERT INTO Users(Initial,UserName,Name,MailID,Password,Mobile,ProfessionID,UserTypeID,SpecialNameID,LastActivity,CreatedDate)values                    
(LTRIM(RTRIM(@Initial)),LTRIM(RTRIM(@User)),LTrim(RTrim(@Name)),@Email,@Password,@Mobile,@ProfessionID,@UserTypeID,@SpecialNameID,getdate(),getdate())                    
set @Result = scope_Identity()                    
return @Result                    
END                    
ELSE                    
BEGIN                    
set @Result=-2                    
return @Result                    
END                    
END                    
ELSE                    
update Users set Initial=LTRIM(RTRIM(@Initial)),UserName=LTRIM(RTRIM(@User)),Name=LTRIM(RTRIM(@Name)),MailID=LTRIM(RTRIM(@Email)),Password=@Password,Mobile=LTRIM(RTRIM(@Mobile)),                    
ProfessionID=@ProfessionID,UserTypeID=@UserTypeID,SpecialNameID=@SpecialNameID                    
OUTPUT INSERTED.UserId                    
where UserId=@UserID                    
set @Result=@UserID                    
return @Result                    
End 