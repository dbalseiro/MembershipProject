using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using SSOServices.Services;

namespace MembershipProject.Actions
{
    class UsersWithoutAnswerAction : IAction
    {
        #region IAction Members

        public void doAction()
        {
            string sql = string.Format(@"
                select loweredusername
                from usuario u, ora_aspnet_users o 
                where o.userid = u.idusuario
                and respuesta is null
            ");
            using (var db = new DBServices(sql))
            {
                foreach (string s in db.getStringValues("loweredusername"))
                {
                    Console.WriteLine(s);
                }
            }
        }

        #endregion
    }
}
