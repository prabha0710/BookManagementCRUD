using System.ComponentModel.DataAnnotations;
namespace BookManagementCRUD.BusinessLogicLayer.ValidationBL
{
	public class InputValidationBL
	{
		[Required(ErrorMessage = "Book Name is Required")]
		public string BookName { get; set; }
		[Required(ErrorMessage = "AuthorName  is Required")]
		public string AuthorName { get; set; }
		[Required(ErrorMessage = "Book Count is Required")]
		public int BookCount { get; set; }
		[Required(ErrorMessage ="Publication is required")]
		public int PublicationYear { get; set; }
		[Required(ErrorMessage = "ISBN is Required")]
		public string ISBN { get; set; }
		[Required(ErrorMessage="Language is Required")]
		public string Language { get; set; }


	}
}