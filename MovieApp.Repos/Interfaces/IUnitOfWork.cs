using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        Task Commit();
    }
}
