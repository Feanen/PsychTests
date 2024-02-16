using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PsychTestsMilitary.ViewModels
{
    public partial class UserForm : BaseWindow, INotifyPropertyChanged
    {
        // Count of techniques names observed on the screen
        private const byte numberOfTechniquesInAColumn = 5;
        private LinkedList<DataWrapper[]> dataQueue = new LinkedList<DataWrapper[]>();
        
        //---------------- INotifyPropertyChanged realization--------------------------
        private ObservableCollection<DataWrapper> observableTechniques;
        public ObservableCollection<DataWrapper> ObservableTechniques
        {
            get { return observableTechniques; }
            set 
            {
                observableTechniques = value;
                OnPropertyChanged(nameof(ObservableTechniques));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int currentIndex;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                currentIndex = value;
                OnPropertyChanged(nameof(CurrentIndex));
            }
        }
        //-----------------------------------------------------------------------------


        public UserForm()
        {
            InitializeComponent();
            ConnectDictionaryData();
            ObservableTechniques = ShowTechniquesList();
            CurrentIndex = 0;
        }


        private void ConnectDictionaryData()
        {
            //observableTechniques = new ObservableCollection<DataWrapper[]>();
            List<Technique> techniques = TechniquesDBSingleton.Instance.GetTechniqueContext().Techniques.ToList();
            IEnumerator<Technique> enumerator = techniques.GetEnumerator();

            DataWrapper[] listOfTechs = new DataWrapper[numberOfTechniquesInAColumn];
            int index = 0;
            foreach (Technique technique in techniques)
            {
                if (enumerator.MoveNext())
                {
                    if (index.Equals(numberOfTechniquesInAColumn))
                    {
                        dataQueue.AddLast(listOfTechs);
                        listOfTechs = new DataWrapper[numberOfTechniquesInAColumn];
                        index = 0;
                    }

                    listOfTechs[index] = new DataWrapper(enumerator.Current, false);

                    index++;              
                } 
                else
                    dataQueue.AddLast(listOfTechs);
            }

            if (!index.Equals(0))
                dataQueue.AddLast(listOfTechs);
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DataWrapper[] value;

            switch (btn.Name)
            {
                case "forward":
                    value = dataQueue.First();
                    dataQueue.RemoveFirst();
                    dataQueue.AddLast(value);
                    ObservableTechniques = ShowTechniquesList();
                    break;
                case "back":
                    value = dataQueue.Last();
                    dataQueue.RemoveLast();
                    dataQueue.AddFirst(value);
                    ObservableTechniques = ShowTechniquesList();
                    break;
            }
        }

        private ObservableCollection<DataWrapper> ShowTechniquesList()
        {
            ObservableCollection<DataWrapper> list = new ObservableCollection<DataWrapper>();

            for (int i = 0; i < dataQueue.First().Length; i++)
                list.Add(dataQueue.First()[i]);

            return list;
        }

        private void BeginButtonClicked(object sender, RoutedEventArgs e)
        {
            Queue<Technique> chosenTests = new Queue<Technique>();

            //foreach (List<KeyValuePair<CheckBox, Technique>> pair in connectionBetweenCheckboxAndTechnique)
            //{
            //    if ((bool) pair.Key.IsChecked)
            //        chosenTests.Enqueue(pair.Value);
            //}

            if (chosenTests.Count > 0)
            {
                TestsQueueSingleton.Instance.Techniques = chosenTests;
                TechniquesManager.RunNextTechnique();
                this.Close();
            }
        }
    }

    public class DataWrapper
    {
        public Technique Key { get; set; }
        public bool Value { get; set; }

        public DataWrapper(Technique key, bool value) 
        { 
            Key = key;
            Value = value;
        }
    }
}
