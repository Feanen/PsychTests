namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class CorrectionFactor
    {
        public int id { get; set; }
        public int CorrectionFull { get; set; }
        public int CorrectionFiftyPercent { get; set; }
        public int CorrectionFourtyPercent { get; set; }
        public int CorrectionTwentyPercent { get; set; }

        public CorrectionFactor() { }
        public CorrectionFactor(int correctionFull, int correctionFiftyPercent, int correctionFourtyPercent, int correctionTwentyPercent)
        {
            CorrectionFull = correctionFull;
            CorrectionFiftyPercent = correctionFiftyPercent;
            CorrectionFourtyPercent = correctionFourtyPercent;
            CorrectionTwentyPercent = correctionTwentyPercent;
        }
    }
}
