using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int FailLoginCount { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set;}
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public IList<Offer> GivenOffer { get; set; }
        public IList<Offer> TakingOffer { get; set; }
    }
}
