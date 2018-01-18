using Hospital.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeCategory
{
    public class Clinic : BaseEntity
    {

        public string Name { get; set; }
        public Employee Employees { get; set; }
    }
}
