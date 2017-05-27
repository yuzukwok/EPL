using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;


namespace EnjoyPubLib
{
    [Table("BookItem")]
    public class BookItem
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public long IpacId { get; set; }
        public string Titile{get;set;}
        public string callno{get;set;}
        public string category{get;set;}
        public string content{get;set;}
        public string isbn{get;set;}
        public string publisher{get;set;}
        public string author{get;set;}
        public string place{get;set;}
		public string picurl{ get; set;}
        public int date{get;set;}

    }
     [Table("WantRead")]
    public class WantRead 
    {
         [PrimaryKey]
         [AutoIncrement]
         public int Id { get; set; }

         public long BookItemId { get; set; }

         public DateTime AddDateTime { get; set; }

         
    }


//     [Table("WantBow")]
//     public class WantBow
//     {
//         [PrimaryKey]
//         [AutoIncrement]
//         public int Id { get; set; }
//
//         public string listname { get; set; }
//
//         public DateTime GenDateTime { get; set; }
//
//         public bool Finished { get; set; }
//     }

     [Table("WantBowBook")]
     public class WantBowBook
     {
         [PrimaryKey]
         [AutoIncrement]
         public int Id { get; set; }

        

		public string BookName { get; set; }
		public string BookDesc { get; set; }
		public string BookLoction { get; set; }
		public DateTime AddDateTime{ get; set;}

     }

//     [Table("MonitorBook")]
//     public class MonitorBook 
//     {
//         [PrimaryKey]
//         [AutoIncrement]
//         public int Id { get; set; }
//
//         public long BookItemId { get; set; }
//         public DateTime ReturnDate { get; set; }
//     }

	[Table("ConfigInfo")]
	public class ConfigInfo 
	{
		[PrimaryKey]
		[AutoIncrement]
		public int Id { get; set; }

		public string  K { get; set; }
		public string V { get; set; }
	}

	[Table("LibInfo")]
	public class LibInfo 
	{
		[PrimaryKey]
		[AutoIncrement]
		public int Id { get; set; }

		public string LibId { get; set; }

		public string LibName { get; set; }

		public string Address { get; set; }

		public decimal Longtitude{ get; set;}

		public decimal Latitude{ get; set;}

		public string District{ get; set;}

		public string LibUrl{ get; set;}

		public string LibType{ get; set;}

		public string Telephone { get; set;}


	}


}
