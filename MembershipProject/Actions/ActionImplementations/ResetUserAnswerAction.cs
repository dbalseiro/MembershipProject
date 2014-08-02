using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using SSO.Services;
using SSOServices.Services;


namespace MembershipProject.Actions
{
    class ResetUserAnswerAction : ActionTemplate, IAction
    {
        #region ActionTemplate

        public ResetUserAnswerAction(WriteLine w) : base(w) { }

        #endregion

        private string username;
        private static string[] paramsDescription = { "Username" };

        #region IAction Members

        public void doAction()
        {
            var user = Membership.GetUser(username);
            if (user == null) throw new NullReferenceException("El usuario no existe");

            UsuarioService.ActualizarCampoUsuario((Guid)user.ProviderUserKey, "respuesta", ActionHelper.NA);
            
            string resettedPassword = user.ResetPassword();
            user.ChangePasswordQuestionAndAnswer(resettedPassword, ActionHelper.NA, ActionHelper.NA);
            string newPassword = AccountMembershipService.GeneraPasswordAleatoria();
            user.ChangePassword(resettedPassword, newPassword);

            write(newPassword);
        }


        public void initialize(string[] args)
        {
            if (args == null || args.Length == 0) throw new ArgumentException("Debe especificar el cliente");
            if (args.Length > 1) throw new ArgumentOutOfRangeException("Demasiados argumentos");
            username = args[0];
        }

        public string[] paramList()
        {
            return paramsDescription;
        }

        #endregion
    }
}
