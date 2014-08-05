using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using SSOServices.Services;

namespace MembershipProject.Actions.Implementation
{ 
    class UsersWithoutAnswerAction : ActionTemplate, IAction
    {
        #region IAction Members

        public void doAction()
        {
            using (var db = new DBServices(ActionHelper.SQL_USUARIOS_SIN_RESPUESTA))
            {
                foreach (string s in db.getStringValues("loweredusername"))
                {
                    var user = Membership.GetUser(s);
                    if (user.PasswordQuestion != "N/A" && !user.IsApproved)
                        write(s);
                }
            }
        }

        public void initialize(string[] args) { }


        public string[] paramList()
        {
            return new List<string>().ToArray();
        }

        public string nombre()
        {
            return "Usuarios sin Respuesta cargada";
        }

        #endregion
    }
}
