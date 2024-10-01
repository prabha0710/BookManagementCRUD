using System.Data.SqlClient;
using System.Data;
using BookManagementCRUD.CommonLayer.Constant;

namespace BookManagementCRUD.DataAccessLayer
{
	public class BookDAL
	{
		private string connectionString = ConnectionStringValues.ConnectionString;

		public void CreateBookTable()
		{
			string createTableQuery = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Book' AND xtype='U')
                CREATE TABLE Book(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                BookName VARCHAR(100),                    
                AuthorName VARCHAR(100),
                BookCount INT,
                PublicationYear INT,
                ISBN VARCHAR(13), 
                Language VARCHAR(100))";

			using(SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(createTableQuery, con);
				con.Open();
				cmd.ExecuteNonQuery();
			}
		}
		public DataTable GetBooks()
		{
			using(SqlConnection con = new SqlConnection(connectionString))
			{
				SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Book", con);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				return dataTable;
			}
		}

		public DataTable GetBookById(int bookId)
		{
			using(SqlConnection con = new SqlConnection(connectionString))
			{
				SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Book WHERE Id = @Id", con);
				dataAdapter.SelectCommand.Parameters.AddWithValue("@Id", bookId);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				return dataTable;
			}
		}

		public void InsertBook(string[] bookData)
		{
			using(SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Book (BookName, AuthorName, BookCount, PublicationYear, ISBN, Language) VALUES (@BookName, @AuthorName, @BookCount, @PublicationYear, @ISBN, @Language)", con);
				cmd.Parameters.AddWithValue("@BookName", bookData[0]);
				cmd.Parameters.AddWithValue("@AuthorName", bookData[1]);
				cmd.Parameters.AddWithValue("@BookCount", bookData[2]);
				cmd.Parameters.AddWithValue("@PublicationYear", bookData[3]);
				cmd.Parameters.AddWithValue("@ISBN", bookData[4]);
				cmd.Parameters.AddWithValue("@Language", bookData[5]);

				con.Open();
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateBook(int bookId, string[] bookData)
		{
			using(SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("UPDATE Book SET BookName = @BookName, AuthorName = @AuthorName, BookCount = @BookCount, PublicationYear = @PublicationYear, ISBN = @ISBN, Language = @Language WHERE Id = @Id", con);
				cmd.Parameters.AddWithValue("@Id", bookId);
				cmd.Parameters.AddWithValue("@BookName", bookData[0]);
				cmd.Parameters.AddWithValue("@AuthorName", bookData[1]);
				cmd.Parameters.AddWithValue("@BookCount", bookData[2]);
				cmd.Parameters.AddWithValue("@PublicationYear", bookData[3]);
				cmd.Parameters.AddWithValue("@ISBN", bookData[4]);
				cmd.Parameters.AddWithValue("@Language", bookData[5]);

				con.Open();
				cmd.ExecuteNonQuery();
			}
		}

		public void DeleteBook(int bookId)
		{
			using(SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Book WHERE Id = @Id", con);
				cmd.Parameters.AddWithValue("@Id", bookId);
				con.Open();
				cmd.ExecuteNonQuery();
			}
		}

	}
}