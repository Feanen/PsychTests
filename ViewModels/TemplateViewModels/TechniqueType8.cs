using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType8 : BaseTechniqueType, INotifyPropertyChanged
    {
        private SliderDataWrapper slidersData;
        public SliderDataWrapper SlidersData
        {
            get { return slidersData; }
            set 
            {
                slidersData = value;
                OnPropertyChanged(nameof(SlidersData));
            }
        }

        public override string QuestionNumber { 
            get => base.QuestionNumber; 
            set => base.QuestionNumber = "Назва фактора:"; 
        }

        public TechniqueType8(BaseTechniqueModel td) : base(td)
        {
            FillSlidersData();
            InitializeComponent();
            InitTechnique();
        }

        protected override void InitTechnique()
        {
            Technique = TechniqueData.Technique;

            if (TechniqueData != null) {
                Update();
            }
        }

        protected override void Update(Question question = null, Button nextBtn = null)
        {
            if (TechniqueData.Questions.Count.Equals(0))
                nextButton.Content = "Завершити тест";
        }

        private void FillSlidersData()
        {
            Question qstn = TechniqueData.NextQuestion(); 
            SlidersData = new SliderDataWrapper(qstn, null, 15);
        }

        private void ClickNextButton(object sender, EventArgs e)
        {
            SaveSlidersResult();

            if (TechniqueData.Questions.Count.Equals(0))
            {
                TechniquesManager.SaveAnswers(TechniqueData.Technique.Id, userAnswers as List<UserAnswer>);
                TechniquesManager.RunNextTechnique();
                Close();
            }
            else
                ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            FillSlidersData();
            OnPropertyChanged(nameof(SlidersData));
            Update();
        }

        private void SaveSlidersResult()
        {
            if (!SlidersData.IsEmpty())
                (userAnswers as List<UserAnswer>).Add(new UserAnswer(SlidersData.Qstn.Number, SlidersData.SliderResult));
        }

        private void SliderValueChangd(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;

            if (slider.Tag != null)
            {
                double newValue = slider.Value;
                SliderDataWrapper sliderData = slider.Tag as SliderDataWrapper;
                sliderData.SliderResult = (int) Math.Round(newValue);
            }
        }
    }
}
