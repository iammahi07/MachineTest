using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MachineTest
{
	public class Paginated<T> :List<T>
	{
		public int PageIndex { get; set; }
		public int TotalPages { get; set; }

		public Paginated(List<T> items,int count, int pageindex,int pagesize) 
		{
			PageIndex = pageindex;
			TotalPages = (int)Math.Ceiling(count / (double)pagesize);
			this.AddRange(items);
		}

		public bool HasPreviousPage => PageIndex > 1;

		public bool HasNextPage => PageIndex < TotalPages; 

		public static Paginated<T> CreatePage (List<T> source, int pageIndex, int pagesize)
		{
			var count = source.Count;
			var items = source.Skip((pageIndex -1) * pagesize).Take(pagesize).ToList();
			return new Paginated<T>(items,count ,pageIndex,pagesize);
		}
	}
}
