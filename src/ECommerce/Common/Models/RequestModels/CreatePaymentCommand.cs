using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels
{
    public class CreatePaymentCommand : IRequest<Guid>
    {
        public Guid PurchaseId { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string ExpirationDate { get; set; }
        public decimal MoneyInTheCard { get; set; }

        public CreatePaymentCommand()
        {

        }
        public CreatePaymentCommand(Guid pusrchaseId,string nameCard,string cardNumber,string cardCvv,string expirationDate,decimal moneyinCard)
        {
            PurchaseId = pusrchaseId;
            NameOnTheCard = nameCard;
            CardNumber = cardNumber;
            CardCvv = cardCvv;
            ExpirationDate = expirationDate;
            MoneyInTheCard = moneyinCard;
        }
    }
}
