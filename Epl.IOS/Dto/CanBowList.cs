using System;
using System.Collections;
using System.Collections.Generic;
using EnjoyPubLib.WebService;

namespace EnjoyPubLib.Dto
{
	public class CanBowList
	{
		public CanBowList ()
		{
			dictList = new Dictionary<string, IList<BookCollectionDetailResponseCollectionDetailItem>> ();
		}


		public IDictionary<string,IList<BookCollectionDetailResponseCollectionDetailItem>> dictList{ get; set;}
	}



}

