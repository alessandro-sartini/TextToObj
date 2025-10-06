using EmployeeManager.Entity;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Service
{
    public static class Manager
    {

        private static string employeePath = ConfigurationManager.AppSettings["EmpFile"];

        private static string activityPath = ConfigurationManager.AppSettings["ActFile"];

        //private const string absPath = "C:\\Users\\aless\\OneDrive\\Desktop\\betacomEx\\toEntity";

        static string absPath = ConfigurationManager.AppSettings["DataFilePath"];

        private static List<string> toCorrect = new();

        private static List<string> anagraphyErrors = new();
        private static List<string> activityErrors = new();



        private static List<WorkActivity> ReadWorkActivity()
        {

            List<WorkActivity> activities = new();

            string activitiesFile = Path.Combine(absPath, activityPath);

            string[] activitiesTxt = File.ReadAllLines(activitiesFile);

            foreach (string act in activitiesTxt)
            {
                string[] fields = act.Split(';');
                string dateString = fields[0];
                DateTime dateValue;

                if (!DateTime.TryParseExact(dateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValue))
                {
                    Console.WriteLine("Data non valida, riga esclusa: " + act);
                    if (!activityErrors.Contains(act))
                        AddActivityError(act);
                    continue;
                }

                activities.Add(
                    new WorkActivity
                    {
                        Date = dateValue,
                        ActivityType = fields[1],
                        Hours = Convert.ToInt16(fields[2]),
                        WorkerId = fields[3],
                    });
            }


            return activities;
        }



        public static List<Anagraphy> ReadAnagraphy()
        {

            List<Anagraphy> employees = new();
            List<string> employeesToFix = new();

            string employeeFile = Path.Combine(absPath, employeePath);

            string[] employeesTxt = File.ReadAllLines(employeeFile);

            foreach (string emp in employeesTxt)
            {



                if (emp.Split(';').Length < 10)
                {
                    Console.WriteLine("Riga saltata per numero di colonne insufficiente: " + emp);
                    if (!anagraphyErrors.Contains(emp))
                        AddAnagraphyError(emp);

                    continue;
                }


                employees.Add(
                    new Anagraphy
                    {
                        Id = emp.Split(';')[0],
                        Name = emp.Split(';')[1],
                        role = emp.Split(';')[2],
                        office = emp.Split(';')[3],
                        age = Convert.ToInt16(emp.Split(';')[4]),
                        address = emp.Split(';')[5],
                        city = emp.Split(';')[6],
                        provinceCode = emp.Split(';')[7],
                        CAP = emp.Split(';')[8],
                        phone = emp.Split(';')[9],
                    });
            }


            return employees;
        }


        private static List<Anagraphy> LinkActivitiesToEmployees()
        {
            List<Anagraphy> employees = ReadAnagraphy();
            List<WorkActivity> activities = ReadWorkActivity();
            foreach (Anagraphy emp in employees)
            {
                emp.WorkActivities = activities.Where(a => a.WorkerId == emp.Id).ToList();
            }

            return employees;
        }


        public static void PrintInfo()
        {
            foreach (Anagraphy item in LinkActivitiesToEmployees())
            {
                Console.WriteLine(item);
                foreach (WorkActivity activity in item.WorkActivities)
                {
                    Console.WriteLine("\t" + activity);
                }
            }


        }

        private static void AddAnagraphyError(string errorRow)
        {
            anagraphyErrors.Add(errorRow);
        }

        private static void AddActivityError(string errorRow)
        {
            activityErrors.Add(errorRow);
        }


        public static void GetAnagraphyErrors()
        {
            foreach (string error in anagraphyErrors)
            {
                Console.WriteLine(error);
            }
        }

        public static void GetActivityErrors()
        {
            foreach (string error in activityErrors)
            {
                Console.WriteLine(error);
            }
        }



        public static List<string> GetParsingErrors()
        {
            List<string> errors = new();

            string employeeFile = Path.Combine(absPath, employeePath);
            string[] employeesTxt = File.ReadAllLines(employeeFile);

            foreach (string emp in employeesTxt)
            {
                if (emp.Split(';').Length < 10)
                {
                    errors.Add($"Anagraphy: {emp}");
                }
            }

            string actFile = Path.Combine(absPath, activityPath);
            string[] actTxt = File.ReadAllLines(employeeFile);

            foreach (string activity in actTxt)
            {
                string[] fields = activity.Split(';');
                if (!DateTime.TryParseExact(fields[0], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
                {
                    errors.Add($"Activity: {activity}");
                }
            }

            return errors;

        }

        public static List<string> GetParsingErrorsV2(string error)
        {
            if (error == null)
            {
                return toCorrect;
            }
            else
            {
                toCorrect.Add(error);

                return toCorrect;
            }
        }



        public static void ReadFile()
        {
            List<Anagraphy> employees = new();
            List<Anagraphy> employeesToFix = new();

            string employeeFile = Path.Combine(absPath, employeePath);
            //string activitiesFile = Path.Combine(absPath, activityPath);

            string[] employeesTxt = File.ReadAllLines(employeeFile);

            foreach (string emp in employeesTxt)
            {



                if (emp.Split(';').Length < 10)
                {
                    Console.WriteLine("Riga saltata per numero di colonne insufficiente: " + emp);
                    continue;
                }


                employees.Add(
                    new Anagraphy
                    {
                        Id = emp.Split(';')[0],
                        Name = emp.Split(';')[1],
                        role = emp.Split(';')[2],
                        office = emp.Split(';')[3],
                        age = Convert.ToInt16(emp.Split(';')[4]),
                        address = emp.Split(';')[5],
                        city = emp.Split(';')[6],
                        provinceCode = emp.Split(';')[7],
                        CAP = emp.Split(';')[8],
                        phone = emp.Split(';')[9],
                    });
            }




            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }
    }
}
