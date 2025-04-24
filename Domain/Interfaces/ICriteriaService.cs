using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICriteriaService
    {
        List<Category> GetCategories();
        List<Product> GetProducts();
        List<Priority> GetPriorities();

        List<string> GetStatus();
    }
}
