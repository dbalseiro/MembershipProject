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
                    var user = Membership.GetUser(s);
                    //if (user.PasswordQuestion != "N/A") 
                        Console.WriteLine(s);
                }
            }
        }

        public void initialize(string[] args) { }


        public string[] paramList()
        {
            return new List<string>().ToArray();
        }

        #endregion
    }
}
