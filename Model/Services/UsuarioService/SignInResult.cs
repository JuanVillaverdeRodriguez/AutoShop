namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService
{
    public class SignInResult
    {

        private string user_name { get; set; }
        private string user_surname { get; set; }
        private string email { get; set; }
        private string language { get; set; }
        private long workshopid { get; set; }

        public SignInResult(string user_name, string user_surname, string email, long workshopId, string language)
        {
            this.user_name = user_name;
            this.user_surname = user_surname;
            this.email = email;
            this.language = language;
            this.workshopid = workshopid;

        }
    }
}