using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

public interface IUnitOfWork : IDisposable
{
    
    IProductRepository Product
    {
        get;
    }
    int Save();
}
