using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService
{
    public class CardInfoResult
    {
        public long cardNumber { get; private set; }
        public string type { get; private set; }
        public int csv { get; private set; }
        public DateTime expirationDate { get; private set; }
        public bool defaultCard { get; private set; }
        public CardInfoResult(long cardNumber, string type, int csv, DateTime expirationDate, bool defaultCard)
        {
            this.cardNumber = cardNumber;
            this.type = type;
            this.csv = csv;
            this.expirationDate = expirationDate;
            this.defaultCard = defaultCard;
        }
    }
}