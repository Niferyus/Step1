using AutoMapper;
using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<CreateProductDto> Create(CreateProductDto item)
        {
           var entity = _mapper.Map<Product>(item);
           await _productRepository.Create(entity);
            return item;
        }

        public async Task Delete(int id)
        {
            var entity = await _productRepository.GetById(id);
            if (entity == null)
            {
                throw new Exceptions.NotFoundException($"Product with id {id} not found.");
            }

            await _productRepository.Delete(id);
        }

        public async Task<List<ProductListDto>> GetAllProduct()
        {
            var products = await _productRepository.GetAll();
            var productDtos = _mapper.Map<List<ProductListDto>>(products);
            return productDtos;
        }

        public async Task<ProductDetailDto> GetById(int id)
        {
            var entity = await _productRepository.GetById(id); 
            if (entity == null) 
            {
                throw new Exceptions.NotFoundException($"Product with id {id} not found.");
            }
            return _mapper.Map<ProductDetailDto>(entity);
        }

        public async Task<UpdateProductDto> Update(UpdateProductDto item)
        {
            var entity = _mapper.Map<Product>(item);
            await _productRepository.Update(entity);                       
            var updatedDto = _mapper.Map<UpdateProductDto>(entity);
            return updatedDto;
        }
    }
}
