using MediatR;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferZen.Application.Commands.ProductCommands
{
    public record UpdateProductCommand(Product Product) : IRequest<Product>;

    public class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, Product>
    {
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.UpdateProductAsync(request.Product, cancellationToken);
        }
         
    }
   
}
