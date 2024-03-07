using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.Constructors
{
    public partial class QuestionsConstructor : Window
    {
        int id;
        public QuestionsConstructor()
        {
            InitializeComponent();
        }


        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "back":
                    DeveloperToolsConstructor wnd = new DeveloperToolsConstructor();
                    this.Close();
                    wnd.Show();
                    break;
                case "add":
                    Question question = new Question(id++, Int32.Parse(number.Text), this.description.Text, (techniques.SelectedItem as Technique).Id);
                    TechniquesDBSingleton.Instance.GetTechniqueContext().Questions.Add(question);
                    TechniquesDBSingleton.Instance.GetTechniqueContext().SaveChanges();
                    Update();
                    break;
            }
        }

        private List<Technique> GetTechniques()
        {
            return TechniquesDBSingleton.Instance.GetTechniqueContext().Techniques.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Technique> techs = GetTechniques();

            Question lastQuestion = ((TechniquesDBSingleton.Instance.GetTechniqueContext().Questions.OrderByDescending(q => q.qId).FirstOrDefault()) as Question);
            id = (lastQuestion == null) ? 0 : lastQuestion.qId;
            techniques.ItemsSource = techs;
            techniques.DisplayMemberPath = "Name";
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (techniques.SelectedItem != null)
                Update();
        }

        private void Update()
        {
            Technique selectedTech = (Technique)techniques.SelectedItem;
            Question lastQuestion = TechniquesDBSingleton.Instance.GetTechniqueContext().Questions.Where(q => q.Technique_id == selectedTech.Id)
                .OrderByDescending(q => q.Number)
                .FirstOrDefault();

            description.Text = null;
            if (lastQuestion == null)
                number.Text = "1";
            else
                number.Text = (lastQuestion.Number + 1).ToString();
        }
    }
}
