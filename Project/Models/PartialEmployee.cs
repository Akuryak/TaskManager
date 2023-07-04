using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public partial class Employee
    {
        public string Fullname { get { return $"{Surname} {Name} {Patronomic}"; } }
    }
}
