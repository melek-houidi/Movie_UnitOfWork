using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Interfaces
{
   public interface IMovieRepository
    {
        IEnumerable<Movie> GetTopMovieInAYear(int year, int count);
    }
}
