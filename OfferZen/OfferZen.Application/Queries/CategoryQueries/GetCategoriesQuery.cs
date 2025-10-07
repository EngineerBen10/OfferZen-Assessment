using MediatR;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Queries.CategoryQueries;

public record GetCategoriesQuery(): IRequest<IEnumerable<Category>>;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
{
    public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
         return await categoryRepository.GetCategoriesAsync(cancellationToken);
    }
}
