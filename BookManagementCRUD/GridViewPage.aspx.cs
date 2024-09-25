using System;
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
			try
			{
				int rowIndex = Convert.ToInt32(e.CommandArgument);
				GridViewRow row = gvBooks.Rows[rowIndex];
				int bookId = Convert.ToInt32(gvBooks.DataKeys[rowIndex].Value);

				if(e.CommandName == "EditBook")
				{
					Response.Redirect("FirstPage.aspx?Id=" + bookId);
				}
				else if(e.CommandName == "DeleteBook")
				{
					DeleteBook(bookId);
				}
			}
			catch(Exception ex)
			{
				lblMessage.Text = "Error handling row command: " + ex.Message;
			}
		}

		private void DeleteBook(int bookId)
		{
			SqlConnection con = null;
			try
			{
				con = new SqlConnection("data source=.;database=Book;integrated security=SSPI");
				con.Open();
				SqlCommand cmd = new SqlCommand("DELETE FROM Book WHERE Id = @Id", con);
				cmd.Parameters.AddWithValue("@Id", bookId);
				cmd.ExecuteNonQuery();
				LoadBooks();
			}
			catch(Exception ex)
			{
				lblMessage.Text = "Error deleting book: " + ex.Message;
			}
			finally
			{

				con.Close();
			}
		}
	}
}
