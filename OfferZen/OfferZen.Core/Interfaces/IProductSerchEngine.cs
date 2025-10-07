using OfferZen.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferZen.Core.Interfaces
{
    public interface IProductSerchEngine
    {
        Task<PaginatedResult<ProductDto>> ProductSearchEngineAsync(ProductQueryDto productQueryDto, CancellationToken token);
    }
}
