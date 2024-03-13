using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType5 : BaseTechniqueType
    {
        public TechniqueType5(BaseTechniqueModel td) : base(td)
        {
            userAnswers = new List<UserMultipleAnswer>();
            InitializeComponent();
            InitTechnique();
        }

        protected override void InitTechnique()
        {
            Technique = TechniqueData.Technique;

            if (TechniqueData != null)
                Update(TechniqueData.NextQuestion(), nextButton);
        }

        protected override void Update(Question question, Button nextBtn)
        {
            if (question != null)
            {
                Question = question;
                QuestionNumber = question.Number.ToString();
                AnswerOptions = new ObservableCollection<AnswerOption>(JSONStringParser.ParseAnswerOptions(question.Answer_options));
            }
            else
            {
                TechniquesManager.SaveAnswers(TechniqueData.Technique.Id, userAnswers as List<UserMultipleAnswer>);
                TechniquesManager.RunNextTechnique();
                Close();
            }


            if (TechniqueData.Questions.Count == 0)
                nextBtn.Content = "Завершити тест";
        }


        protected override void ShowNextQuestion(object sender, EventArgs e, Grid grid, Button btn)
        {
            (userAnswers as List<UserMultipleAnswer>).Add(new UserMultipleAnswer(Question.Number, GetSelectedCheckboxesData()));
            ResetCheckboxes(answerButtonsGrid);
            Update(TechniqueData.NextQuestion(), btn);
        }

        private void ShowNextQuestion(object sender, EventArgs e)
        {
            ShowNextQuestion(sender, e, answerButtonsGrid, nextButton);
        }

        private List<int> GetSelectedCheckboxesData()
        {
            List<int> result = new List<int>();

            foreach (Control ctrl in answerButtonsGrid.Children)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox checkBox = (CheckBox) ctrl;
                    if ((bool) checkBox.IsChecked)
                    {
                        result.Add((checkBox.DataContext as AnswerOption).Id);
                    }
                }     
            }

            return result;
        }
    
        private void ResetCheckboxes(Grid grid)
        {
            foreach (Control ctrl in grid.Children)
            {
                if (ctrl is CheckBox)
                    (ctrl as CheckBox).IsChecked = false;
            }
        }
    }
}
