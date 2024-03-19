namespace PsychTestsMilitary.Models
{
    public class ScaleResult
    {
        public double Result { get; set; }
        public string Description { get; set; }

        public ScaleResult(double result, string description)
        {
            Result = result;
            Description = description;
        }
    }
}
