using MembershipWeb.Models;
using MembershipProject.Actions;

namespace MembershipWeb.Helpers
{
    public class HomeHelper
    {
        private string result = "";
        private void writer(string s) {
            result += s + "<br />";
        }

        public string getText()
        {
            return result;
        }

        public Menu getMenu()
        {
            var menu = new Menu();
            int i = 0;
            foreach (ItemAction item in ItemAction.Actions)
            {
                if (item.Equals(ItemAction.EXIT)) continue;
                menu.Add(new MenuItem()
                {
                    id = i++,
                    item = item
                });
            }
            return menu;
        }

        public IAction getItemAction(int id, Menu menu)
        {
            ItemAction itemAction = null;
            foreach (var item in menu)
            {
                if (item.id == id)
                {
                    itemAction = item.item;
                    break;
                }
            }

            return ActionFactory.create(itemAction, writer);

        }

        public Parameters getParameters(IAction action)
        {
            var model = new MembershipWeb.Models.Parameters()
            {
                nombre = action.nombre()
            };
            foreach (string text in action.paramList())
            {
                model.Add(new MembershipWeb.Models.Parameter()
                {
                    text = text
                });
            }
            return model;
        }
    }
}