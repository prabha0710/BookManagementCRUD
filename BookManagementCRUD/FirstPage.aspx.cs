
using System;
using System.Data;
<<<<<<< Updated upstream:BookManagementCRUD/FirstPage.aspx.cs
using System.Data.SqlClient;
using System.Web.UI;
=======
using BookManagementCRUD.CommonLayer.Constant;
using BookManagementCRUD.CommonLayer.Messages;
using BookManagementCRUD.BusinessLogicLayer.BookBL;

>>>>>>> Stashed changes:BookManagementCRUD/WebPages/FirstPage.aspx.cs

namespace BookManagementCRUD
{
	public partial class AddBooks : System.Web.UI.Page
	{
<<<<<<< Updated upstream:BookManagementCRUD/FirstPage.aspx.cs
=======
		private BookBL bookBL = new BookBL();
		string connectionString = ConnectionStringValues.ConnectionString;
>>>>>>> Stashed changes:BookManagementCRUD/WebPages/FirstPage.aspx.cs
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				if(Request.QueryString["Id"] != null)
				{
					int bookId = Convert.ToInt32(Request.QueryString["Id"]);
					LoadBookDetails(bookId);
					btnSave.Visible = false;
					btnUpdate.Visible = true;
				}
			}

			CreateBookTable();
		}

		protected void LoadBookDetails(int bookId)
		{
<<<<<<< Updated upstream:BookManagementCRUD/FirstPage.aspx.cs
			using(SqlConnection con = new SqlConnection("data source=.;database=Book;integrated security=SSPI"))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM Book WHERE Id = @Id", con);
					cmd.Parameters.AddWithValue("@Id", bookId);
					SqlDataReader reader = cmd.ExecuteReader();
					if(reader.Read())
					{
						txtBookName.Text = reader["BookName"].ToString();
						txtAuthorName.Text = reader["AuthorName"].ToString();
						txtBookCount.Text = reader["BookCount"].ToString();
						txtPublicationYear.Text = reader["PublicationYear"].ToString();
						txtISBN.Text = reader["ISBN"].ToString();
						txtLanguage.Text = reader["Language"].ToString();
					}
				}
				catch(Exception ex)
				{
					Label1.Text = "Error loading book details: " + ex.Message;
				}
=======
			DataTable dataTable = bookBL.LoadBookDetails(bookId);

			if(dataTable.Rows.Count > 0)
			{
				DataRow row = dataTable.Rows[0];
				txtBookName.Text = row["BookName"].ToString();
				txtAuthorName.Text = row["AuthorName"].ToString();
				txtBookCount.Text = row["BookCount"].ToString();
				txtPublicationYear.Text = row["PublicationYear"].ToString();
				txtISBN.Text = row["ISBN"].ToString();
				txtLanguage.Text = row["Language"].ToString();
>>>>>>> Stashed changes:BookManagementCRUD/WebPages/FirstPage.aspx.cs
			}
		}

		private void CreateBookTable()
		{
<<<<<<< Updated upstream:BookManagementCRUD/FirstPage.aspx.cs
			string connectionString = "data source=.;database=Book;integrated security=SSPI";
			string createTableQuery =
				@"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Book' AND xtype='U')
                CREATE TABLE Book(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                BookName VARCHAR(100),                    
                AuthorName VARCHAR(100),
                BookCount INT,
                PublicationYear INT,
                ISBN VARCHAR(13), -- Changed from INT to VARCHAR(13) for ISBN
                Language VARCHAR(100))";

			using(SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand(createTableQuery, con);
					cmd.ExecuteNonQuery();
				}
				catch(Exception ex)
				{
					Label1.Text = "Error creating table: " + ex.Message;
				}
			}
=======
			bookBL.CreateBookTable();
>>>>>>> Stashed changes:BookManagementCRUD/WebPages/FirstPage.aspx.cs
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
<<<<<<< Updated upstream:BookManagementCRUD/FirstPage.aspx.cs
			string connectionString = "data source=.;database=Book;integrated security=SSPI";
			string[] dataToInsert = new string[6];
			dataToInsert[0] = txtBookName.Text;
			dataToInsert[1] = txtAuthorName.Text;
			dataToInsert[2] = txtBookCount.Text;
			dataToInsert[3] = txtPublicationYear.Text;
			dataToInsert[4] = txtISBN.Text;
			dataToInsert[5] = txtLanguage.Text;

			if(Array.Exists(dataToInsert, string.IsNullOrEmpty))
			{
				Label1.Text = "Please fill in all text boxes.";
				return;
			}

			using(SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string selectCommand = "SELECT * FROM Book";
					SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, con);
					SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

					DataTable dataTable = new DataTable();
					dataAdapter.Fill(dataTable);

					DataRow newRow = dataTable.NewRow();
					newRow["BookName"] = dataToInsert[0];
					newRow["AuthorName"] = dataToInsert[1];
					newRow["BookCount"] = dataToInsert[2];
					newRow["PublicationYear"] = dataToInsert[3];
					newRow["ISBN"] = dataToInsert[4];
					newRow["Language"] = dataToInsert[5];

					dataTable.Rows.Add(newRow);
					dataAdapter.Update(dataTable);
					Label1.Text = "Book Details Saved Sucessfully in Database";
					ClearFields();
				}
				catch(Exception ex)
				{
					Label1.Text = "Data insertion failed: " + ex.Message;
				}
			}
=======
			try
			{
				string[] dataToInsert = { txtBookName.Text,  txtAuthorName.Text,
								txtBookCount.Text, txtPublicationYear.Text,
								txtISBN.Text,      txtLanguage.Text };
				bookBL.InsertBook(dataToInsert);
				Label1.Text = SuccessMessages.BookDetailsSave_Message;
				ClearTextBoxFields();
			}
			catch
			{
				Label1.Text = ErrorMessage.DataInsertionFailed;
			}
			
>>>>>>> Stashed changes:BookManagementCRUD/WebPages/FirstPage.aspx.cs
		}

		private void ClearFields()
		{
			txtBookName.Text = "";
			txtAuthorName.Text = "";
			txtBookCount.Text = "";
			txtPublicationYear.Text = "";
			txtISBN.Text = "";
			txtLanguage.Text = "";
		}

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
<<<<<<< Updated upstream:BookManagementCRUD/FirstPage.aspx.cs
			int bookId = Convert.ToInt32(Request.QueryString["Id"]);

			using(SqlConnection con = new SqlConnection("data source=.;database=Book;integrated security=SSPI"))
			{
				SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Book WHERE Id = @Id", con);
				dataAdapter.SelectCommand.Parameters.AddWithValue("@Id", bookId);

				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);

				if(dataTable.Rows.Count > 0)
				{
					DataRow row = dataTable.Rows[0];
					row["BookName"] = txtBookName.Text;
					row["AuthorName"] = txtAuthorName.Text;
					row["BookCount"] = txtBookCount.Text;
					row["PublicationYear"] = txtPublicationYear.Text;
					row["ISBN"] = txtISBN.Text;
					row["Language"] = txtLanguage.Text;

					dataAdapter.Update(dataTable);
					Label1.Text = "Data updated successfully in Database";
					Response.Redirect("GridViewPage.aspx");
				}
=======
			try
			{
				int bookId = Convert.ToInt32(Request.QueryString["Id"]);
				string[] dataToUpdate = { txtBookName.Text,  txtAuthorName.Text,
								txtBookCount.Text, txtPublicationYear.Text,
								txtISBN.Text,      txtLanguage.Text };
				bookBL.UpdateBook(bookId, dataToUpdate);
				Label1.Text = SuccessMessages.UpdateBook_Message;
				ClearTextBoxFields();
>>>>>>> Stashed changes:BookManagementCRUD/WebPages/FirstPage.aspx.cs
			}
			catch
			{
				Label1.Text = ErrorMessage.UpdateDatafailed;
			}
			
		}

		protected void btnViewBooks_Click(object sender, EventArgs e)
		{
			Response.Redirect("GridViewPage.aspx");
		}
	}
}
