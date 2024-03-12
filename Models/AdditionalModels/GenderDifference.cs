namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class GenderDifference
    {
        public int id { get; set; }
        public int Gender { get; set; }
        public string Scale { get; set; }
        public double Median { get; set; }
        public double Delta { get; set; }

        public GenderDifference() { }

        public GenderDifference(int gender, string scale, double median, double delta)
        {
            Gender = gender;
            Scale = scale;
            Median = median;
            Delta = delta;
        }
    }
}
