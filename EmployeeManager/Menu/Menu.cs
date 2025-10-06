using EmployeeManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Menu
{
    public static class Menu
    {

        public static void Show()
        {
            Manager.ReadAnagraphy();

            bool isSelect = true;
            while (isSelect)
            {
                Console.Clear();
                Console.WriteLine("Employee Manager");
                Console.WriteLine("1. Show Employees");
                //Console.WriteLine("2. Show Activities");
                Console.WriteLine("2. Show Error Employee");
                Console.WriteLine("3. Show Error Activities");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");
                string scelta = Console.ReadLine();

                int sceltaEnum;
                //controllo che la scelta sia
                //effettivamente valida altrimenti ancora!
                if (!int.TryParse(scelta, out sceltaEnum) || !Enum.IsDefined(typeof(MainEnumerator.Selection), sceltaEnum))
                {
                    Console.WriteLine("Scelta non valida, inserire un numero corretto!");
                    Console.WriteLine("Premi un tasto per riprovare...");
                    Console.ReadKey();
                    continue; 
                }
                switch ((MainEnumerator.Selection)sceltaEnum)
                {

                    case MainEnumerator.Selection.LoadList:
                        Console.WriteLine("All info:\n");

                        Manager.PrintInfo();

                        Console.WriteLine("\nPress any any key to continue...");
                        Console.ReadKey();
                        break;
                    case MainEnumerator.Selection.ShowEmpFix:
                        //Manager.ReadAnagraphy();
                        Console.WriteLine("Employees to fix:\n");
                        Manager.GetAnagraphyErrors();

                        Console.WriteLine("\nPress any any key to continue...");
                        Console.ReadKey();
                        break;
                    case MainEnumerator.Selection.ShowActFix:
                        //Manager.ReadAnagraphy();
                        Console.WriteLine("Activities to fix:\n");
                        Manager.GetActivityErrors();
                        Console.WriteLine("\nPress any any key to continue...");
                        Console.ReadKey();
                        break;

                    case MainEnumerator.Selection.ExitProgram:

                        isSelect = false;
                        break;
                    default: break;

                }

            }


        }   


    }
}
