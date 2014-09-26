using System.Collections.Generic;
using MembershipProject.Actions;

namespace MembershipWeb.Models
{
    public class Menu : List<MenuItem> { }
    public class MenuItem
    {
        public ItemAction item { get; set; }
        public int id { get; set; }
        public string text
        {
            get
            {
                return item == null ? "" : item.nombreMenu();
            }
        }
    }
}

