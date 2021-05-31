using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RunningCompetitionMVVM.Model
{
    public class Result : INotifyPropertyChanged
    {
        private string surname;
        private string name;
        private string patronymic;
        private int age;
        private DateTime date;
        private string location;
        private int distance;
        private double finishTime;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged("Surname"); }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; OnPropertyChanged("Patronymic"); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("Age"); }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }

        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged("Location"); }
        }

        public int Distance
        {
            get { return distance; }
            set { distance = value; OnPropertyChanged("Distance"); OnPropertyChanged("AverageTime"); }
        }

        public double FinishTime
        {
            get { return finishTime; }
            set { finishTime = value; OnPropertyChanged("FinishTime"); OnPropertyChanged("AverageTime"); }
        }

        public double AverageSpeed
        {
            get { return (double)distance / finishTime; }
            set { }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
