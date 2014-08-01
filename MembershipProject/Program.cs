using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MembershipProject.Actions;

namespace MembershipProject
{
   
    class Program
    {
        private static ItemAction action;

        static void Main(string[] args)
        {
            while (true)
            {
                printMenu();
                try
                {
                    selectAction();
                    if (action == ItemAction.EXIT) break;
                    ActionFactory.create(action).doAction();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Presione ENTER para continuar . . .");
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }

        private static void printMenu()
        {
            int i = 0;
            foreach (ItemAction item in Enum.GetValues(typeof(ItemAction)))
            {
                Console.WriteLine(i++ + ")\t" + item.nombreMenu());
            }
        }

        private static void selectAction()
        {
            Console.Write("Seleccione una opcion: ");
            string r = Console.ReadLine();
            Console.WriteLine();
            int seleccion = int.Parse(r);
            action = (ItemAction)Enum.GetValues(typeof(ItemAction)).GetValue(seleccion);
        }

    }
}
