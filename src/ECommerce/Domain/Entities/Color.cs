using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
