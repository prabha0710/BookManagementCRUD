using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookManagementCRUD.Common;
using BookManagementCRUD.Common.Constant;

namespace BookManagementCRUD
{
	public  partial class GridViewPage : System.Web.UI.Page
	{
		string connectionString = ConnectionStringValues.ConnectionString;
		protected   void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				Methods.LoadBooks(GridView, lblMessage);
			}
		}

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int rowIndex = Convert.ToInt32(e.CommandArgument);
			int bookId = Convert.ToInt32(GridView.DataKeys[rowIndex].Value);

			if(e.CommandName == "EditBook")
			{
				Response.Redirect("~/WebPages/FirstPage.aspx?Id=" + bookId);
			}
			else if(e.CommandName == "DeleteBook")
			{
				RemoveBookRecord(bookId);
			}
		}

		private void RemoveBookRecord(int bookId)
		{
				using(SqlConnection con = new SqlConnection(connectionString))
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
					Methods.LoadBooks(GridView, lblMessage); 
				}
			}
		}
	}
}
