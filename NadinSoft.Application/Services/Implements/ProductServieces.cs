using NadinSoft.Application.Services.Interfaces;
using NadinSoft.Domain.Entities;
using NadinSoft.Domain.Interface;
using NadinSoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.Services.Implements
{
    public class ProductServieces : IProductService
    {
        private IProductRepository _productRepository;
        private IGenericRepository<Products> _genericRepository;

        public ProductServieces(IProductRepository productRepository, IGenericRepository<Products> genericRepository)
        {
            _productRepository = productRepository;
            _genericRepository = genericRepository;
        }
        public async Task<List<ProductModel>> GetAllProducts()
        {
            var model = await _genericRepository.GetAllAsync();
            if (model.ToList().Count > 0)
            {
                return model.Select(c => new ProductModel
                {
                    IsAvailable = c.IsAvailable,
                    ManufactureEmail = c.ManufactureEmail,
                    ManufacturePhone = c.ManufacturePhone,
                    Name = c.Name,
                    ProductDate = c.ProductDate,
                    UserId = c.UserId
                }).ToList();

            }
            return new List<ProductModel>();
        }
    }
}
