using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType1 : BaseWindow, INotifyPropertyChanged
    {
        public BaseTechniqueModel TechniqueData { get; set; }
        private List<UserAnswer> userAnswers = new List<UserAnswer>();
        private AnswerOption selectedAnswer;

        private ObservableCollection<AnswerOption> answerOptions;
        public ObservableCollection<AnswerOption> AnswerOptions
        {
            get { return answerOptions; }
            set { answerOptions = value; 
                OnPropertyChanged(nameof(answerOptions));
            }
        }

        private Technique technique;
        public Technique Technique
        {
            get { return technique; }
            set {
                technique = value; 
                OnPropertyChanged(nameof(technique));
            }
        }

        private string questionNumber;
        public string QuestionNumber
        {
            get { return questionNumber; }
            set
            {
                questionNumber = "Питання №" + value;
                OnPropertyChanged(nameof(questionNumber));
            }
        }

        private Question question;
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

                                                                                                                                                                                                                                                                                                                                                                                                                   
        public TechniqueType1(BaseTechniqueModel td) 
        {
            TechniqueData = td;
            Loaded += WindowLoaded;
            DataContext = this;
            InitializeComponent();
            InitTechnique();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void InitTechnique()
        {
            Technique = TechniqueData.Technique;

            if (TechniqueData != null) {
                Update(TechniqueData.NextQuestion());
            }
        }

        private void AnswerSelected(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            nextButton.IsEnabled = true;
            selectedAnswer = rb.DataContext as AnswerOption;
        }

        private void NextQuestion(object sender, EventArgs e)
        {
            userAnswers.Add(new UserAnswer(Question.Number, selectedAnswer.Id));
            Update(TechniqueData.NextQuestion());
        }

        private void Update(Question question)
        {
            if (question != null)
            {
                Question = question;
                QuestionNumber = question.Number.ToString();
                nextButton.IsEnabled = false;
                AnswerOptions = new ObservableCollection<AnswerOption>(JSONStringParser.ParseAnswerOptions(question.Answer_options));

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
