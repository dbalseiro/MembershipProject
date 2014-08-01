using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipProject.Actions
{
    class ActionFactory
    {
        public static IAction create(ItemAction item)
        {
            switch (item)
            {
                case ItemAction.EXIT: return null;
                case ItemAction.USERS_WITHOUT_ANSWER: return new UsersWithoutAnswerAction() as IAction;
            }
            return null;
        }

    }
}
