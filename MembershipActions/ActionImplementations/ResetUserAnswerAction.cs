using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using SSO.Services;
using SSOServices.Services;


namespace MembershipProject.Actions.Implementation
{
    class ResetUserAnswerAction : ActionTemplate, IAction
    {
        private string username;
        private string newUserPassword;

        private static string[] paramsDescription = { "Username", "New Password" };

        #region IAction Members

        public void doAction()
        {
            var user = Membership.GetUser(username);
            if (user == null) throw new NullReferenceException("El usuario no existe");

            UsuarioService.ActualizarCampoUsuario((Guid)user.ProviderUserKey, "respuesta", ActionHelper.NA);
            
            string resettedPassword = user.ResetPassword();
            user.ChangePasswordQuestionAndAnswer(resettedPassword, ActionHelper.NA, ActionHelper.NA);

            string newPassword = newUserPassword;

            if (string.IsNullOrEmpty(newPassword))
            {
                newPassword = AccountMembershipService.GeneraPasswordAleatoria();
            }

            user.ChangePassword(resettedPassword, newPassword);

            write(newPassword);
        }


        public void initialize(string[] args)
        {
            validate(args);
            username = args[0];
            if (args.Length > 1)
            {
                newUserPassword = args[1].Trim();
            }
        }

        private static void validate(string[] args)
        {
            if (args == null || args.Length == 0) throw new ArgumentException("Debe especificar el cliente");
            if (args.Length > 2) throw new ArgumentOutOfRangeException("Demasiados argumentos");
            if (string.IsNullOrEmpty(args[0])) throw new ArgumentNullException("username");
        }

        public string[] paramList()
        {
            return paramsDescription;
        }

        public string nombre()
        {
            return "Resetear pregunta y contrasenia de usuario";
        }

        #endregion
    }
}
