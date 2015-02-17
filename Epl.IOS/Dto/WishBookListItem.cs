using System;

namespace EnjoyPubLib.Dto
{
	public class WishBookListItem
	{
		public WishBookListItem ()
		{

		}

		public int Id { get; set;}
		public int BookItemId{ get; set;}

		public string BookName{ get; set;}
		public DateTime AddDateTime{ get; set;}
		public string Author{ get; set;}
		public string Content{ get; set;}
		public string Isbn{ get; set;}
		public string Url{ get; set;}

	}
}

