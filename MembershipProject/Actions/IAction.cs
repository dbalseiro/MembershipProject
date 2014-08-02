using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipProject.Actions
{
    interface IAction
    {
        void doAction();
        void initialize(string[] args);
        string[] paramList();
    }
}
