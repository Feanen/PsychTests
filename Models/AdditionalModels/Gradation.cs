﻿namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class Gradation
    {
        public int gradationID { get; set; }
        public int barrierID { get; set; }
        public int Value { get; set; }
        public Gradation() { }
        public Gradation(int gradID, int barrID, int value)
        {
            gradationID = gradID;
            barrierID = barrID;
            Value = value;
        }
    }
}
