using RunningCompetitionMVVM.ViewModel;
using RunningCompetitionMVVM.Model;
using System;
using Xunit;
using System.Collections.ObjectModel;
using System.Collections.Immutable;

namespace XUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            Assert.Equal("Zhmyshenko", vm.Results[0].Surname);
        }

        [Fact]
        public void Test2()
        {
            Result resultModel = new Result { Surname = "A", Name = "B", Patronymic = "C", Age = 30, 
                Date = DateTime.Now, Location = "Asd", Distance = 100, FinishTime = 10 };
            Assert.Equal(10, resultModel.AverageSpeed);
        }

        [Fact]
        public void Test3()
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            Result s1 = vm.Results[0];
            Result s2 = vm.Results[1];
            Result s3 = vm.Results[2];
            Result r1 = new Result { Surname = "A1", Name = "B1", Patronymic = "C1", Age = 30, 
                Date = DateTime.Now, Location = "Dsa", Distance = 500, FinishTime = 20 };

            vm.Results.Add(r1);
            vm.SortResults();

            var correct = new ObservableCollection<Result> { s1, s2, r1, s3};
            
            Assert.Equal(correct, vm.Results);
        }

        [Fact]
        public void Test4()
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            Result r1 = new Result { Surname = "A1", Name = "B1", Patronymic = "C1", Age = 30, 
                Date = DateTime.Now, Location = "Dsa", Distance = 60, FinishTime = 1 };

            vm.Results.Add(r1);
            vm.Results.Add(r1);
            vm.Results.Add(r1);
            vm.Results.Add(r1);
            vm.Results.Add(r1);
            vm.Results.Add(r1);
            vm.Results.Add(r1);
            vm.Results.Add(r1);
            vm.Results.Add(r1);
            vm.SortResults();
            
            Assert.Equal(5, vm.Results.Count);
        }

        [Fact]
        public void Test5()
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            Result s1 = vm.Results[0];
            Result s2 = vm.Results[1];
            Result s3 = vm.Results[2];
            Result r1 = new Result { Surname = "A1", Name = "B1", Patronymic = "C1", Age = 30, 
                Date = DateTime.Now, Location = "Dsa", Distance = 60, FinishTime = 1 };
            Result r2 = new Result { Surname = "A2", Name = "B2", Patronymic = "C2", Age = 25, 
                Date = DateTime.Now, Location = "Asd", Distance = 300, FinishTime = 3 };
            Result r3 = new Result { Surname = "A3", Name = "B3", Patronymic = "C3", Age = 45, 
                Date = DateTime.Now, Location = "Fgh", Distance = 130, FinishTime = 2 };

            vm.Results.Add(r1);
            vm.Results.Add(r2);
            vm.Results.Add(r3);
            vm.SortResults();

            var correct = new ObservableCollection<Result> { r2, r3, r1, s1, s2 };
            
            Assert.Equal(correct, vm.Results);
        }
    }
}
