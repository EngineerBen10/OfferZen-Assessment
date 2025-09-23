using MediatR;
using OfferZen.Application.Events;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Commands.ProductCommands;
    public record AddProductCommand(Product Product): IRequest<Product>;
    
    public class AddProductCommandHandler(IProductRepository productRepository, IPublisher mediator) : IRequestHandler<AddProductCommand, Product>
    {
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = await  productRepository.AddProductAsync(request.Product, cancellationToken);
            await mediator.Publish(new ProductCreatedEvent(product.Id));
            return product;
        }
    }