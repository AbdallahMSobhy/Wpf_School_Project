namespace ITI_School__MVVM.Models
{
    public class Teachers
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Gendar Gendar { get; set; }
        public Subject Subject { get; set; }
        public string Image { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
        public Teachers() { }
    }
    public enum Gendar
    {
        Male,
        Female
    }
    public enum Subject
    {
        Arabic,
        Chemistry,
        English,
        Math,
        Physics
    }
}
