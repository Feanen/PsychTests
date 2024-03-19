using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.Constructors
{
    public partial class TechniqueKeysConstructor : Window
    {
        private TechniquesContext context = new TechniquesContext();
        private List<TechniqueKey> keys;
        private TechniqueKey key = null;
        public TechniqueKeysConstructor()
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
                    Close();
                    wnd.Show();
                    break;
                case "addPair":
                    AddPair(qid.Text, aid.Text);
                    qid.Text = "";
                    break;
                case "addScale":
                    AddScale();
                    scale.Text = "";
                    break;
                case "addKey":
                    AddKey();
                    break;
            }
        }

        private void AddKey()
        {
            string json = JSONStringParser.StringToJSON(keys);
            Key km = new Key((techniques.SelectedItem as Technique).Id, json);
            context.Keys.Add(km);
            context.SaveChanges();
        }
        private void AddScale()
        {
            if (key != null)
            {
                keys.Add(key);
                key = null;
            }

        }
        private void AddPair(string QID, string AID)
        {
            if (string.IsNullOrEmpty(scale.Text))
                return;
            else if (string.IsNullOrEmpty(QID))
                return;
            else
            {
                if (key == null)
                {
                    key = new TechniqueKey(scale.Text);
                    key.Pairs = new List<QAPair>();
                }

                if (string.IsNullOrEmpty(AID))
                    key.Pairs.Add(new QAPair(int.Parse(QID)));
                else
                    key.Pairs.Add(new QAPair(int.Parse(QID), int.Parse(AID)));
            }
        }

        private async Task<List<Technique>> GetTechniques()
        {
            return await context.Techniques.ToListAsync();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Technique> techs = await GetTechniques();
            keys = new List<TechniqueKey>();

            Question lastQuestion = context.Questions.OrderByDescending(q => q.qId).FirstOrDefault();
            int id = (lastQuestion == null) ? 0 : lastQuestion.qId;
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
            Question lastQuestion = context.Questions.Where(q => q.Technique_id == selectedTech.Id)
                .OrderByDescending(q => q.Number)
                .FirstOrDefault();
        }
    }
}
