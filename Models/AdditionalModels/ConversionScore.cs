using System.ComponentModel.DataAnnotations;

namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class ConversionScore
    {
        [Key]
        public int id { get; set; }
        public int Gender { get; set; }
        public int Score { get; set; }
        public int L { get; set; }
        public int Ag { get; set; }
        public int Di { get; set; }
        public int A { get; set; }
        public int B_PTSD { get; set; }
        public int C_PTSD { get; set; }
        public int D_PTSD { get; set; }
        public int F_PTSD { get; set; }
        public int B_ASD { get; set; }
        public int C_ASD { get; set; }
        public int D_ASD { get; set; }
        public int E_ASD { get; set; }
        public int F_ASD { get; set; }
        public int PTSD { get; set; }
        public int ASD { get; set; }
        public int Dprs { get; set; }

        public ConversionScore() { }
        public ConversionScore(int id, int gender, int score, int l, int ag, int di, int a, int b_PTSD, int c_PTSD, int d_PTSD, int f_PTSD, int b_ASD, int c_ASD, int d_ASD, int e_ASD, int f_ASD, int pTSD, int aSD, int dprs)
        {
            this.id = id;
            Gender = gender;
            Score = score;
            L = l;
            Ag = ag;
            Di = di;
            A = a;
            B_PTSD = b_PTSD;
            C_PTSD = c_PTSD;
            D_PTSD = d_PTSD;
            F_PTSD = f_PTSD;
            B_ASD = b_ASD;
            C_ASD = c_ASD;
            D_ASD = d_ASD;
            E_ASD = e_ASD;
            F_ASD = f_ASD;
            PTSD = pTSD;
            ASD = aSD;
            Dprs = dprs;
        }


    }
}
