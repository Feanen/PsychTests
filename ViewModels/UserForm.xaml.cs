﻿using PsychTestsMilitary.Models;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


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
                    break;
                case "back":
                    value = dataQueue.Last();
                    dataQueue.RemoveLast();
                    dataQueue.AddFirst(value);
                    break;
            }

            ObservableTechniques = ShowTechniquesList();
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
            IEnumerator enumerator = dataQueue.GetEnumerator();
            DataWrapper[] data;

            while (enumerator.MoveNext())
            {
                data = enumerator.Current as DataWrapper[];

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != null)
                    {
                        if (data[i].Value)
                            chosenTests.Enqueue(data[i].Key);
                    }
                }
            }  

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
