using RunningCompetitionMVVM.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;


namespace RunningCompetitionMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        private Result newResult;
        List<Result> allResults = new List<Result>();
        ObservableCollection<Result> results;

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
            }
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

                    allResults.Add(newResult);
                    results.Add(newResult);
                    SortResults();
                    OnPropertyChanged("Results");

                    newResult = new Result { Surname = "Surname", Name = "Name", Patronymic = "Patronymic", Age = 30, 
                            Distance = 1000, Date = DateTime.Now, Location = "Location", FinishTime = 60 };
                    OnPropertyChanged("NewResult");
                }));
            }
        }

        public void SortResults()
        {
            ObservableCollection<Result> temp;
            temp = new ObservableCollection<Result>(results.OrderByDescending(r => r.AverageSpeed).Take(5));
            results.Clear();
            foreach (Result j in temp) results.Add(j);
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
                    Distance = 1200, Date = DateTime.Now, Location = "Near KNU", FinishTime = 120 },

                new Result { Surname = "Savchuk", Name = "Andriy", Patronymic = "Viktorovych", Age = 20, 
                    Distance = 1000, Date = DateTime.Now, Location = "Stadium", FinishTime = 25 },

                new Result { Surname = "Zhmyshenko", Name = "Valeriy", Patronymic = "Albertovych", Age = 54,
                    Distance = 900, Date = DateTime.Now, Location = "Samara", FinishTime = 18 }
            };

            allResults = new List<Result>();
            allResults.Add(results[0]);
            allResults.Add(results[1]);
            allResults.Add(results[2]);

            SortResults();

            newResult = new Result { Surname = "Surname", Name = "Name", Patronymic = "Patronymic", Age = 30, 
                    Distance = 1000, Date = DateTime.Now, Location = "Location", FinishTime = 60 };
        }
    }
}
