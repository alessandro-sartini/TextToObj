using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManager.Entity
{
    public class Anagraphy
    {

        public string Id { get; set; }
        public string Name { get; set; } 

        public string role { get; set; }

        public string office { get; set; }

        public int age { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string provinceCode { get; set; }    

        public string CAP { get; set; }

        [Phone]
        public string phone { get; set; }


        public List<WorkActivity> WorkActivities { get; set; } = [];



        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name},\nRole: {role}, Office: {office}, \nAge: {age}, Address: {address}, City: {city}, CAP: {CAP}, \nProvince: {provinceCode}Phone: {phone}";
        }


    }
}
