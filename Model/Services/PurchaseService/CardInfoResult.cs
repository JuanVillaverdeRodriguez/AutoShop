using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService
{
    public class CardInfoResult
    {
        private long cardNumber;
        private string type;
        private int csv;
        private DateTime expirationDate;
        private bool defaultCard;
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