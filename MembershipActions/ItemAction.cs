using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MembershipProject.Actions
{
    public class ItemAction
    {
        private bool isExit;
        private IAction action;

        public ItemAction() : this(false) { }
        private ItemAction(bool isExit) : this(null, isExit) { }
        private ItemAction(IAction action) : this(action, false) { }
        private ItemAction(IAction action, bool isExit)
        {
            this.isExit = isExit;
            this.action = action;
        }      
        public static ItemAction EXIT = new ItemAction(true);

        public string nombreMenu()
        {
            if (this.isExit) return "SALIR";
            return action.nombre();
        }        

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ItemAction that = obj as ItemAction;
            if (this.isExit || that.isExit) return this.isExit == that.isExit;
            return this.nombreMenu() == that.nombreMenu();
        }

        public override int GetHashCode()
        {
            return this.nombreMenu().GetHashCode();
        }

        private static ItemAction[] actions;
        public static ItemAction[] Actions
        {
            get
            {
                if (actions == null) createActions();
                return actions;
            }
        }

        private static void createActions()
        {
            var ret = new List<ItemAction>();
            ret.Add(EXIT);
            var type = typeof(IAction);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            foreach (var t in types)
            {
                ret.Add(new ItemAction((IAction)Activator.CreateInstance(t)));
            }

            actions = ret.ToArray();
        }

        internal IAction createAction(WriteLine writer)
        {
            (this.action as ActionTemplate).write = writer;
            return this.action;
        }
    }
}
