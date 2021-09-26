using MovieApp.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos
{
   public class UnitOfWork: Interfaces.IUnitOfWork
    {
        private readonly MovieDBContext _DbContext;

        public MovieRepositroy MovieRepository { get; private set; }

        public UnitOfWork(MovieDBContext context)
        {
            this._DbContext = context;
            this.MovieRepository = new MovieRepositroy(this._DbContext);
        }
        public void Dispose()
        {
            this._DbContext.Dispose();
        }
        public async Task Commit()
        {
            await this._DbContext.SaveChangesAsync();
        }
    }
}
