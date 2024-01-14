using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType1 : Window
    {
        public BaseTechniqueMV TechniqueData { get; set; }
        public TechniqueType1(BaseTechniqueMV td) 
        {
            TechniqueData = td;
            InitializeComponent();
            InitTechnique();
        }

        private void InitTechnique()
        {
            if (TechniqueData != null) {
                this.Title = TechniqueData.Technique.Name;
                this.instruction.Text = TechniqueData.Technique.Instruction;

                Question question = TechniqueData.Questions.FirstOrDefault();

                this.question.Text = question.Number + ". " + question.Description;
                List<AnswerOption> answerOptions = JSONStringParcer.ParseAnswerOptions(question.Answer_options);

                for (int i = 0; i < answerOptions.Count; i++)
                {
                    Button button = FindName($"answer{i + 1}") as Button;
                    (button.Content as TextBlock).Text = answerOptions[i].Text;
                }
            }
        }

        private void ChooseAnswer(object sender, EventArgs e)
        {
        }

        private void NextQuestion(object sender, EventArgs e)
        {
        }
    }
}
