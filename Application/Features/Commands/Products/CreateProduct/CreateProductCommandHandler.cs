using Application.Repositories.Products;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new Product()
            {
                BestSeller = request.BestSeller,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                Description = request.Description,
                GenderId = request.GenderId,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                OldPrice = request.DiscountPrice,
            });
            await _productWriteRepository.SaveChangesAsync();

            return new();
        }
    }
}
