using EmployeeManager.Entity;
using EmployeeManager.Menu;
using EmployeeManager.Service;

namespace EmployeeManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //Manager.ReadFile();


            //foreach (WorkActivity item in Manager.ReadWorkActivity())
            //{
            //   Console.WriteLine(item); 
            //}


            //foreach (Anagraphy item in Manager.ReadAnagraphy())
            //{
            //    Console.WriteLine(item);
            //}




            //foreach (Anagraphy item in Manager.LinkActivitiesToEmployees())
            //{
            //    Console.WriteLine(item);
            //    foreach (WorkActivity activity in item.WorkActivities)
            //    {
            //        Console.WriteLine("\t" + activity);
            //    }
            //}


            //Manager.PrintInfo();

            Menu.Menu.Show();
            
        }



    }
}
