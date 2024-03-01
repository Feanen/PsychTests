using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType2 : Window
    {
        public BaseTechniqueModel TechniqueData { get; set; }
        private static Style normalButtonStyle;
        private static Style selectedButtonStyle;
        private List<UserAnswer> userAnswers = new List<UserAnswer>();
        private Button selectedButton;
        private Question currentQuestion;
        public TechniqueType2(BaseTechniqueModel td)
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
            if (TechniqueData != null)
            {
                this.Title = TechniqueData.Technique.Name;
                this.instruction.Text = TechniqueData.Technique.Instruction;

                Update(TechniqueData.NextQuestion());
            }
        }

        private void ChooseAnswer(object sender, EventArgs e)
        {
            ClearAnswerButtonsBack();
            nextButton.IsEnabled = true;
            (sender as Button).Style = selectedButtonStyle;
            selectedButton = sender as Button;
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
            userAnswers.Add(new UserAnswer(currentQuestion.Number, (selectedButton.Tag as AnswerOption).Id));
            Update(TechniqueData.NextQuestion());
            ClearAnswerButtonsBack();
        }

        private void Update(Question question)
        {
            if (question != null)
            {
                currentQuestion = question;
                nextButton.IsEnabled = false;
                this.question.Text = question.Number + ". " + question.Description;
                //Queue<AnswerOption> answerOptions = JSONStringParser.ParseAnswerOptions(question.Answer_options);


                if (TechniqueData.Questions.Count == 0)
                    nextButton.Content = "Завершити тест";
            }
            else
            {
                TechniquesManager.SaveAnswers(TechniqueData.Technique.Id, userAnswers);

                TechniquesManager.RunNextTechnique();
                this.Close();
            }
        }
    }
}
