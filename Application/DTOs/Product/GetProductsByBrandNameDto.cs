﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class GetProductsByBrandNameDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
