using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagementCRUD
{
	public partial class GridViewPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				LoadBooks();
			}
		}
		private void LoadBooks()
		{
			SqlConnection con = null;
			try
			{
				con = new SqlConnection("data source=.;database=Book;integrated security=SSPI");
				con.Open();
				SqlCommand cmd = new SqlCommand("SELECT * FROM Book", con);
				gvBooks.DataSource = cmd.ExecuteReader();
				gvBooks.DataBind();
			}
			catch(Exception ex)
			{

				lblMessage.Text = "Error loading books: " + ex.Message;
			}
			finally
			{

				con.Close();
			}
		}

		protected void gvBooks_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int rowIndex = Convert.ToInt32(e.CommandArgument);
			int bookId = Convert.ToInt32(gvBooks.DataKeys[rowIndex].Value);

			if(e.CommandName == "EditBook")
			{
				Response.Redirect("Firstpage.aspx?Id=" + bookId);
			}
			else if(e.CommandName == "DeleteBook")
			{
				DeleteBook(bookId);
			}
		}

		private void DeleteBook(int bookId)
		{
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
					row.Delete();

					dataAdapter.Update(dataTable);
					LoadBooks();
				}
			}
		}
	}
}
