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
    public partial class TechniqueType2 : Window
    {
        public BaseTechniqueMV TechniqueData { get; set; }
        private static Style normalButtonStyle;
        private static Style selectedButtonStyle;
        public TechniqueType2(BaseTechniqueMV td) 
        {
            TechniqueData = td;
            Loaded += WindowLoaded;
            InitializeComponent();
            InitTechnique();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            normalButtonStyle = (Style)FindResource("NormalAnswerButtonStyle");
            selectedButtonStyle = (Style)FindResource("SelectedAnswerButtonStyle");
        }

        private void InitTechnique()
        {
            if (TechniqueData != null) {
                this.Title = TechniqueData.Technique.Name;
                this.instruction.Text = TechniqueData.Technique.Instruction;

                Update(TechniqueData.Questions[0]);
            }
        }

        private void ChooseAnswer(object sender, EventArgs e)
        {
            ClearAnswerButtonsBack();
            nextButton.IsEnabled = true;
            (sender as Button).Style = selectedButtonStyle;
        }

        private void ClearAnswerButtonsBack()
        {
            foreach (Button btn in answerButtonsGrid.Children)
            {
                btn.Style = normalButtonStyle;
            }
        }

        private void NextQuestion(object sender, EventArgs e)
        {
            Update(TechniqueData.NextQuestion());
            ClearAnswerButtonsBack();
        }

        private void Update(Question question)
        {
            nextButton.IsEnabled = false;
            this.question.Text = question.Number + ". " + question.Description;
            List<AnswerOption> answerOptions = JSONStringParcer.ParseAnswerOptions(question.Answer_options);

            foreach (Button btn in answerButtonsGrid.Children)
            {
                (btn.Content as TextBlock).Text = answerOptions[0].Text;
                answerOptions.RemoveAt(0);
            }
        }
    }
}
