using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_School__MVVM.Models
{
    public class Subjects
    {
        public string Name { get; set; }
        public Subjects() { }
        public Subjects(string name) 
        {
            Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
