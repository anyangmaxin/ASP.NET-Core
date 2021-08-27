using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
	public class Movie
	{
		public int ID { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// [DataType(DataType.Date)]：[DataType] 属性指定数据的类型 (Date)。 通过此特性
		/// 用户无需在日期字段中输入时间信息
		/// 仅显示日期，而非时间信息
		/// </summary>
		[Display(Name = "Release Date")]
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }

		/// <summary>
		/// 流派
		/// </summary>
		public string Genre { get; set; }

		/// <summary>
		/// 价格
		/// </summary>
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		/// <summary>
		/// 分级
		/// </summary>
		public string Rating { get; set; }

	}
}
