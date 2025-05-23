using Application.DTOs.Product;
using Application.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Products.GetAllProductWithAll
{
    public class GetAllProductWithAllQueryHandler : IRequestHandler<GetAllProductWithAllQueryRequest, GetAllProductWithAllQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductWithAllQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        async Task<GetAllProductWithAllQueryResponse> IRequestHandler<GetAllProductWithAllQueryRequest, GetAllProductWithAllQueryResponse>.Handle(GetAllProductWithAllQueryRequest request, CancellationToken cancellationToken)
        {
           List<GetAllProductWithAllDto> products = await _productReadRepository.GetAll(false)
                                                    .Skip(request.Page * request.Size).Take(request.Size)
                                                    .Include(p=>p.Gender)
                                                    .Include(p=>p.Category)
                                                    .Include(p=>p.Brand)
                                                    .Select(p=> new GetAllProductWithAllDto()
                                                    {
                                                        BestSeller = p.BestSeller,
                                                        BrandId = p.BrandId,
                                                        BrendName = p.Brand.Name,
                                                        CategoryId = p.CategoryId,
                                                        CategoryName = p.Category.Name,
                                                        Description = p.Description,
                                                        GenderId = p.GenderId,
                                                        GenderName = p.Gender.Name,
                                                        Id = p.Id,
                                                        Name = p.Name,
                                                        OldPrice = p.OldPrice,
                                                        Price = p.Price,
                                                        Stock = p.Stock
                                                    }).ToListAsync();
            return new()
            {
                Products = products
            };
        }
    }
}
