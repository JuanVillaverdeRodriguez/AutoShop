using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService
{
    class UsuarioService
    {
        public UsuarioService() {}

        [Inject]
        public IUsuarioDaoEF UsuarioDao { get; set; }

        [Transactional]
        public getAllUsers FindFeedUserDetails(long usrId, int startIndex, int size)
        {

            UserProfile user = UserProfileDao.Find(usrId);

            FeedUserDetails feedUserDetails = new FeedUserDetails(user.usrId, user.loginName, user.numFollows, user.numFollowers, FindPostUser(usrId, startIndex, size));

            return feedUserDetails;
        }
    }   
}
