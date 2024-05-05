using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PsychTestsMilitary.ViewModels
{
    public abstract class BaseTechniqueType : BaseWindow, INotifyPropertyChanged, IFullScreenable
    {
        public BaseTechniqueModel TechniqueData { get; set; }
        protected object userAnswers = new List<UserAnswer>();
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
        public virtual string QuestionNumber
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

        public BaseTechniqueType(BaseTechniqueModel td)
        {
            TechniqueData = td;
            DataContext = this;
        }

        protected abstract void InitTechnique();

        protected virtual void Update(Question question, Button nextBtn)
        {
            nextBtn.IsEnabled = false;
            nextBtn.Opacity = 0.3;

            if (question != null)
            {
                Question = question;
                QuestionNumber = question.Number.ToString();
                AnswerOptions = new ObservableCollection<AnswerOption>(JSONStringParser.ParseAnswerOptions(question.Answer_options));
            }
            else
            {
                TechniquesManager.SaveAnswers(TechniqueData.Technique.Id, userAnswers as List<UserAnswer>);
                TechniquesManager.RunNextTechnique();
                Close();
            }

            if (TechniqueData.Questions.Count == 0)
                nextBtn.Content = "Завершити тест";
        }

        protected virtual void ResetRadiobuttons(Grid grid)
        {
            foreach (Control ctrl in grid.Children)
            {
                if (ctrl is RadioButton)
                    (ctrl as RadioButton).IsChecked = false;
            }
        }

        protected virtual void AnswerSelected(object sender, EventArgs e, Button btn)
        {
            RadioButton rb = (RadioButton)sender;
            btn.IsEnabled = true;
            btn.Opacity = 1.0;
            selectedAnswer = rb.DataContext as AnswerOption;
        }

        protected virtual void ShowNextQuestion(object sender, EventArgs e, Grid grid, Button btn)
        {
            ResetRadiobuttons(grid);
            (userAnswers as List<UserAnswer>).Add(new UserAnswer(Question.Number, selectedAnswer.Id));
            Update(TechniqueData.NextQuestion(), btn);
        }

        public virtual void OnFullScreen()
        {
        }

        protected override void MaximizeButtonClicked(object sender, RoutedEventArgs e)
        {
            base.MaximizeButtonClicked(sender, e);
            OnFullScreen();
        }
    }
}
