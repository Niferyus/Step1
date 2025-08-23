using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProductService
    {
        Task<List<ProductListDto>> GetAllProduct();
        Task<PagedResult<ProductListDto>> GetAllProductPaged(PaginationRequest request);
        Task<ProductDetailDto> GetById(int id);
        Task<CreateProductDto> Create(CreateProductDto item);
        Task<UpdateProductDto> Update(UpdateProductDto item);
        Task Delete(int id);
    }
}
