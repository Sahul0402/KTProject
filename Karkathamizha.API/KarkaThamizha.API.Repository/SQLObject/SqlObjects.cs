using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaThamizha.API.Repository.SQLObject
{
    public class SqlObjects
    {
        #region Article
        public const string GetAllArticle = "dbo.USP_GetAllArticle";
        public const string AddArticle = "dbo.USP_AddArticle";
        #endregion

        #region Books
        public const string AddBook = "dbo.USP_AddBooks";
        public const string DeleteBook = "dbo.USP_DeleteBook";  
        public const string GetAllBooks = "dbo.USP_GetAllBooks";
        public const string GetBookById = "dbo.USP_GetBookById";
        public const string GetAllBooksWithAuthor = "dbo.USP_GetAllBooksWithAuthor";
        public const string GetAuthorIdByBookId = "dbo.USP_GetAuthorIdByBookId";
        #endregion

        #region BooksDetails
        public const string GetAllBooksDetails = "dbo.USP_GetAllBooksDetails";
        public const string GetAllBooksDetailsByAuthorID = "dbo.USP_GetAllBooksDetailsByAuthorID";
        public const string GetAllBooksDetailsByBookId = "dbo.USP_GetAllBooksDetailsByBookId";
        #endregion

        #region BooksReview
        public const string GetBooksReview = "dbo.USP_GetBooksReview_HomePage";
        public const string GetAllBooksReview = "dbo.USP_GetAllBooksReview";
        public const string GetAllBooksReviewByBookId = "dbo.USP_GetAllBooksReviewByBookId";
        #endregion

        #region Events
        public const string GetAllEvents = "dbo.USP_GetAllEvents";
        public const string AddEvent = "dbo.USP_AddEvent";
        public const string UpdateEvent = "dbo.USP_UpdateEvent";
        public const string DeleteEvent = "dbo.USP_DeleteEvent";
        #endregion

        #region Publisher
        public const string GetAllPublishers = "dbo.USP_GetAllPublishers";
        public const string GetPublisherById = "dbo.USP_GetPublisherById";
        public const string AddPublisher = "dbo.USP_AddPublisher";
        public const string UpdatePublisher = "dbo.USP_UpdatePublisher";
        public const string DeletePublisher = "dbo.USP_DeletePublisher";
        public const string AddPublisherDetails = "dbo.USP_AddPublisherDetails";
        public const string GetBooksByPublisherID = "dbo.USP_GetBooksByPublisherID";

        #endregion

        #region User
        public const string UserLogIn = "dbo.USP_UserLogIn";
        public const string GetAllUsers = "dbo.USP_GetAllUsers";
        public const string GetUserById = "dbo.USP_GetUserById";
        public const string GetUserByEmailId = "dbo.USP_GetUserByEmailId";
        public const string CheckMailExists = "USP_CheckMailExists";
        public const string AddUser = "dbo.USP_AddUser";
        public const string UpdateUser = "dbo.USP_UpdateUser";
        public const string DeleteUser = "dbo.USP_DeleteUser";
        #endregion

        #region UserDetail
        public const string GetAllUserDetail = "dbo.USP_GetAllUserDetail";
        public const string AddUserDetail = "dbo.USP_AddUserDetail";
        public const string UpdateUserDetail = "dbo.USP_UpdateUserDetail";
        #endregion

        #region Role
        public const string GetUserRole = "dbo.USP_GetUserRole"; 
        #endregion

    }
}
