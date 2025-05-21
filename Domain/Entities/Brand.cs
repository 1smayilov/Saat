using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }

        
        public ICollection<Product> Products { get; set; }

        //public Brand(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}
    }
}
