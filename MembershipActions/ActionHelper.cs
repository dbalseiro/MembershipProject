using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipProject.Actions
{
    class ActionHelper
    {
        public const string NA = "N/A";
        public const string SQL_USUARIOS_SIN_RESPUESTA = @"
            select loweredusername
            from usuario u, ora_aspnet_users o 
            where o.userid = u.idusuario
            and respuesta is null
        ";
    }
}
