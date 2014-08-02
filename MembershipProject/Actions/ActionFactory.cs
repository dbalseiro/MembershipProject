using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipProject.Actions
{
    class ActionFactory
    {
        public static IAction create(ItemAction item, WriteLine writer)
        {
            switch (item)
            {
                case ItemAction.EXIT: return null;
                case ItemAction.USERS_WITHOUT_ANSWER: return new UsersWithoutAnswerAction(writer) as IAction;
                case ItemAction.RESET_USER_ANSWER: return new ResetUserAnswerAction(writer) as IAction;
            }
            return null;
        }

    }
}
