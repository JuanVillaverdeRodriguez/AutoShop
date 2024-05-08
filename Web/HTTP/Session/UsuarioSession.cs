using Es.Udc.DotNet.PracticaMaD.Model.Services.Cart;

namespace Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session
{
    public class UsuarioSession
    {

        private long userProfileId;

        private Cart cart;

        public long UserProfileId
        {
            get { return userProfileId; }
            set { userProfileId = value; }
        }

        public Cart UserCart
        {
            get { return cart; }
            set { cart = value; }
        }

    }
}


