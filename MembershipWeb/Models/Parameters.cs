using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembershipWeb.Models
{
    public class Parameters : List<Parameter>
    {
        public string nombre { get; set; }
    }

    public class Parameter
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
