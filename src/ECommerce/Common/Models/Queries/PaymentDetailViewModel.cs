using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Queries
{
    public class PaymentDetailViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid PurchaseId { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string ExpirationDate { get; set; }
        public decimal MoneyInTheCard { get; set; }
       
    }
}
