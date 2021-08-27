using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
	public class IndexModel : PageModel
	{
		private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

		public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
		{
			_context = context;
		}

		/// <summary>
		/// 数据列表
		/// </summary>
		public IList<Movie> Movie { get; set; }

		/// <summary>
		/// 异步查询
		/// </summary>
		/// <returns></returns>
		public async Task OnGetAsync()
		{
			IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;
			//使用linq查询
			var movies = from m in _context.Movie select m;
			if (!string.IsNullOrWhiteSpace(SearchString))
			{
				movies = movies.Where(s => s.Title.Contains(SearchString));
			}

			if (!string.IsNullOrWhiteSpace(MovieGenre))
			{
				movies = movies.Where(x => x.Genre == MovieGenre);
			}

			//赋值流派数据
			Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
			//Movie = await _context.Movie.ToListAsync();
			Movie = await movies.ToListAsync();
		}

		/// <summary>
		/// 包含用户在搜索文本框中输入的文本
		/// </summary>
		[BindProperty(SupportsGet = true)]
		public string SearchString { get; set; }

		public SelectList Genres { get; set; }

		/// <summary>
		/// 查询条件流派
		/// </summary>
		[BindProperty(SupportsGet = true)]
		public string MovieGenre { get; set; }

	}
}
