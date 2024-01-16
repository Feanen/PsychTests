﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class AnswerOptions
    {
        public Queue<AnswerOption> Options { get; set; }
    }
}
