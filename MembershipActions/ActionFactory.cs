using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipProject.Actions
{
    public class ActionFactory
    {
        public static IAction create(ItemAction item, WriteLine writer)
        {
            return item.createAction(writer);
        }

    }
}
