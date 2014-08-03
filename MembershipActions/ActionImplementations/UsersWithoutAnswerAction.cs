using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using SSOServices.Services;

namespace MembershipProject.Actions
{ 
    class UsersWithoutAnswerAction : ActionTemplate, IAction
    {
        #region ActionTemplate

        public UsersWithoutAnswerAction(WriteLine w) : base(w) { }

        #endregion

        #region IAction Members

        public void doAction()
        {
            using (var db = new DBServices(ActionHelper.SQL_USUARIOS_SIN_RESPUESTA))
            {
                foreach (string s in db.getStringValues("loweredusername"))
                {
                    var user = Membership.GetUser(s);
                    if (user.PasswordQuestion != "N/A")
                        write(s);
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
