  
  
/*    
 EXEC [dbo].[USP_GetBooksReview_HomePage]    
*/    
    
/****** Object:  StoredProcedure [dbo].[USP_GetBooksReview]    Script Date: 07-11-2021 12.33.19 PM ******/                      
CREATE procedure [dbo].[USP_GetBooksReview_HomePage]            
AS                          
BEGIN                          
SET NOCOUNT ON            
DECLARE @end_char INT;        
SET @end_char = 270;        
        
 SELECT Rt.BooksReviewId,Rt.BookDetailsId,Rt.BookId, REPLACE(Rt.Book,' ','-')AS Book, Rt.CreatedDate,Rt.CategoryId,Rt.ParentId, BookCategory, Rt.Header,Rt.Description,        
   ImgBookSmallFS,UserId,UserName        
   --,Rank        
    FROM (        
        SELECT         
  BooksReviewId,BD.BookDetailsId,BD.BookId,        
          
  CASE WHEN BR.Header LIKE '%-%' THEN SUBSTRING(Header,0, CHARINDEX('-',Header)-1) ELSE Header           
  END AS Book,        
  BC.CategoryId,C.ParentId, C.Category AS BookCategory, BR.Header,        
  BR.CreatedDate, ImgBookSmallFS,U.UserId,U.UserName,U.UserTypeId,        
          
  Case WHEN C.ParentId IN(16, 36) AND SUBSTRING(BR.Description, 1, @end_char+1) <> ' '           
     THEN REPLACE(SUBSTRING(BR.Description, 1, @end_char-1),'<br />','')        
   ELSE '-'        
   END As Description,           
          
  ROW_NUMBER()        
          over (Partition BY BC.CategoryID,C.ParentID        
                ORDER BY C.ParentID,BC.CategoryID,BR.CreatedDate DESC) AS Rank        
        FROM BooksReview    BR WITH(NOLOCK)        
  left outer JOIN Booksdetails BD WITH(NOLOCK) ON BR.BookDetailsID = BD.BookDetailsID                          
  left outer JOIN BookCategory BC WITH(NOLOCK) ON BC.BookID = BD.BookID                          
  left outer JOIN Category   C WITH(NOLOCK) ON C.CategoryID = BC.CategoryID                          
  left outer join UserDetails  UD WITH(NOLOCK) ON UD.UserID=BR.UserID                          
  left outer join Users   U WITH(NOLOCK) ON UD.UserID=U.UserID         
        ) Rt WHERE Rank = 1         
           
END 