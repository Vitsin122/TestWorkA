using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkA.Models
{
    public class Technic
    {
        public int Id { get; set; }
        public double Xposition { get; set; }
        public double Yposition { get; set; }
        public bool isModifide { get; set; } = false;
    }
}
