using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipProject.Actions
{
    public enum ItemAction { EXIT, USERS_WITHOUT_ANSWER, RESET_USER_ANSWER }
    public static class ItemActionExtension
    {
        public static string nombreMenu(this ItemAction action)
        {
            switch (action)
            {
                case ItemAction.EXIT: return "SALIR";
                case ItemAction.USERS_WITHOUT_ANSWER: return "Clientes sin Respuesta";
                case ItemAction.RESET_USER_ANSWER: return "Resetear Respuesta secreta";
            }
            return null;
        }
    }
}
