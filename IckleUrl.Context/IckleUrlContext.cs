using IckleUrl.Entities;
using System.Data.Entity;


namespace IckleUrl.Context
{
	public class IckleUrlContext : DbContext
	{
		public IckleUrlContext()
			: base("name=IckleUrl")
		{

		}

		public virtual DbSet<SmallUrl> ShortUrls { get; set; }
	}
}
