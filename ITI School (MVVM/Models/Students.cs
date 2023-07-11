using System.Collections.Generic;

namespace ITI_School__MVVM.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gendar Gendar { get; set; }
        public string Subjlist { get; set; }
        public string Image { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
        public Students() { }
        
    }
}
