using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels
{
    public abstract class BaseTechniqueType : BaseWindow, INotifyPropertyChanged
    {
        public BaseTechniqueModel TechniqueData { get; set; }
        protected List<UserAnswer> userAnswers = new List<UserAnswer>();
        protected AnswerOption selectedAnswer;

        protected ObservableCollection<AnswerOption> answerOptions;
        public ObservableCollection<AnswerOption> AnswerOptions
        {
            get { return answerOptions; }
            set
            {
                answerOptions = value;
                OnPropertyChanged(nameof(answerOptions));
            }
        }

        protected Technique technique;
        public Technique Technique
        {
            get { return technique; }
            set
            {
                technique = value;
                OnPropertyChanged(nameof(technique));
            }
        }

        protected string questionNumber;
        public string QuestionNumber
        {
            get { return questionNumber; }
            set
            {
                questionNumber = "Питання або твердження №" + value;
                OnPropertyChanged(nameof(questionNumber));
            }
        }

        protected Question question;
        public Question Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged(nameof(question));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public BaseTechniqueType(BaseTechniqueModel td)
        {
            TechniqueData = td;
            DataContext = this;
        }

        protected abstract void InitTechnique();

        protected void Update(Question question, Button nextBtn)
        {
            if (question != null)
            {
                Question = question;
                QuestionNumber = question.Number.ToString();
                nextBtn.IsEnabled = false;
                nextBtn.Opacity = 0.3;
                AnswerOptions = new ObservableCollection<AnswerOption>(JSONStringParser.ParseAnswerOptions(question.Answer_options));

                if (TechniqueData.Questions.Count == 0)
                    nextBtn.Content = "Завершити тест";
            }
            else
            {
                TechniquesManager.SaveAnswers(TechniqueData.Technique.Id, userAnswers);
                TechniquesManager.RunNextTechnique();
                this.Close();
            }
        }

        protected void ResetRadiobuttons(Grid grid)
        {
            foreach (Control ctrl in grid.Children)
            {
                if (ctrl is RadioButton)
                    (ctrl as RadioButton).IsChecked = false;
            }
        }

        protected void AnswerSelected(object sender, EventArgs e, Button btn)
        {
            RadioButton rb = (RadioButton)sender;
            btn.IsEnabled = true;
            btn.Opacity = 1.0;
            selectedAnswer = rb.DataContext as AnswerOption;
        }

        protected void ShowNextQuestion(object sender, EventArgs e, Grid grid, Button btn)
        {
            ResetRadiobuttons(grid);
            userAnswers.Add(new UserAnswer(Question.Number, selectedAnswer.Id));
            Update(TechniqueData.NextQuestion(), btn);
        }
    }
}
