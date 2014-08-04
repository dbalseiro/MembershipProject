using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipProject.Actions
{
    public delegate void WriteLine(string s);

    abstract class ActionTemplate
    {
        public WriteLine write { set; get; }

        public ActionTemplate() : this(null) { }
        public ActionTemplate(WriteLine w)
        {
            write = w;
        }
    }
}
