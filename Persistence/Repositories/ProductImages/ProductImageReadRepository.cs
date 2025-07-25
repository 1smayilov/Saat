﻿using Application.Repositories.ProductImages;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ProductImages
{
    public class ProductImageReadRepository : ReadRepository<ProductImage>, IProductImageReadRepository
    {
        public ProductImageReadRepository(SaatDbContext context) : base(context)
        {
        }
    }
}
