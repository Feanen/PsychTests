using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType3 : BaseTechniqueType, INotifyPropertyChanged
    {
        private const int COLLECTION_SIZE = 4;

        private SliderDataWrapper[] slidersData;
        public SliderDataWrapper[] SlidersData
        {
            get { return slidersData; }
            set 
            {
                slidersData = value;
                OnPropertyChanged(nameof(SlidersData));
            }
        }

        public TechniqueType3(BaseTechniqueModel td) : base(td)
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
            SlidersData = new SliderDataWrapper[COLLECTION_SIZE];

            Question qstn = null;
            for (int i = 0; i < SlidersData.Length; i++)
            {
                qstn = TechniqueData.NextQuestion();

                if (qstn == null)
                    SlidersData[i] = new SliderDataWrapper(null, null);
                else
                    SlidersData[i] = new SliderDataWrapper(qstn, JSONStringParser.ParseAnswerOptions(qstn.Answer_options).ToArray());
            }
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
            foreach (var item in SlidersData)
                if (!item.IsEmpty())
                    (userAnswers as List<UserAnswer>).Add(new UserAnswer(item.Qstn.Number, item.SliderResult));
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;

            if (slider.DataContext != null)
            {
                double newValue = slider.Value;
                SliderDataWrapper sliderData = slider.DataContext as SliderDataWrapper;
                sliderData.SliderResult = (int) Math.Round(newValue);
            }
        }
    }

    public class SliderDataWrapper
    {
        public Question Qstn { get; set; }
        public AnswerOption[] Answrs { get; set; }
        public int SliderResult { get; set; }

        public SliderDataWrapper(Question question, AnswerOption[] answerOptions = null, int sliderResult = 50)
        {
            Qstn = question;
            Answrs = answerOptions;
            SliderResult = sliderResult;
        }

        public bool IsEmpty()
        {
            return Qstn == null;
        }
    }

    public class DataToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
