using MediatR;
using OfferZen.Core.Dtos;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Queries.CategoryQueries;


public record GetCategoryTreeCommand(): IRequest<IEnumerable<CategoryDto>>;

public class GetCategoryTreeQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoryTreeCommand, IEnumerable<CategoryDto>>
{
    public async Task<IEnumerable<CategoryDto>> Handle(GetCategoryTreeCommand request,
        CancellationToken cancellationToken)
    {
        return await categoryRepository.GetCategoriesTreeAsync(cancellationToken);
    }
}