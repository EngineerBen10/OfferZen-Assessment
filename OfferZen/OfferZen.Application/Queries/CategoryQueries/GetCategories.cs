using MediatR;
using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Queries.CategoryQueries;

public record GetCategories(): IRequest<IEnumerable<Category>>;

public class GetCategoriesHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategories, IEnumerable<Category>>
{
    public async Task<IEnumerable<Category>> Handle(GetCategories request, CancellationToken cancellationToken)
    {
         return await categoryRepository.GetCategoriesAsync(cancellationToken);
    }
}
