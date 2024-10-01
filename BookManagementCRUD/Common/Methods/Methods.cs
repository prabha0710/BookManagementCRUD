using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
namespace BookManagementCRUD.Common
{
	public static class Methods
	{
		public static void LoadBooks(GridView gridView, Label lblMessage)
		{
			SqlConnection con = null;
			try
			{
				con = new SqlConnection("data source=.;database=Book;integrated security=SSPI");
				con.Open();
				SqlCommand cmd = new SqlCommand("SELECT * FROM Book", con);

				gridView.DataSource = cmd.ExecuteReader();
				gridView.DataBind();
			}
			catch(Exception ex)
			{
				lblMessage.Text = "Error loading books: " + ex.Message;
			}
			finally
			{
				if(con != null)
				{
					con.Close();
				}
			}
		}
	}
}
