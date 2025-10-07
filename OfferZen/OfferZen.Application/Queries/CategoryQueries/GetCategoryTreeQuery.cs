using MediatR;
using OfferZen.Core.Dtos;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Queries.CategoryQueries;


public record GetCategoryTreeQuery(): IRequest<IEnumerable<CategoryDto>>;

public class GetCategoryTreeQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoryTreeQuery, IEnumerable<CategoryDto>>
{
    public async Task<IEnumerable<CategoryDto>> Handle(GetCategoryTreeQuery request,
        CancellationToken cancellationToken)
    {
        return await categoryRepository.GetCategoriesTreeAsync(cancellationToken);
    }
}