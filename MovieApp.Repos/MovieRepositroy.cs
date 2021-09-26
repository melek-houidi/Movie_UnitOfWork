using MovieApp.data.Models;
using MovieApp.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieApp.Repos
{
    public class MovieRepositroy : GenericRepository<Movie>, IMovieRepository
    {
        private readonly MovieDBContext _DbContext;
        public MovieRepositroy(MovieDBContext context) : base(context)
        {
            this._DbContext = context;
        }
        public IEnumerable<Movie> GetTopMovieInAYear(int year , int count)
        {
            return (from m in this._DbContext.Movie
                    orderby m.Rating descending
                    where m.ReleaseDate.Year.Equal(year)
                    select m).take(count);
        }
    }
}

