using System;
using EnjoyPubLib.WebService;
using EnjoyPubLib;
using EnjoyPubLib.IPACS;
using System.Collections.Generic;
using EnjoyPubLib.Dto;
using System.Linq;
using SQLite;

namespace EnjoyPubLib
{
	public class dal
	{
		public dal ()
		{
		}

		public IList<LibInfo> QueryLibs (SQLite.SQLiteConnection infoDbConnection)
		{
			return infoDbConnection.Table<LibInfo> ().ToList<LibInfo>();
		}

		public IList<WishBookListItem> QueryWishBooks(SQLiteConnection conn ){

			IList<WishBookListItem> list = new List<WishBookListItem> ();
			var tk = conn.Table<WantRead> ().OrderByDescending(p=>p.AddDateTime);
			foreach (var item in tk) {
				string s = "";
				var b=conn.Find<BookItem> (item.BookItemId);
				s +=" "+ b.Titile +" " +b.author; 
				WishBookListItem i = new WishBookListItem ();
				i.Id = item.Id;
				i.BookName = b.Titile;
				//i.Content = b.content;
				i.Author = b.author;
				//i.AddDateTime = item.AddDateTime;
				i.Isbn = b.isbn;
				i.Url = b.picurl;
				list.Add (i);
			}
			return list;
		}

		public IList<WantBowBook> QueryWishBowBooks (SQLiteConnection conn){
			var tk = conn.Table<WantBowBook> ().OrderByDescending(p=>p.AddDateTime).ToList();
			return tk;

		}
		public int QueryWishBooksCount(SQLiteConnection conn){


			var tk = conn.Table<WantRead> ().Count();

			return tk;
		}
		public bool DelWishBookId(SQLiteConnection conn,int id){
			conn.Delete<WantRead> (id);

			return true;
		}

		public string getKV(SQLiteConnection conn,string k){
			var tk= conn.Table<ConfigInfo>().Where(p => p.K.Equals(k)).FirstOrDefault();
			if (tk != null) {
				return tk.V;
			} else {
				return null;
			}
		}

		public void setKV(SQLiteConnection conn,string k,string v){
			var tk= conn.Table<ConfigInfo>().Where(p => p.K.Equals(k)).FirstOrDefault();
			if (tk != null) {
				tk.V = v;
				conn.Update (tk);
			} else {
				ConfigInfo n = new ConfigInfo ();
				n.K = k;
				n.V = v;
				conn.Insert (n);
			}
		}

		public void ClearBowList(SQLiteConnection conn){
			conn.DeleteAll<WantBowBook> ();
		}
		public void AddNewBookIntoBow(SQLiteConnection conn,string bookname,string bookdesc,string bookloc){
			WantBowBook t = new WantBowBook ();
			t.BookName = bookname;
			t.BookDesc = bookdesc;
			t.BookLoction = bookloc;
			t.AddDateTime = DateTime.Now;
			conn.Insert (t);
		}



		public void AddNewBookIntoWish(SQLiteConnection conn,Mobile_iPacResponseBookItem bookitem,string picurl){


			long id = long.Parse(bookitem.id);

			var book= conn.Table<BookItem>().Where(p => p.IpacId.Equals(id)).FirstOrDefault();
			int newid;
			if (book==null)
			{
				var item= bookitem;
				//save
				BookItem b = new BookItem();
				b.author = item.author;
				b.callno = item.callno;
				b.category = item.category;
				b.content = item.content;
				int d = 0;
				var bt=int.TryParse (item.date, out d);
				if (bt) {
					b.date = d;
				}


				b.picurl = picurl;
				b.IpacId = long.Parse(item.id);
				b.isbn = item.isbn;
				b.place = item.place;
				b.publisher = item.publisher;
				b.Titile = item.title;
				conn.Insert(b);
				newid = b.Id;
			}
			else
			{
				newid = book.Id;
			}
			//保存想读记录
			WantRead r = conn.Table<WantRead> ().Where (s => s.BookItemId == newid).FirstOrDefault ();
			if (r==null) {
				r = new WantRead ();
				r.AddDateTime = DateTime.Now;
				r.BookItemId = newid;

				conn.Insert(r);
			}

		}
	}
}

