﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementCRUD.Common.DataTransferObjects
{
	public class CommonDTOs
	{
		
			public int Id { get; set; }
			public string BookName { get; set; }
			public string AuthorName { get; set; }
			public int BookCount { get; set; }
			public int PublicationYear { get; set; }
			public string ISBN { get; set; }
			public string Language { get; set; }
		

	}
}