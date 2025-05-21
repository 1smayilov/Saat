using Application.DTOs.Product;
using Application.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Products.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetListProductDto> products = await _productReadRepository.GetAll(false)
                .Skip(request.Page * request.Size).Take(request.Size)
                .Select(p=> new GetListProductDto()
                {
                    BestSeller = p.BestSeller,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    Description = p.Description,
                    DiscountPrice = p.OldPrice,
                    GenderId = p.GenderId,
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToListAsync();
            return new()
            {
                Products = products
            };
        }
    }
}
