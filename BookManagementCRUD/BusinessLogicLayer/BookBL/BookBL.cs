using System.Data;
using BookManagementCRUD.BusinessLogicLayer.ValidationBL;
using BookManagementCRUD.CommonLayer.Messages;
using BookManagementCRUD.DataAccessLayer;

namespace BookManagementCRUD.BusinessLogicLayer.BookBL
{
	public class BookBL
	{
		private BookDAL bookDAL = new BookDAL();

		public void CreateBookTable()
		{
			bookDAL.CreateBookTable();
		}
		public DataTable GetBooks()
		{
			return bookDAL.GetBooks();
		}

		public DataTable LoadBookDetails(int bookId)
		{
			return bookDAL.GetBookById(bookId);
		}

		public DataTable GetBookById(int bookId)
		{
			return bookDAL.GetBookById(bookId);
		}

		public void InsertBook(string[] bookData)
		{
            bookDAL.InsertBook(bookData);
		}

		public void UpdateBook(int bookId, string[] bookData)
		{
			bookDAL.UpdateBook(bookId, bookData);
		}

		public void DeleteBook(int bookId)
		{
			bookDAL.DeleteBook(bookId);
		}
		
	
	}
}