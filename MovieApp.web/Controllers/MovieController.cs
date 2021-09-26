using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.web.Controllers
{
    
    public class MovieController : Controller
    {
        private readonly UnitOfWork _UoW;


        public MovieController(IUnitOfWork uow)
        {
            this._UoW = uow as UnitOfWork;
        }
        public IActionResult Index()
        {
            dynamic model = new ExpendoObject();
            model.Movies = this._UoW.MovieRepository.GetTopMovieInAYear(2016,count:5);
            return View("MovieDetailView",model);
        }
    }
}
