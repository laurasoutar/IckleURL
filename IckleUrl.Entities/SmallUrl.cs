using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IckleUrl.Entities
{

	[Table("Ickle_Urls")]
	public class SmallUrl
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Required]
		[Column("full_url")]
		[StringLength(1000)]
		public string FullUrl { get; set; }


		[Required]
		[Column("ip")]
		[StringLength(50)]
		public string Ip { get; set; }

		[Required]
		[Column("pointer")]
		[StringLength(20)]
		public string Pointer { get; set; }

	}
}
