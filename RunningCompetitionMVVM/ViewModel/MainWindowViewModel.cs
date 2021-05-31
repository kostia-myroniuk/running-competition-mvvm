using RunningCompetitionMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace RunningCompetitionMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        private Result newResult;
        private ObservableCollection<Result> results;

        public Result NewResult 
        {
            get { return newResult; }
            set 
            { 
                newResult = value;
                OnPropertyChanged("NewResult");
            }
        }

        public ObservableCollection<Result> Results
        {
            get { return results; }
            set 
            { 
                results = value;
                OnPropertyChanged("Results");
                OnPropertyChanged("SortedResults");
            }
        }

        public ObservableCollection<Result> SortedResults
        {
            get { return results; }
        }

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    Result o = (Result)obj;
                    Result result = new Result { Surname = o.Surname, Name = o.Name, Patronymic = o.Patronymic, Age = o.Age, 
                        Location = o.Location, Distance = o.Distance, FinishTime = o.FinishTime };
                    results.Add(result);
                    OnPropertyChanged("SortedResults");

                    newResult = new Result { Surname = "Surname", Name = "Name", Patronymic = "Patronymic", Age = 30, 
                            Distance = 1000, Date = DateTime.Now, Location = "Location", FinishTime = 60 };
                    OnPropertyChanged("NewResult");
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowViewModel()
        {
            results = new ObservableCollection<Result>()
            {
                new Result { Surname = "Koval", Name = "Yuriy", Patronymic = "Vitaliyovych", Age = 90, 
                    Distance = 1000, Date = DateTime.Now, Location = "Near KNU", FinishTime = 5 },

                new Result { Surname = "Savchuk", Name = "Andriy", Patronymic = "Viktorovych", Age = 20, 
                    Distance = 1000, Date = DateTime.Now, Location = "Stadium", FinishTime = 15 },

                new Result { Surname = "Zhmyshenko", Name = "Valeriy", Patronymic = "Albertovych", Age = 54,
                    Distance = 1488, Date = DateTime.Now, Location = "Samara", FinishTime = 3 }
            };

            newResult = new Result { Surname = "Surname", Name = "Name", Patronymic = "Patronymic", Age = 30, 
                    Distance = 1000, Date = DateTime.Now, Location = "Location", FinishTime = 60 };
        }
    }
}
