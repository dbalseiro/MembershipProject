﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MembershipProject.Actions;

namespace MembershipProject
{
   
    class Program
    {
        private static ItemAction action;
        private static bool interactive = true;
        private static string[] extraparams;
        private static int errorlevel=0;
        static int Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                interactive = false;
                cliLoop(args);
            }
            else
            {
                interactive = true;
                interactiveLoop();
            }
            return errorlevel;
        }

        private static void interactiveLoop()
        {
            while (true)
            {
                printMenu();
                try
                {
                    selectAction();
                    if (action == ItemAction.EXIT) break;
                    doAction();
                }
                catch (Exception ex)
                {
                    handleException(ex);
                }
            }
        }

        private static void cliLoop(string[] args)
        {
            try
            {
                handleParams(args);
                doAction();
            }
            catch (Exception e)
            {
                handleException(e);
            }
        }

        private static void doAction()
        {
            if (action == ItemAction.EXIT) return;
            var executor = ActionFactory.create(action, Console.WriteLine);
            if (interactive) askforParams(executor.paramList());
            executor.initialize(extraparams);
            executor.doAction();
        }

        private static void askforParams(string[] paramList)
        {
            var l = new List<string>();
            foreach (string s in paramList)
            {
                Console.Write(s + ": ");
                l.Add(Console.ReadLine());
            }
            extraparams = l.ToArray();
        }

        private static void handleException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            if (interactive)
            {
                Console.Write("Presione ENTER para continuar . . .");
                Console.ReadLine();
                Console.WriteLine();
            }
            else
            {
                errorlevel = 1;
            }

        }

        private static void handleParams(string[] args)
        {
            try
            {
                if (args.Length < 1) throw new ArgumentException();
                string sarg = args[0];
                if (sarg == "?")
                {
                    usage();
                    action = ItemAction.EXIT;
                    return;
                }
                int arg = int.Parse(sarg);
                if (arg < 1 || arg > ItemAction.Actions.Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                parseSelection(sarg);

                List<string> arr = new List<string>();
                for (int i = 1; i < args.Length; i++)
                {
                    arr.Add(args[i]);
                }
                extraparams = arr.ToArray();
            }
            catch (Exception e)
            {
                usage();
                throw e;
            }
        }

        private static void usage()
        {
            Console.WriteLine("USO: membership [arg] ...");
            Console.WriteLine("Si Arg es vacio se muestra programa interactivo");
            Console.WriteLine("Si arg es ? se muestra esta ayuda");
            Console.WriteLine("o puede ser alguna de las siguientes opciones");
            printMenu();
        }

        private static void printMenu()
        {
            int i = 0;
            foreach (ItemAction item in ItemAction.Actions)
            {
                Console.WriteLine(i++ + ")\t" + item.nombreMenu());
            }
        }

        private static void selectAction()
        {
            Console.Write("Seleccione una opcion: ");
            string r = Console.ReadLine();
            Console.WriteLine();
            parseSelection(r);
        }

        private static void parseSelection(string r)
        {
            int seleccion = int.Parse(r);
            action = ItemAction.Actions[seleccion];
        }
    }
}
