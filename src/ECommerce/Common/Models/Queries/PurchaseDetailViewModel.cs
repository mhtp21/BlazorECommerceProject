using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Queries
{
    public class PurchaseDetailViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
