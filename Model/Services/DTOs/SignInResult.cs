using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService
{
    public class SignInResult
    {
        public String user_name { get; private set; }
        public long user_id { get;}
        public String user_surname { get; private set; }
        public String email { get; private set; }
        public String language { get; private set; }
        public String country { get; private set; }
        public long workshopId { get; private set; }

        //Constructor con language
        public SignInResult(long user_id, String user_name, String user_surname, String email, String language, String country, long workshopId)
        {
            this.user_name = user_name;
            this.user_surname = user_surname;
            this.email = email;
            this.language = language;
            this.country = country;
            this.workshopId = workshopId;
            this.user_id = user_id;
        }
        public override bool Equals(object obj)
        {

            UserProfileDetails target = (UserProfileDetails)obj;

            return (this.user_name == target.user_name)
                  && (this.user_surname == target.user_surname)
                  && (this.email == target.email)
                  && (this.language == target.language)
                  && (this.country == target.country)
                  && (this.workshopId == target.workshopId);
        }
        public override int GetHashCode()
        {
            return this.email.GetHashCode();
        }
    }
}