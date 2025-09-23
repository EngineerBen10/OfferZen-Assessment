using MediatR;
using OfferZen.Application.Events;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Commands.ProductCommands;

    public record DeleteProductCommand(int ProductId) : IRequest<bool>;

    internal class DeleteProductCommandHandler(IProductRepository productRepository, IPublisher mediator) : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await mediator.Publish(new ProductDeletedEvent(request.ProductId));
            return await productRepository.DeleteProductAsync(request.ProductId, cancellationToken);
        }
    }