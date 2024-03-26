using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService
{
    public class UserProfileDetails
    {
        public String user_name { get; private set; }

        public String user_surname { get; private set; }

        public String email { get; private set; }

        public String language { get; private set; }

        public long workshopId { get; private set; }

        public UserProfileDetails(String user_name, String user_surname, String email, String language, long workshopId) {
            this.user_name = user_name;
            this.user_surname = user_surname;
            this.email = email;
            this.language = language;
            this.workshopId = workshopId;
        }
        public UserProfileDetails(String user_name, String user_surname, String email, long workshopId)
        {
            this.user_name = user_name;
            this.user_surname = user_surname;
            this.email = email;
            this.language = "es";
            this.workshopId = workshopId;
        }

        public override bool Equals(object obj)
        {

            UserProfileDetails target = (UserProfileDetails)obj;

            return (this.user_name == target.user_name)
                  && (this.user_surname == target.user_surname)
                  && (this.email == target.email)
                  && (this.language == target.language)
                  && (this.workshopId == target.workshopId);
        }
        public override int GetHashCode()
        {
            return this.email.GetHashCode();
        }
    }
}