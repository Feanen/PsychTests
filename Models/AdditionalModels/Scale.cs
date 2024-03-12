namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class Scale
    {
        public int id { get; set; }
        public string Name { get; set; }

        public Scale() { }

        public Scale(string name)
        {
            Name = name;
        }
    }
}
