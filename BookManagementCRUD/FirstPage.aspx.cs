
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BookManagementCRUD
{
	public partial class AddBooks : System.Web.UI.Page
	{
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

		private void LoadBookDetails(int bookId)
		{
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
			}
		}

		private void CreateBookTable()
		{
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
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
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
					Label1.Text = "Data inserted successfully.";
					ClearFields();
				}
				catch(Exception ex)
				{
					Label1.Text = "Data insertion failed: " + ex.Message;
				}
			}
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
			using(SqlConnection con = new SqlConnection("data source=.;database=Book;integrated security=SSPI"))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand(
						"UPDATE Book SET BookName = @BookName, AuthorName = @AuthorName, BookCount = @BookCount, PublicationYear = @PublicationYear, ISBN = @ISBN, Language = @Language WHERE Id = @Id",
						con);
					cmd.Parameters.AddWithValue("@BookName", txtBookName.Text);
					cmd.Parameters.AddWithValue("@AuthorName", txtAuthorName.Text);
					cmd.Parameters.AddWithValue("@BookCount", txtBookCount.Text);
					cmd.Parameters.AddWithValue("@PublicationYear", txtPublicationYear.Text);
					cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text);
					cmd.Parameters.AddWithValue("@Language", txtLanguage.Text);
					cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);

					cmd.ExecuteNonQuery();
					Response.Redirect("GridViewPage.aspx");
				}
				catch(Exception ex)
				{
					Label1.Text = "Error updating record: " + ex.Message;
				}
			}
		}

		protected void btnViewBooks_Click(object sender, EventArgs e)
		{
			Response.Redirect("GridViewPage.aspx");
		}
	}
}
