using NadinSoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.Services.Interfaces
{
    public interface IProductService
    {
       Task<List<ProductModel>> GetAllProducts();
    }
}
