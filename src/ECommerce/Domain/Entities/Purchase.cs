using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Purchase
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }

        public virtual User CreateSold { get; set; }
    }
}
