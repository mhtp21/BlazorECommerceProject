using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Purchase : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public virtual User CreateSold { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
