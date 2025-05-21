using Application.Repositories.Products;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductReadRepository _productReadRepository;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.OldPrice = request.DiscountPrice;
            product.BestSeller = request.BestSeller;
            product.BrandId = request.BrandId;
            product.Stock = request.Stock;
            product.CategoryId = request.CategoryId;
            product.GenderId = request.GenderId;
            await _productWriteRepository.SaveChangesAsync();
            return new();
        }
    }
}
