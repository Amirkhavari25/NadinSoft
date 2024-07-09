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
        Task AddProduct(ProductModel product);
        Task<ProductModel> GetProductById(int id);
        Task<bool> UpdateProduct(int productId,ProductModel product);
        Task<bool> RemoveProduct(int productId);
    }
}
