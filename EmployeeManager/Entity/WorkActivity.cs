using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Entity
{
    public class WorkActivity
    {
        public string WorkerId { get; set; }

        public DateTime Date { get; set; }
        public string ActivityType { get; set; }
        public int Hours { get; set; }

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}, ActivityType: {ActivityType}, Hours: {Hours}, WorkerId: {WorkerId}";
        }

    }
}
