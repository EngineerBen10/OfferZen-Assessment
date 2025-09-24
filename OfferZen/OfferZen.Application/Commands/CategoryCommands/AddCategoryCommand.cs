using MediatR;
using OfferZen.Application.Events.CategoryEvents;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Commands.CategoryCommands;

public record AddCategoryCommand(Category Category) : IRequest<Category>;

public class AddCategoryCommandHandler(ICategoryRepository categoryRepository, IPublisher mediator)
    : IRequestHandler<AddCategoryCommand, Category>
{
    public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.AddCategoryAsync(request.Category, cancellationToken);
         await mediator.Publish(new CategoryCreatedEvent(category.Id));
        return category;
    }
}
