using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
	public class Movie
	{
		public int ID { get; set; }

		public string Title { get; set; }

		/// <summary>
		/// [DataType(DataType.Date)]：[DataType] 属性指定数据的类型 (Date)。 通过此特性
		/// 用户无需在日期字段中输入时间信息
		/// 仅显示日期，而非时间信息
		/// </summary>
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }

		public string Genre { get; set; }

		public decimal Price { get; set; }

	}
}
