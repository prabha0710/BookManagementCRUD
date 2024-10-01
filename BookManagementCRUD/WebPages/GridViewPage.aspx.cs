using System;
using System.Web.UI.WebControls;
using BookManagementCRUD.BusinessLogicLayer.BookBL;
using BookManagementCRUD.CommonLayer.Messages;

namespace BookManagementCRUD
{
	public partial class GridViewPage : System.Web.UI.Page
	{
		private BookBL bookBL = new BookBL();

		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				LoadBooks();
			}
		}
		private void LoadBooks()
		{
			try
			{
				GridView.DataSource = bookBL.GetBooks();
				GridView.DataBind();
			}
			catch
			{
				Label1.Text = ErrorMessage.ErrorLoadBooks;
			}
			
		}

		protected void GridView_RowCommand(object sender,
										   GridViewCommandEventArgs e)
		{
			int rowIndex = Convert.ToInt32(e.CommandArgument);
			int bookId = Convert.ToInt32(GridView.DataKeys[rowIndex].Value);

			if(e.CommandName == "EditBook")
			{
				Response.Redirect("~/WebPages/FirstPage.aspx?Id=" + bookId);
			}
			else if(e.CommandName == "DeleteBook")
			{
				bookBL.DeleteBook(bookId);
				LoadBooks();
			}
		}
	}
}
