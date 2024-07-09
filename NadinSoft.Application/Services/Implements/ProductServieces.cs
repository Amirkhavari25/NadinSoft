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

        public async Task AddProduct(ProductModel product)
        {
            var newProduct = new Products
            {
                Name = product.Name,
                ProductDate = product.ProductDate,
                ManufacturePhone = product.ManufacturePhone,
                ManufactureEmail = product.ManufactureEmail,
                IsAvailable = product.IsAvailable,
                UserId = product.UserId

            };
            await _genericRepository.AddAsync(newProduct);
            await _genericRepository.SaveChangesAsync();

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

        public async Task<ProductModel> GetProductForEdit(int id)
        {
            var product = await _productRepository.GetProductForEdit(id);
            if (product != null)
            {
                return new ProductModel
                {
                    Id = product.Id,
                    IsAvailable = product.IsAvailable,
                    ManufactureEmail = product.ManufactureEmail,
                    ManufacturePhone = product.ManufacturePhone,
                    Name = product.Name,
                    ProductDate = product.ProductDate,
                    UserId = product.UserId
                };

            }
            return new ProductModel();
        }

        public async Task<bool> UpdateProduct(int productId, ProductModel product)
        {
            var entity = await _genericRepository.GetByIdAsync(productId);
            if (entity != null)
            {
                entity.Name = product.Name;
                entity.ProductDate = product.ProductDate;
                entity.UserId = product.UserId;
                entity.ManufacturePhone = product.ManufacturePhone;
                entity.ManufactureEmail = product.ManufactureEmail;
                entity.IsAvailable = product.IsAvailable;
                await _genericRepository.Update(entity);
                await _genericRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
