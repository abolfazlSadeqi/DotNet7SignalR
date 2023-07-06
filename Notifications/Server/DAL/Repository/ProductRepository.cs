using Contract.Repository;
using DAL.Contexts;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(TestCurdContext context) : base(context) { }
}
